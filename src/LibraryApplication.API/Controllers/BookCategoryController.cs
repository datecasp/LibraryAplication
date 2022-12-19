using AutoMapper;
using LibraryApplication.API.Dtos.Book;
using LibraryApplication.API.Dtos.BookCategory;
using LibraryApplication.API.Dtos.Category;
using LibraryApplication.Domain.Interfaces;
using LibraryApplication.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryApplication.API.Controllers
{
    [Route("api/[controller]")]
    public class BookCategoryController : MainController
    {
        private readonly IBookCategoryService _bookCategoryService;
        private readonly IMapper _mapper;


        public BookCategoryController(IBookCategoryService bookCategoryService, IMapper mapper)
        {
            _bookCategoryService = bookCategoryService;
            _mapper = mapper;
        }

        [HttpPost("AddCategoryToBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddCategoryToBook(BookCategoryasicDto bookCategoryDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            
            var result = await _bookCategoryService.AddCategoryToBook(bookCategoryDto.BookId, bookCategoryDto.CategoryId);

            if (!result) return BadRequest($"ERROR. Check CategoryId {bookCategoryDto.CategoryId} and BookId {bookCategoryDto.BookId}");

            return Ok($"Category {bookCategoryDto.CategoryId} added to book {bookCategoryDto.BookId}");
        }

        [HttpDelete("RemoveCategory/Book/{bookId:int}/categoryId/{categoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCategoryFromBook(int bookId, int categoryId) 
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _bookCategoryService.DeleteCategoryFromBook(bookId, categoryId);

            if (!result) return BadRequest($"ERROR. Check CategoryId {categoryId} and BookId {bookId}");

            return Ok($"Category {categoryId} removed from book {bookId}");
        }

        [HttpGet("BooksWithCategory/categoryId/{categoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FindBooksWithCategory(int categoryId)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _bookCategoryService.FindBooksWithCategory(categoryId);

            if (!result.Any()) return Ok($"There are no books with category {categoryId}");

            return Ok(_mapper.Map<IEnumerable<BookResultDto>>(result));
        }

        [HttpGet("CategoriesOfBook/BookId/{bookId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FindCategoriesOfBook(int bookId)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _bookCategoryService.FindCategoriesOfBook(bookId);

            if (!result.Any()) return Ok($"There are no categories assigned to book {bookId}");

            return Ok(_mapper.Map<IEnumerable<CategoryResultDto>>(result));
        }
    }
}
