using LibraryApplication.Domain.Interfaces;
using LibraryApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Domain.Services
{
    public class BookUserService : IBookUserService
    {
        private readonly IBookUserRepository _bookUserRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;

        public BookUserService(IBookUserRepository bookUserRepository, IUserRepository userRepository, IBookRepository bookRepository)
        {
            _bookUserRepository = bookUserRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }

        public async Task<bool> AddActualUserToBook(int bookId, int userId)
        {
            bool userIsActive = _userRepository.Search(u => u.Id == userId && u.IsActive).Result.Any();
            bool bookIsNotAvaliable = _bookUserRepository.Search(bu => bu.BookId == bookId && bu.ActualUser).Result.Any();
                       
            if (userIsActive && !bookIsNotAvaliable) 
            {
                BookUser bu = new()
                {
                    BookId = bookId,
                    UserId = userId,
                    ActualUser = true
                };

                _bookUserRepository.AddActualUserToBook(bu);
                
                return true;
            }
            
            return false;
        }

        public async Task<bool> RemoveActualUserFromBook(int bookId, int userId)
        {
            var bookUserList = _bookUserRepository.Search(bc => bc.BookId == bookId && bc.UserId == userId && bc.ActualUser).Result;
            if (!bookUserList.Any())
            {
                return false;
            }
            foreach (BookUser bookUser in bookUserList)
            {
                bookUser.ActualUser = false;
                _bookUserRepository.RemoveActualUserFromBook(bookUser);
            }
            return true;
        }

        public async Task<IEnumerable<Book>> FindBooksOfUser(int userId)
        {
            var booksIdList = await _bookUserRepository.GetBooksIdOfUser(userId);
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
