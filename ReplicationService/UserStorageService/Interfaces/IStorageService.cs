using System;
using System.Collections.Generic;
using UserStorageService.Entities;

namespace UserStorageService.Interfaces
{
    public interface IStorageService<T>
    {
        int Add(T user);
        void Delete(T user);
        T GetUser(int id);
        IEnumerable<T> GetAllUsers();
        IEnumerable<int> SearchUsers(params Func<User, bool>[] func);
        IEnumerable<int> SearchUsersByFirstName(string userFName);
        IEnumerable<int> SearchUsersByLastName(string userLName);
    }
}
