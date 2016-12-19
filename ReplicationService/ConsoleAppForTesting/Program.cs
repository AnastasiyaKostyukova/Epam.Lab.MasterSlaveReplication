using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStorageService;
using UserStorageService.Entities;
using UserStorageService.IdGenerators;
using UserStorageService.ImplementationsOfStoring;

namespace ConsoleAppForTesting
{
    public class Program
    {
        static void Main(string[] args)
        {
            var servInMem = new UserStorageServiceInMemory();
            var service1 = new UserStorageService.UserStorageService(servInMem);
            service1.Add(new User
            {
                FirstName = "s",
                LastName = "d",
                DateOfBirth = new DateTime(1991, 11, 5),
                Sex = Gender.Male
            });

            service1.Add(new User { FirstName = "1regrg", LastName = "11egerg", DateOfBirth = new DateTime(1991, 11, 5) });
            service1.Add(new User { FirstName = "2eghrh", LastName = "22geeg", DateOfBirth = new DateTime(1991, 8, 5) });
            service1.Add(new User { FirstName = "3ehrher", LastName = "33egrg", DateOfBirth = new DateTime(1991, 10, 5) });

            Console.WriteLine("Test1");
            foreach (var user in service1.GetAllUsers())
            {
                Console.WriteLine(user.Id + " " + user.FirstName);
            }

            var idGenerator = new UserIdArithmProgressionGenerator(5);
            var service2 = new UserStorageService.UserStorageService(servInMem, idGenerator.GenerateIdAsArithmeticProgression);
            
            service2.Add(new User { FirstName = "4grhd", LastName = "11th", DateOfBirth = new DateTime(1991, 11, 5) });
            service2.Add(new User { FirstName = "5hdth", LastName = "22tht", DateOfBirth = new DateTime(1991, 8, 5) });
            service2.Add(new User { FirstName = "6fhfh", LastName = "33tht", DateOfBirth = new DateTime(1991, 10, 5) });

            //var a = service.GetUsersByPredicate(r => r.FirstName == "A0");
            //foreach (var user in a)
            //{
            //    Console.WriteLine(user.LastName);
            //}

            Console.WriteLine("\n\nTest2");
            foreach (var user in service2.GetAllUsers())
            {
                Console.WriteLine(user.Id + " " + user.FirstName);
            }

            //var us = service.GetUser(1);
            //Console.WriteLine(us.FirstName);
        }
    }
}
