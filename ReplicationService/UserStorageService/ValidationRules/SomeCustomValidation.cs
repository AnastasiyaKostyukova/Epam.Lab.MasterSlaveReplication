using System.Collections.Generic;
using UserStorageService.Entities;
using UserStorageService.HelperModels;

namespace UserStorageService.ValidationRules
{
    internal class CustomUserValidator : BaseValidation
    {
        public override ValidationModel Validate(List<User> users, User user)
        {
            // base (default)
            var baseValidationModel = base.Validate(users, user);

            if (baseValidationModel.IsInvalidUser)
            {
                return baseValidationModel;
            }
            
            // custom validation
            if (user.FirstName.Length > 25 && user.LastName.Length > 25)
            {
                return new ValidationModel {IsInvalidUser = true, ErrorMessage = "user name should be less then 25 symbols"};
            }

            return new ValidationModel();
        }
    }
}
