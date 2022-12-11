using LibraryApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Domain.Interfaces
{
    public interface IBookCategoryRepository : IRepository<BookCategory>
    {
        Task<BookCategory> AddCategoryToBook(BookCategory bc);

        Task DeleteCategoryFromBook(BookCategory bc);

    }
}
