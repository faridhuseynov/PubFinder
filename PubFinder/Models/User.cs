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
        public string Surname { get; set; }

        public string PhotoLink { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public IEnumerable<IdentityRole> IdentityRoles { get; set; }

        public IEnumerable<Pub> Pubs { get; set; }
        public IEnumerable<Comment> Comments { get; set; }

        public string SaltValue { get; set; }
        public string HashValue { get; set; }

        //this will be set later
        //public string Error => throw new NotImplementedException();
        //public string this[string columnName] => this.Validate(columnName);

        public User()
        {
            Name = null;
            Surname = null;
            UserName = null;
            SaltValue = null;
            HashValue = null;
            PhotoLink = null;
            Email = null;
        }

        public User(User user)
        {
            if (user!=null)
            {
            Name = user.Name;
            Surname = user.Surname;
            UserName = user.UserName;
            SaltValue = user.SaltValue;
            HashValue = user.HashValue;
            PhotoLink = user.PhotoLink;
            Email = user.Email;
            Id = user.Id;

            }
            //User newUser = new User();
            //newUser=user;
        }
    }
}
