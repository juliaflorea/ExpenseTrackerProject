using ExpenseTrackerProject.Models;
using Microsoft.CodeAnalysis;

namespace ExpenseTrackerProject.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Category GetCategoryById(int id);
        IEnumerable<Category> GetAllCategories();
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
        void Save();
    }
    
}
