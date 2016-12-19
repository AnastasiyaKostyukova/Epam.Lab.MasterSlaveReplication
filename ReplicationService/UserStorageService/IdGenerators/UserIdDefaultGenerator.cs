using System.Collections.Generic;
using System.Linq;
using UserStorageService.Entities;

namespace UserStorageService.IdGenerators
{
    public class UserIdDefaultGenerator
    {
        public static int GenerateDefaultId(List<User> users)
        {
            var lastUser = users.LastOrDefault();

            if (lastUser == null)
            {
                return 1;
            }

            var newUserId = lastUser.Id + 1;
            return newUserId;
        }
    }
}
