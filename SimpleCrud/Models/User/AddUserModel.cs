using SimpleCrud.Entities;
using SimpleCrud.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleCrud.Models
{//16. Dodajemy view model dla metody Add
    public class AddUserModel
    {
        private readonly IRoleRepository _roleRepository = new RoleRepository();

        public AddUserModel()
        {
            DateOfBirth = DateTime.Now;
            RoleModelsList = _roleRepository.GetAll();
        }

        [Required(ErrorMessage ="Pole imie musi być wypełnione")]
        [MinLength(3, ErrorMessage ="Imie musi mieć co najmniej 3 znaki")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Pole nazwisko musi być wypełnione")]
        [MinLength(3, ErrorMessage = "Nazwisko musi mieć co najmniej 3 znaki")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public IList<RoleModel> RoleModelsList { get; set; }
        public SimpleCrud.Entities.Role Role { get; set; }
        public long RoleId { get; set; }
    }
}