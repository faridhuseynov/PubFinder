using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubFinder.Models
{
    class User
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surame { get; set; }

        public string PhotoLink { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //public IEnumerable<Trip> Trips { get; set; }

        public string SaltValue { get; set; }
        public string HashValue { get; set; }

        //this will be set later
        //public string Error => throw new NotImplementedException();
        //public string this[string columnName] => this.Validate(columnName);
    }
}
