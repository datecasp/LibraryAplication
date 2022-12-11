using AutoMapper;
using LibraryApplication.API.Dtos.Book;
using LibraryApplication.Domain.Interfaces;
using LibraryApplication.Domain.Models;
using LibraryApplication.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.API.Controllers
{
    [Route("api/[controller]")]

    public class BookUserController : MainController
    {
        private readonly IBookUserService _bookUserService;
        private readonly IMapper _mapper;


        public BookUserController(IBookUserService bookUserService, IMapper mapper)
        {
            _bookUserService = bookUserService;
            _mapper = mapper;
        }

        [HttpPost("UserGetsBook/Book/{bookId:int}/userId/{userId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddActualUserToBook(int bookId, int userId)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _bookUserService.AddActualUserToBook(bookId, userId);

            if (!result) return BadRequest($"ERROR. Check CategoryId {userId} and BookId {bookId}");

            return Ok($"User {userId} gets book {bookId}");
        }

        [HttpDelete("UserReturnsBook/Book/{bookId:int}/userId/{userId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveActualUserFromBook(int bookId, int userId)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _bookUserService.RemoveActualUserFromBook(bookId, userId);

            if (!result) return BadRequest($"ERROR. Check CategoryId {userId} and BookId {bookId}");

            return Ok($"User {userId} returns book {bookId}");
        }

        [HttpGet("BooksOfUser/userId/{userId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FindBooksOfUser(int userId)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _bookUserService.FindBooksOfUser(userId);

            if (!result.Any()) return Ok($"There are no books assigned to User {userId}");

            return Ok(_mapper.Map<IEnumerable<BookResultDto>>(result));
        }
    }
}

