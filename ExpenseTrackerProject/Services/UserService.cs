using ExpenseTrackerProject.Models;
using ExpenseTrackerProject.Repositories.Interfaces;
using ExpenseTrackerProject.Services.Interfaces;

namespace ExpenseTrackerProject.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repository;
        public UserService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public UserService()
        {
        }

        public User GetUserById(int id)
        {
            return _repository.User.GetUserById(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _repository.User.GetAllUsers();
        }

        public void AddUser(User user)
        {
            _repository.User.AddUser(user);
            _repository.Save();
        }

        public void UpdateUser(User user)
        {
            _repository.User.UpdateUser(user);
            _repository.Save();
        }

        public void DeleteUser(int id)
        {
            var user = _repository.User.GetUserById(id);
            _repository.User.DeleteUser(id);
            _repository.Save();
        }

        public void Save()
        {
            _repository.Save();
        }

    }
}