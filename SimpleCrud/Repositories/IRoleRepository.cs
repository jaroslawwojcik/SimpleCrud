using SimpleCrud.Entities;
using SimpleCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrud.Repositories
{
    public interface IRoleRepository
    {
        IList<RoleModel> GetAll();
        void Add(AddRoleModel role);
        void Delete(long id);
        Role GetRole(long id);
    }
}
