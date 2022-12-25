using AutoMapper;
using LibraryApplication.API.Dtos.Book;
using LibraryApplication.API.Dtos.BookUser;
using LibraryApplication.API.Dtos.Category;
using LibraryApplication.API.Dtos.User;
using LibraryApplication.Domain.Interfaces;
using LibraryApplication.Domain.Models;
using LibraryApplication.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LibraryApplication.API.Controllers
{
    [Route("api/")]

    public class BookUserController : MainController
    {
        private readonly IBookUserService _bookUserService;
        private readonly IMapper _mapper;


        public BookUserController(IBookUserService bookUserService, IMapper mapper)
        {
            _bookUserService = bookUserService;
            _mapper = mapper;
        }

        [HttpPost("UserGetsBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddActualUserToBook(BookUserDto bookUserDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _bookUserService.AddActualUserToBook(bookUserDto.BookId, bookUserDto.UserId);

            if (!result) return BadRequest($"ERROR. Check UserId {bookUserDto.UserId} and BookId {bookUserDto.BookId}");

            return Ok($"User {bookUserDto.UserId} gets book {bookUserDto.BookId}");
        }

        [HttpPut("UserReturnsBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveActualUserFromBook(BookUserDto bookUserDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _bookUserService.RemoveActualUserFromBook(bookUserDto.BookId, bookUserDto.UserId);

            if (!result) return BadRequest($"ERROR. Check UserId {bookUserDto.UserId} and BookId {bookUserDto.BookId}");

            return Ok($"User {bookUserDto.UserId} returns book {bookUserDto.BookId}");
        }

        [HttpGet("BooksOfUser/userId/{userId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FindBooksOfUser(int userId, bool actualBooks = true)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _bookUserService.FindBooksOfUser(userId, actualBooks);

            if (!result.Any())
            {
                if (actualBooks) return Ok($"There are no books actually assigned to user {userId}");

                return BadRequest($"User {userId} has not past books");
            }
            return Ok(_mapper.Map<IEnumerable<BookResultDto>>(result));
        }

        [HttpGet("Books/UsersOfBook/BookId/{bookId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FindUsersOfBook(int bookId, bool actualUser = true)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _bookUserService.FindUsersOfBook(bookId, actualUser);

            if (!result.Any())
            {
                if(actualUser) return Ok($"There are no users actually assigned to book {bookId}");

                return BadRequest($"Book {bookId} has not past users");
            }
            
            return Ok(_mapper.Map<IEnumerable<UserResultDto>>(result));
        }

        [HttpGet("Books/AvailabilityOfBook/BookId/{bookId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> FindAvailabilityOfBook(int bookId)
        {
            if (!ModelState.IsValid) return false;

            var result = await _bookUserService.FindUsersOfBook(bookId, true);

            if (!result.Any())
            {
                return true;
            }

            return false;
        }
    }
}

