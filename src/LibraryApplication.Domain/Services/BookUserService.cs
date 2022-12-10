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

        public BookUserService(IBookUserRepository bookUserRepository)
        {
            _bookUserRepository = bookUserRepository;
        }

        public Task AddActualUserToBook(int bookId, int userId)
        {
            BookUser bu = new()
            {
                BookId = bookId,
                UserId = userId,
                ActualUser = true
            };

            _bookUserRepository.AddActualUserToBook(bu);
            return Task.CompletedTask;
        }

        public Task RemoveActualUserFromBook(int bookId, int userId)
        {
            var bookUserList = _bookUserRepository.Search(bc => bc.BookId == bookId && bc.UserId == userId).Result;
            if (!bookUserList.Any())
            {
                return null;
            }
            foreach (BookUser bookUser in bookUserList)
            {
                bookUser.ActualUser = false;
                _bookUserRepository.RemoveActualUserFromBook(bookUser);
            }
            return Task.CompletedTask;
        }
    }
}
