using SimpleCrud.Entities;
using SimpleCrud.Models;
using System.Collections.Generic;
//3. Dodajemy interfejs IPersonsRepository i metody które będą używane w kontrolerze
namespace SimpleCrud.Repositories
{//Przy dodawaniu view model musimy ustawić parametry na Modele
    public interface IPersonsRepository
    {
        IList<UserModel> GetAllUsers();
        EditUserModel GetUser(long id);

        void Add(AddUserModel user);
        void Update(EditUserModel user);
        void Delete(long id);
    }
}