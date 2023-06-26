using ExpenseTrackerProject.Models;
using ExpenseTrackerProject.Repositories.Interfaces;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;

namespace ExpenseTrackerProject.Services.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers(); 
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        void Save();
    }

}







