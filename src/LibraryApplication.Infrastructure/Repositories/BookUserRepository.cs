using LibraryApplication.Domain.Interfaces;
using LibraryApplication.Domain.Models;
using LibraryApplication.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Infrastructure.Repositories
{
    public class BookUserRepository : Repository<BookUser>, IBookUserRepository
    {
        public BookUserRepository(LibraryApplicationDbContext context) : base(context) { }


        public Task AddActualUserToBook(BookUser bu)
        {
            Db.AddAsync(bu);
            Db.SaveChanges();
            return Task.CompletedTask;

        }

        public Task RemoveActualUserFromBook(BookUser bu)
        {
            Db.Update(bu);
            Db.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<ICollection<int>> GetBooksIdOfUser(int userId, bool actualUser)
        {
            var booksOfUserList = Search(bc => bc.UserId == userId && bc.ActualUser == actualUser).Result;
            List<int> result = new List<int>();
            foreach (var bc in booksOfUserList)
            {
                result.Add(bc.BookId);
            }

            return result;
        }

        public async Task<ICollection<int>> GetUsersIdOfBook(int bookId, bool actualUser)
        {
            var usersOfBookList = Search(bc => bc.BookId == bookId && bc.ActualUser == actualUser).Result;
            List<int> result = new List<int>();
            foreach (var bc in usersOfBookList)
            {
                result.Add(bc.UserId);
            }

            return result;
        }
    }
}