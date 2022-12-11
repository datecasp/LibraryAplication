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
    }
}