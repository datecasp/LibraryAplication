﻿using LibraryApplication.Domain.Interfaces;
using LibraryApplication.Domain.Services;
using LibraryApplication.Infrastructure.Context;
using LibraryApplication.Infrastructure.Repositories;

namespace LibraryApplication.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<LibraryApplicationDbContext>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookCategoryRepository, BookCategoryRepository>();
            services.AddScoped<IBookUserRepository, BookUserRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookCategoryService, BookCategoryService>();
            services.AddScoped<IBookUserService, BookUserService>();

            return services;
        }
    }
}
