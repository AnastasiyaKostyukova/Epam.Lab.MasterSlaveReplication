using System.Collections.Generic;
using UserStorageService.Entities;
using UserStorageService.HelperModels;

namespace UserStorageService.Interfaces
{
    public interface IUserValidator
    {
        ValidationModel Validate(List<User> users, User user);
    }
}
