using AutoMapper;
using LibraryApplication.API.Dtos.Book;
using LibraryApplication.API.Dtos.BookCategory;
using LibraryApplication.API.Dtos.BookUser;
using LibraryApplication.API.Dtos.Category;
using LibraryApplication.API.Dtos.User;
using LibraryApplication.Domain.Models;

namespace LibraryApplication.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Category, CategoryAddDto>().ReverseMap();
            CreateMap<Category, CategoryEditDto>().ReverseMap();
            CreateMap<Category, CategoryResultDto>().ReverseMap();
            CreateMap<Book, BookAddDto>().ReverseMap();
            CreateMap<Book, BookEditDto>().ReverseMap();
            CreateMap<Book, BookResultDto>().ReverseMap();
            CreateMap<User, UserAddDto>().ReverseMap();
            CreateMap<User, UserEditDto>().ReverseMap();
            CreateMap<User, UserResultDto>().ReverseMap();
            CreateMap<BookCategory, BookCategoryDto>().ReverseMap();
            CreateMap<BookUser, BookUserDto>().ReverseMap();
        }
    }
}
