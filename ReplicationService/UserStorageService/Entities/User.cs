using System;

namespace UserStorageService.Entities
{
    public enum Gender
    {
        Male,
        Famale
    }

    public class User
    {
        public int Id { get; internal set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Visa[] Visa { get; set; }
        public Gender Sex { get; set; }
    }
}
