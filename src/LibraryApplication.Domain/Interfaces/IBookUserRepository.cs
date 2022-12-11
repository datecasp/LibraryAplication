using LibraryApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Domain.Interfaces
{
    public interface IBookUserRepository : IRepository<BookUser>
    {
        Task AddActualUserToBook(BookUser bu);

        Task RemoveActualUserFromBook(BookUser bu);

        Task<ICollection<int>> GetBooksIdOfUser(int userId);
    }
}