using LibraryApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Domain.Interfaces
{
    public interface IBookUserService
    {
        Task<bool> AddActualUserToBook(int bookId, int userId);

        Task<bool> RemoveActualUserFromBook(int bookId, int userId);

        Task<IEnumerable<Book>> FindBooksOfUser(int userId);
    }
}
