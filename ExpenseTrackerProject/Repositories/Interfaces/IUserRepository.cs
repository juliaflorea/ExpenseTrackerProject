﻿using ExpenseTrackerProject.Models;

namespace ExpenseTrackerProject.Repositories.Interfaces
{
    public interface IUserRepository
    {
       
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        void Save();

       
    }
}
