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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(LibraryApplicationDbContext context) : base(context) { }
    }
}
