using ExpenseTrackerProject.Models;
using ExpenseTrackerProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerProject.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ExpenseTrackerDbContext _context;

        public object Category => throw new NotImplementedException();

        public CategoryRepository(ExpenseTrackerDbContext context)
        {
            _context = context;
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories
                .Include(c => c.Expenses)
                .Include(c => c.Budgets)
                .FirstOrDefault(c => c.CategoryId == id);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories
                .Include(c => c.Expenses)
                .Include(c => c.Budgets)
                .ToList();
        }

        public void AddCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = GetCategoryById(id);

            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
