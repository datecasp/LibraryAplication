using AutoMapper;
using LibraryApplication.Domain.Interfaces;
using LibraryApplication.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.API.Controllers
{
    [Route("api/[controller]")]
    public class BookCategoryController : MainController
    {
        private readonly IBookCategoryService _bookCategoryService;

        public BookCategoryController(IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
        }

        [HttpPost("Add Category to Book/Book/{bookId:int}/categoryId/{categoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddCategoryToBook(int bookId, int categoryId)
        {
            if (!ModelState.IsValid) return BadRequest();

            
            var result = _bookCategoryService.AddCategoryToBook(bookId, categoryId);

            if (result == null) return BadRequest();

            return Ok($"Category {categoryId} added to book {bookId}");
        }

        [HttpDelete("Remove Category from Book/Book/{bookId:int}/categoryId/{categoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteCategoryFromBook(int bookId, int categoryId) 
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = _bookCategoryService.DeleteCategoryFromBook(bookId, categoryId);
            if (result == null)
            { 
                return BadRequest();
            }
            return Ok($"Category {categoryId} removed from book {bookId}");
        }
    }
}
