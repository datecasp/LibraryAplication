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
        Task AddActualUserToBook(int bookId, int userId);

        Task RemoveActualUserFromBook(int bookId, int userId);
    }
}
