using LibraryApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Domain.Interfaces
{
    public interface IBookCategoryService
    {
        Task<bool> AddCategoryToBook(int bookId, int categoryId);

        Task<bool> DeleteCategoryFromBook(int bookId, int categoryId);

    }
}
