using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStorageService.Entities;

namespace MasterSlaveReplicationOverTcp
{
    public enum Operation { Add, Delete, Update }

    [Serializable]
    public class Message
    {
        public Operation Operation { get; }
        public User User { get; }

        public Message(User user, Operation operation)
        {
            this.User = user;
            this.Operation = operation;
        }
    }
}
