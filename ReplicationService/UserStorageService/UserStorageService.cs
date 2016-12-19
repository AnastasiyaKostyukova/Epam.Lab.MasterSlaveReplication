using System;
using System.Collections.Generic;
using System.Linq;
using UserStorageService.Custom_Exceptions;
using UserStorageService.Entities;
using UserStorageService.IdGenerators;
using UserStorageService.ImplementationsOfStoring;
using UserStorageService.Interfaces;
using UserStorageService.ValidationRules;

namespace UserStorageService
{
    public class UserStorageService
    {
        private readonly IStorageService<User> _userStorageService;
        private readonly Func<List<User>, int> _idGeneratorFunction;
        
        public UserStorageService(IStorageService<User> storageService) : this(storageService, null)
        {
        }

        public UserStorageService(IStorageService<User> storageService, Func<List<User>, int> idGeneratorFunction)
        {
            _userStorageService = storageService;
            _idGeneratorFunction = idGeneratorFunction ?? UserIdDefaultGenerator.GenerateDefaultId;
        }

        public int Add(User user, IUserValidator userValidator = null)
        {
            if (userValidator == null)
            {
                userValidator = new BaseValidation();
            }

            var listOfUsers = _userStorageService.GetAllUsers().ToList();
            var validationResult = userValidator.Validate(listOfUsers, user);

            if (validationResult.IsInvalidUser)
            {
                throw new UserCreateException(validationResult.ErrorMessage);
            }

            user.Id = _idGeneratorFunction(listOfUsers);
            _userStorageService.Add(user);

            return user.Id;
        }

        public IEnumerable<User> GetAllUsers() => _userStorageService.GetAllUsers();

        public User GetUser(int id) => _userStorageService.GetUser(id);

        public IEnumerable<int> SearchUsers(params Func<User, bool>[] searchCollection)
            => _userStorageService.SearchUsers(searchCollection);

        public void Delete(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            _userStorageService.Delete(user);
        }

        public IEnumerable<int> SearchUsersByFirstName(string firstName)
        {
            if (firstName == null)
            {
                throw new ArgumentNullException();
            }

            return _userStorageService.SearchUsersByFirstName(firstName);
        }

        public IEnumerable<int> SearchUsersByLastName(string lastName)
        {
            if (lastName == null)
            {
                throw new ArgumentNullException();
            }

            return _userStorageService.SearchUsersByLastName(lastName);
        }

        public IEnumerable<int> SearchByLastAndFirstName(string firstName, string lastName)
        {
            if (firstName == null || lastName == null)
            {
                throw new ArgumentNullException();
            }

            return _userStorageService.SearchUsers(r => r.LastName == lastName, r => r.FirstName == firstName);
        }

        public IEnumerable<int> SearchByDateOfBirth(DateTime dateOfBirth)
        {
            if (dateOfBirth == null)
            {
                throw new ArgumentNullException();
            }

            return _userStorageService.SearchUsers(r => r.DateOfBirth == dateOfBirth);
        }
    }
}
