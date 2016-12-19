using System;

namespace UserStorageService.Entities
{
    public class Visa
    {
        public string Country { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}