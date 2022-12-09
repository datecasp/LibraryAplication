using LibraryApplication.Domain.Interfaces;
using LibraryApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ICollection<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category> GetById(int id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task<Category> Add(Category category)
        {
            if (_categoryRepository.Search(c => c.CategoryName == category.CategoryName).Result.Any())
                return null;

            await _categoryRepository.Add(category);
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            if (_categoryRepository.Search(c => c.CategoryName == category.CategoryName && c.Id != category.Id).Result.Any())
                return null;

            await _categoryRepository.Update(category);
            return category;
        }

        public async Task<bool> Remove(Category category)
        {
            await _categoryRepository.Remove(category);
            return true;
        }
        
        public void Dispose()
        {
            _categoryRepository?.Dispose();
        }
    }
}
