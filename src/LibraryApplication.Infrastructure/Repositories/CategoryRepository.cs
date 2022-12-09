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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(LibraryApplicationDbContext context) : base(context) { }
    }
}
