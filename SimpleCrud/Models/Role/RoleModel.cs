using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleCrud.Models
{
    public class RoleModel
    {
        public long Id { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}