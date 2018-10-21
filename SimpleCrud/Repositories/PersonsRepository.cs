using SimpleCrud.Entities;
using SimpleCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;

//5. Tworzymy klasę i implementujemy interfejs i jego metody
namespace SimpleCrud.Repositories
{
    public class PersonsRepository : IPersonsRepository
    {
        private readonly static IRoleRepository _roleRepository = new RoleRepository();
        private readonly static IList<User> _users = new List<User>()
        {

            //6. Tworzymy userów testowych
            new User()
            {
                Id = 1,
                FirstName = "Jarek",
                LastName = "Wójcik",
                DateOfBirth = new DateTime(1990,12,17),
                Role = new Role
                {
                    Id = 1,
                    RoleName = "Administrator"
                }
            },

            new User()
            {
                Id = 2,
                FirstName = "Maciej",
                LastName = "Makota",
                DateOfBirth = new DateTime(1994,5,12),
                Role = new Role
                {
                    Id = 1,
                    RoleName = "Administrator"
                }
            }
        };

        //mapujemy usermodel na usera i dodajemy do listy
        public void Add(AddUserModel userModel)
        {
            var user = new User
            {
                Id = GenerateKey(),
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                DateOfBirth = userModel.DateOfBirth,
                Role = _roleRepository.GetRole(userModel.RoleId),

                IsActive = true
            };

            _users.Add(user);
        }

        //mapujemy usera na usermodel
        public IList<UserModel> GetAllUsers()
        {//15. Tworzymy liste zwracającą userModel
            return _users.Select(u => new UserModel {
                Id = u.Id,

                FullName = string.Format("{0} {1}",u.FirstName, u.LastName),
                Age = DateTime.Now.Year - u.DateOfBirth.Year,
                Role = u.Role,
                IsActiveAsString = u.IsActive ? "TAK" : "NIE"
                
            })
            .ToList();
        }

        public EditUserModel GetUser(long id)
        {
            return _users.Select(u => new EditUserModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Role = u.Role,
                IsActive = u.IsActive,
                
            })
            .SingleOrDefault(u => u.Id == id);
        }

        public void Update(EditUserModel model)
        {
            var originalUser = _users.Single(x => x.Id == model.Id);
            
            originalUser.FirstName = model.FirstName;
            originalUser.LastName = model.LastName;
            originalUser.Role = _roleRepository.GetRole(model.RoleId);
            originalUser.IsActive = model.IsActive;
        }

        private long GenerateKey()
        {
            return _users.Max(x => x.Id) + 1;
        }

        public void Delete(long id)
        {
            var userToDelete = _users.Single(u => u.Id == id);
            _users.Remove(userToDelete);
        }
    }
}