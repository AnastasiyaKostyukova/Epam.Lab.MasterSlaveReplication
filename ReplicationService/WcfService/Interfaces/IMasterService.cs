using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using UserStorageService.Entities;
using WcfService.CompositeTypes;

namespace WcfService.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IMasterService
    {
        // TODO: Add your service operations here

        [OperationContract]
        int Add(UserCompositeType user);

        [OperationContract]
        void Delete(UserCompositeType user);

        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        IEnumerable<User> GetAllUsers();

        [OperationContract]
        IEnumerable<int> SearchUsersByFirstName(string firstName);

        [OperationContract]
        IEnumerable<int> SearchUsersByLastName(string user);


        //[OperationContract]
        //IList<User> SearchByLastAndFirstName(UserCompositeType user);

        //IEnumerable<int> SearchUsers(params Func<User, bool>[] func);

        //[OperationContract]
        //bool Update(UserCompositeType user);
    }
}
