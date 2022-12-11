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
        public async Task<IActionResult> AddCategoryToBook(int bookId, int categoryId)
        {
            if (!ModelState.IsValid) return BadRequest();

            
            var result = await _bookCategoryService.AddCategoryToBook(bookId, categoryId);

            if (!result) return BadRequest($"ERROR. Check CategoryId {categoryId} and BookId {bookId}");

            return Ok($"Category {categoryId} added to book {bookId}");
        }

        [HttpDelete("Remove Category from Book/Book/{bookId:int}/categoryId/{categoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCategoryFromBook(int bookId, int categoryId) 
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _bookCategoryService.DeleteCategoryFromBook(bookId, categoryId);

            if (!result) return BadRequest($"ERROR. Check CategoryId {categoryId} and BookId {bookId}");

            return Ok($"Category {categoryId} removed from book {bookId}");
        }
    }
}
