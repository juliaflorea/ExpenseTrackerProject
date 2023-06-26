using ExpenseTrackerProject.Models;
using ExpenseTrackerProject.Repositories.Interfaces;
using ExpenseTrackerProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerProject.Services
{

    class CategoryService : ICategoryService
    {
        private readonly IRepositoryWrapper _repository;
        public CategoryService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public CategoryService()
        {
        }

        public Category GetCategoryById(int id)
        {
            return _repository.Category.GetCategoryById(id);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _repository.Category.GetAllCategories();
        }

        public void AddCategory(Category category)
        {
            _repository.Category.AddCategory(category);
            _repository.Save();
        }

        public void UpdateCategory(Category category)
        {
            _repository.Category.UpdateCategory(category);
            _repository.Save();
        }

        public void DeleteCategory(int id)
        {
            var category = _repository.Category.GetCategoryById(id);
            _repository.Category.DeleteCategory(id);
            _repository.Save();
        }

        public void Save()
        {
            _repository.Save();
        }
    }
}
