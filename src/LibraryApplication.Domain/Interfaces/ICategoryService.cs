using LibraryApplication.Domain.Models;

namespace LibraryApplication.Domain.Interfaces
{
    public interface ICategoryService 
    {
        Task<ICollection<Category>> GetAll();
        Task<Category> GetById(int id);
        Category Add(Category category);
        Task<bool> Update(Category category);
        Task<bool> Remove(Category category);
    }
}
