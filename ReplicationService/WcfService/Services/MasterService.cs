using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStorageService.Entities;
using WcfService.CompositeTypes;
using WcfService.Interfaces;

namespace WcfService.Services
{
    public class MasterService : IMasterService
    {
        public int Add(UserCompositeType user)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserCompositeType user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> SearchUsersByFirstName(string firstName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> SearchUsersByLastName(string lastName)
        {
            throw new NotImplementedException();
        }
    }
}
