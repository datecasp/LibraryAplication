﻿using LibraryApplication.Domain.Models;
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
        User Add(User user);
        Task<bool> Update(User user);
        Task<bool> Remove(User user);
    }
}
