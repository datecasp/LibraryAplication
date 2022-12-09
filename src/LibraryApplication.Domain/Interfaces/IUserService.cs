using LibraryApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Domain.Interfaces
{
    public interface IUserService
    {
        Task<ICollection<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Add(User user);
        Task<User> Update(User user);
        Task<bool> Remove(User user);
    }
}
