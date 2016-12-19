using System;

namespace UserStorageService.Custom_Exceptions
{
    public class UserCreateException : Exception
    {
        private const string DEFAULT_MESSAGE = "Create of user error";

        public UserCreateException() : base(DEFAULT_MESSAGE)
        {
        }

        public UserCreateException(string message) : base(message)
        {
        }
    }
}