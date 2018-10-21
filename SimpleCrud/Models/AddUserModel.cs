using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleCrud.Models
{//16. Dodajemy view model dla metody Add
    public class AddUserModel
    {
        public AddUserModel()
        {
            DateOfBirth = DateTime.Now;
        }

        [Required(ErrorMessage ="Pole imie musi być wypełnione")]
        [MinLength(3, ErrorMessage ="Imie musi mieć co najmniej 3 znaki")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Pole nazwisko musi być wypełnione")]
        [MinLength(3, ErrorMessage = "Nazwisko musi mieć co najmniej 3 znaki")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}