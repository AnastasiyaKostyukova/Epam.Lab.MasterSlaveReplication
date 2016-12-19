using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UserStorageService.Entities;
using WcfService.CompositeTypes;

namespace WcfService.Interfaces
{
    public interface ISlaveService
    {
        [OperationContract]
        IEnumerable<User> SearchUsersByFirstName(string firstName);

        [OperationContract]
        IEnumerable<User> SearchUsersByLastName(UserCompositeType user);
    }
}
