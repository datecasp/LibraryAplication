using LibraryApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Domain.Interfaces
{
    public interface IBookService
    {
        Task<ICollection<Book>> GetAll();
        Task<Book> GetById(int id);
        Task<Book> Add(Book book);
        Task<Book> Update(Book book);
        Task<bool> Remove(Book book);
       
    }
}
