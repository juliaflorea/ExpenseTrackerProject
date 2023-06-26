using ExpenseTrackerProject.Models;

namespace ExpenseTrackerProject.Services.Interfaces
{
    public interface ICategoryService
    {
        Category GetCategoryById(int id);
        IEnumerable<Category> GetAllCategories();
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
        void Save();
    }
}
