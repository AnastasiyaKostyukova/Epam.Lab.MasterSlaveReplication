using System;
using System.Collections.Generic;
using System.Linq;
using UserStorageService.Entities;
using UserStorageService.Interfaces;

namespace UserStorageService.ImplementationsOfStoring
{
    public class UserStorageServiceInMemory : IStorageService<User>
    {
        private readonly List<User> _listOfUsers;

        public UserStorageServiceInMemory(List<User> listOfUsers = null)
        {
            _listOfUsers = listOfUsers ?? new List<User>();
        }

        public int Add(User user)
        {
            _listOfUsers.Add(user);
            return user.Id;
        }

        public IEnumerable<User> GetAllUsers() => _listOfUsers;

        public void Delete(User user)
        {
            _listOfUsers.Remove(user);
        }

        public User GetUser(int id) => _listOfUsers.FirstOrDefault(r => r.Id == id);

        public IEnumerable<int> SearchUsers(params Func<User, bool>[] searchCollection)
        {
            var users = GetAllUsers();

            return searchCollection.Aggregate(users, (current, fun) => current.Where(fun)).Select(r => r.Id);
        }

        public IEnumerable<int> SearchUsersByFirstName(string userFName)
        {
            var users = GetAllUsers();
            return users.Where(r => r.FirstName == userFName).Select(r => r.Id);
        }

        public IEnumerable<int> SearchUsersByLastName(string userLName)
        {
            var users = GetAllUsers();
            return users.Where(r => r.FirstName == userLName).Select(r => r.Id);
        }
    }
}