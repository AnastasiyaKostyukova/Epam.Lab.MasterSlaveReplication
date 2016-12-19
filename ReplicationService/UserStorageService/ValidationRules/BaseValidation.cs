using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserStorageService.Entities;
using UserStorageService.HelperModels;
using UserStorageService.Interfaces;

namespace UserStorageService.ValidationRules
{
    public class BaseValidation: IUserValidator
    {
        public virtual ValidationModel Validate(List<User> users, User user)
        {
            if (user == null)
            {
                return new ValidationModel
                {
                    IsInvalidUser = true,
                    ErrorMessage = "User is null"
                };
            }

            var message = new StringBuilder();
            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
            {
                message.Append("user firstname and lastname should be not empty; ");
            }

            if (user.DateOfBirth == null)
            {
                message.Append("date Of birth should be not empty; ");
            }

            if (user.DateOfBirth >= DateTime.Now)
            {
                message.Append("date of birth should be in the past; ");
            }

            if (IsUserAlreadyExists(users, user))
            {
                message.Append("in addition, this user already exists; ");
            }

            if (string.IsNullOrEmpty(message.ToString()))
            {
                return new ValidationModel();
            }

            return new ValidationModel
                {
                    IsInvalidUser = true,
                    ErrorMessage = message.ToString()
                };
        }
        private bool IsUserAlreadyExists(List<User> users, User user)
        {
            var userExist = users.Any(r => r.FirstName.Equals(user.FirstName, StringComparison.OrdinalIgnoreCase)
                                             && r.LastName.Equals(user.LastName, StringComparison.OrdinalIgnoreCase)
                                             && r.DateOfBirth == user.DateOfBirth);

            return userExist;
        }
    }
}
