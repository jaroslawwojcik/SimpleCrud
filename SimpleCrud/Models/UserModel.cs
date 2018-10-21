using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//14. dodajemy view model aby wyświetlać sformatowany entity
namespace SimpleCrud.Models
{
    public class UserModel
    {
        public long Id { get; set; }

        public string FullName { get; set; }
        public int Age { get; set; }
        public string IsActiveAsString { get; set; }
    }
}