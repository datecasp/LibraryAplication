using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApplication.Infrastructure.Helpers
{
    public class DbSeeder
    {//Create some values in database for testing and development 
        public static void Seed(ModelBuilder builder)
        {
            User user1 = new User()
            {
                Id = -1,
                UserName = "user1"
            };

            User user2 = new User()
            {
                Id = -2,
                UserName = "user2"
            };

            User user3 = new User()
            {
                Id = -3,
                UserName = "user3"
            };

            Book book1 = new Book()
            {
                Id = -1,
                Title = "tit1",
                Author = "aut1",
            };

            Book book2 = new Book()
            {
                Id = -2,
                Title = "tit2",
                Author = "aut2",
            };

            Book book3 = new Book()
            {
                Id = -3,
                Title = "tit3",
                Author = "aut3",
            };

            Book book4 = new Book()
            {
                Id = -4,
                Title = "tit4",
                Author = "aut4",
            };

            Book book5 = new Book()
            {
                Id = -5,
                Title = "tit5",
                Author = "aut5",
            };

            Book book6 = new Book()
            {
                Id = -6,
                Title = "tit6",
                Author = "aut6",
            };

            Category cat1 = new Category()
            {
                Id = -1,
                CategoryName = "Cat1"
            };

            Category cat2 = new Category()
            {
                Id = -2,
                CategoryName = "Cat2"
            };

            Category cat3 = new Category()
            {
                Id = -3,
                CategoryName = "Cat3"
            };

            Category cat4 = new Category()
            {
                Id = -4,
                CategoryName = "Cat4"
            };

            BookUser bu1 = new BookUser()
            {
                Id = -1,
                BookId = -1,
                UserId = -1,
                ActualUser = true
            };

            BookUser bu2 = new BookUser()
            {
                Id = -2,
                BookId = -1,
                UserId = -2,
                ActualUser = false
            };

            BookUser bu3 = new BookUser()
            {
                Id = -3,
                BookId = -2,
                UserId = -2,
                ActualUser = true
            };

            BookUser bu4 = new BookUser()
            {
                Id = -4,
                BookId = -4,
                UserId = -2,
                ActualUser = true
            };

            BookUser bu5 = new BookUser()
            {
                Id = -5,
                BookId = -5,
                UserId = -2,
                ActualUser = true
            };

            BookCategory bc1 = new BookCategory()
            {
                Id = -1,
                BookId = -1,
                CategoryId = -1
            };

            BookCategory bc2 = new BookCategory()
            {
                Id = -2,
                BookId = -1,
                CategoryId = -2
            };

            BookCategory bc3 = new BookCategory()
            {
                Id = -3,
                BookId = -2,
                CategoryId = -3
            };

            BookCategory bc4 = new BookCategory()
            {
                Id = -4,
                BookId = -3,
                CategoryId = -3
            };

            BookCategory bc5 = new BookCategory()
            {
                Id = -5,
                BookId = -3,
                CategoryId = -4
            };

            BookCategory bc6 = new BookCategory()
            {
                Id = -6,
                BookId = -4,
                CategoryId = -4
            };

            BookCategory bc7 = new BookCategory()
            {
                Id = -7,
                BookId = -5,
                CategoryId = -2
            };

            BookCategory bc8 = new BookCategory()
            {
                Id = -8,
                BookId = -6,
                CategoryId = -1
            };

            builder.Entity<User>().HasData(user1, user2, user3);
            builder.Entity<Book>().HasData(book1, book2, book3, book4, book5, book6);
            builder.Entity<Category>().HasData(cat1, cat2, cat3, cat4);
            builder.Entity<BookUser>().HasData(bu1, bu2, bu3, bu4, bu5);
            builder.Entity<BookCategory>().HasData(bc1, bc2, bc3, bc4, bc5, bc6, bc7, bc8);
        }
    }
}
