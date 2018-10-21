using System;
// 2.Dodajemy klasę USer z jego właściwościami
//
//
namespace SimpleCrud.Entities
{
    public class User
    {   
        public long Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public bool IsActive { get; set; }
    }
}