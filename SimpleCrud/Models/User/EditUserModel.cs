using SimpleCrud.Entities;
using SimpleCrud.Models.Role;
using SimpleCrud.Repositories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleCrud.Models
{
    public class EditUserModel
    {
        private readonly IRoleRepository _roleRepository = new RoleRepository();

        public EditUserModel()
        {
            RoleModelsList = _roleRepository.GetAll();
        }

        public long Id { get; set; }
        [Required(ErrorMessage = "Pole imie musi być wypełnione")]
        [MinLength(3, ErrorMessage = "Imie musi mieć co najmniej 3 znaki")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Pole nazwisko musi być wypełnione")]
        [MinLength(3, ErrorMessage = "Nazwisko musi mieć co najmniej 3 znaki")]
        public string LastName { get; set; }
        public IList<RoleModel> RoleModelsList { get; set; }
        public SimpleCrud.Entities.Role Role { get; set; }
        public long RoleId { get; set; }
        public bool IsActive { get; set; }

    }
}