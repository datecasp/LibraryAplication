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
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookCategoryService(IBookCategoryRepository bookCategoryRepository, IBookRepository bookRepository, ICategoryRepository catRepository)
        {
            _bookCategoryRepository = bookCategoryRepository;
            _bookRepository = bookRepository;
            _categoryRepository = catRepository;
        }

        public async Task<bool> AddCategoryToBook(int bookId, int categoryId)
        {
            // Check if relation exists previously
            bool bookCategoryList = _bookCategoryRepository.Search(bc => bc.BookId == bookId && bc.CategoryId == categoryId).Result.Any();
            // Check if book and category exists
            bool bookExists = _bookRepository.Search(b => b.Id == bookId).Result.Any();
            bool catExists = _categoryRepository.Search(c => c.Id == categoryId).Result.Any();

            if (bookCategoryList || !bookExists || !catExists)
            {
                return false;
            }

            BookCategory bc = new()
            {
                BookId = bookId,
                CategoryId = categoryId
            };

            await _bookCategoryRepository.AddCategoryToBook(bc);
            return true;
        }

        public async Task<bool> DeleteCategoryFromBook(int bookId, int categoryId)
        {
            var bookCategoryList = _bookCategoryRepository.Search(bc => bc.BookId == bookId && bc.CategoryId == categoryId).Result;
            if (!bookCategoryList.Any())
            {
                return false;
            }
            foreach (BookCategory bookCategory in bookCategoryList)
            {
                await _bookCategoryRepository.DeleteCategoryFromBook(bookCategory);
            }
            return true;
        }

        public async Task<IEnumerable<Book>> FindBooksWithCategory(int categoryId)
        {
            var booksIdList = await _bookCategoryRepository.GetBooksIdWithCategory(categoryId);
            var bookList = new List<Book>();
            if (booksIdList.Any())
            {
                foreach (var bookId in booksIdList)
                {
                    Book tempBook = await _bookRepository.GetById(bookId);
                    bookList.Add(tempBook);
                }
            }
            return bookList;
        }
    }
}
