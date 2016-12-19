using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using UserStorageService.Entities;
using UserStorageService.ImplementationsOfStoring;

namespace MasterSlaveReplicationOverTcp
{
    public class Master
    {

        private readonly UserStorageService.UserStorageService userService;
        private readonly int[] ports;

        public Master(int[] ports)
        {
            this.ports = ports;
            this.userService = new UserStorageService.UserStorageService(new UserStorageServiceInMemory());
        }

        public int Add(User user)
        {
            var addedUserId = this.userService.Add(user);

            if (addedUserId != 0)
            {
                SendMessage(new Message(user, Operation.Add));
            }

            return addedUserId;
        }

        public void Delete(User user)
        {
            this.userService.Delete(user);
            SendMessage(new Message(user, Operation.Delete));
        }
        public IEnumerable<User> GetAllUsers() => this.userService.GetAllUsers();

        public User GetUser(int id) => this.userService.GetUser(id);

        public IEnumerable<int> SearchUsersByFirstName(string userFName)
            => this.userService.SearchUsersByFirstName(userFName);

        public IEnumerable<int> SearchUsersByLastName(string userLName)
            => this.userService.SearchUsersByLastName(userLName);



        private void SendMessage(Message message)
        {
            var bf = new BinaryFormatter();
            // Create a TcpClient.
            // Note, for this client to work you need to have a TcpServer 
            // connected to the same address as specified by the server, port
            // combination.
            for (int i = 0; i < ports.Length; i++)
            {
                using (TcpClient client = new TcpClient("127.0.0.1", ports[i]))
                {
                    using (NetworkStream stream = client.GetStream())
                    {
                        bf.Serialize(stream, message);
                    }
                }
            }
        }
    }
}
