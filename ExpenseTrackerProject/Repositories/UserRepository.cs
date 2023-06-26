using ExpenseTrackerProject.Models;
using ExpenseTrackerProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerProject.Repositories
{


    public class UserRepository : IUserRepository
    {
        private readonly ExpenseTrackerDbContext _context;

        public UserRepository(ExpenseTrackerDbContext context)
        {
            _context = context;
        }



        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
