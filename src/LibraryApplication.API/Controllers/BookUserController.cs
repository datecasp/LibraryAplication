using LibraryApplication.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.API.Controllers
{
    [Route("api/[controller]")]

    public class BookUserController : MainController
    {
        private readonly IBookUserService _bookUserService;

        public BookUserController(IBookUserService bookUserService)
        {
            _bookUserService = bookUserService;
        }

        [HttpPost("User gets Book/Book/{bookId:int}/userId/{userId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddActualUserToBook(int bookId, int userId)
        {
            if (!ModelState.IsValid) return BadRequest();


            var result = _bookUserService.AddActualUserToBook(bookId, userId);

            if (result == null) return BadRequest();

            return Ok($"User {userId} gets book {bookId}");
        }

        [HttpDelete("User returns Book/Book/{bookId:int}/userId/{userId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult RemoveActualUserFromBook(int bookId, int userId)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = _bookUserService.RemoveActualUserFromBook(bookId, userId);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok($"User {userId} returns book {bookId}");
        }
    }
}

