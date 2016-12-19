using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using UserStorageService.Entities;

namespace WcfService.CompositeTypes
{
    // Use a data contract as illustrated in the sample below to add composite types to service 
    //operations.
    // You can add XSD files into the project. After building the project, you can directly use 
    //the data types defined there, with the namespace "WcfService.ContractType".

    [DataContract]
    public class UserCompositeType
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public DateTime DateOfBirth { get; set; }

        [DataMember]
        public VisaCompositeType UserVisa { get; set; }

        [DataMember]
        public Gender UserGender { get; set; }
    }
}
