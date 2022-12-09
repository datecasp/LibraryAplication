using LibraryApplication.Domain.Models;

namespace LibraryApplication.Domain.Interfaces
{
    public interface ICategoryService 
    {
        Task<ICollection<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<Category> Add(Category category);
        Task<Category> Update(Category category);
        Task<bool> Remove(Category category);
    }
}
