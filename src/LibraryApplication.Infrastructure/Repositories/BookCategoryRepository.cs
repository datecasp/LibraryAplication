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
    public class BookCategoryRepository : Repository<BookCategory>, IBookCategoryRepository
    {
        public BookCategoryRepository(LibraryApplicationDbContext context) : base(context) { }


        public async Task<BookCategory> AddCategoryToBook(BookCategory bc)
        {
            await Db.AddAsync(bc);
            Db.SaveChanges();
            return bc;
            
        }

        public Task DeleteCategoryFromBook(BookCategory bc)
        {
            Db.Remove(bc);
            Db.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<ICollection<int>> GetBooksIdWithCategory(int catId) 
        {
            var booksWithCategoryList = Search(bc => bc.CategoryId == catId).Result;
            List<int> result = new List<int>();
            foreach (var bc in booksWithCategoryList)
            {
                result.Add(bc.BookId);
            }

            return result;
        }
    }
}