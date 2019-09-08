using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubFinder.Models
{
    class Role
    {
        public int Id { get; set; }
        [Required]
        public string RoleName { get; set; }
        public IEnumerable<User> Users { get; set; }

    }
}
