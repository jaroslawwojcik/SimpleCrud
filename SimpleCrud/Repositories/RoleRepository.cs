using SimpleCrud.Entities;
using SimpleCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCrud.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly static IList<Role> _roles = new List<Role>()
        {
            new Role()
            {
                Id = 1,
                RoleName = "Administrator"
            },

            new Role()
            {
                Id = 2,
                RoleName = "SuperUser"
            }
        };

        public void Add(AddRoleModel roleModel)
        {
            var role = new Role
            {
                Id = GenerateKey(),
                RoleName = roleModel.RoleName
            };

            _roles.Add(role);
        }

        public void Delete(long id)
        {
            var roleToDelete = _roles.Single(r => r.Id == id);
            _roles.Remove(roleToDelete);
        }

        public IList<RoleModel> GetAll()
        {
            return _roles.Select(r => new RoleModel
            {
                Id = r.Id,
                RoleName = r.RoleName
            })
            .ToList();
        }

        public Role GetRole(long id)
        {
            return _roles.Single(x => x.Id == id);
        }

        private long GenerateKey()
        {
            return _roles.Max(x => x.Id) + 1;
        }
    }
}