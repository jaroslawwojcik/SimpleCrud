using System.ComponentModel.DataAnnotations;

namespace SimpleCrud.Models
{
    public class EditUserModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Pole imie musi być wypełnione")]
        [MinLength(3, ErrorMessage = "Imie musi mieć co najmniej 3 znaki")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Pole nazwisko musi być wypełnione")]
        [MinLength(3, ErrorMessage = "Nazwisko musi mieć co najmniej 3 znaki")]
        public string LastName { get; set; }

        public bool IsActive { get; set; }
    }
}