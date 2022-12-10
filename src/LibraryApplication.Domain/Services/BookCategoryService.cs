using LibraryApplication.Domain.Interfaces;
using LibraryApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Domain.Services
{
    public class BookCategoryService : IBookCategoryService
    {
        private readonly IBookCategoryRepository _bookCategoryRepository;

        public BookCategoryService(IBookCategoryRepository bookCategoryRepository)
        {
            _bookCategoryRepository = bookCategoryRepository;
        }

        public async Task<BookCategory> AddCategoryToBook(int bookId, int categoryId)
        {
            BookCategory bc = new()
            {
                BookId = bookId,
                CategoryId = categoryId
            };

            await _bookCategoryRepository.AddCategoryToBook(bc);
            return await _bookCategoryRepository.GetById(bc.BookId);
        }

        public Task DeleteCategoryFromBook(int bookId, int categoryId)
        {
            var bookCategoryList = _bookCategoryRepository.Search(bc => bc.BookId == bookId && bc.CategoryId == categoryId).Result;
            if (!bookCategoryList.Any())
            {
                return null;
            }
            foreach (BookCategory bookCategory in bookCategoryList)
            {
                _bookCategoryRepository.DeleteCategoryFromBook(bookCategory);
            }
            return Task.CompletedTask;
        }
    }
}
