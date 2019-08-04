using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubFinder.Models
{
    class Pub
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNum { get; set; }

        public string LogoLink { get; set; }

        //this caused error, therefore better to create separate database comments
        //with UserId and PubId
        //public int UserId { get; set; }
        //public User User { get; set; }

        public string SaltValue { get; set; }
        public string HashValue { get; set; }
        public IEnumerable<BeerSet> BeerSets { get; set; }
        //public IEnumerable<Ranking> Rankings { get; set; }

        //public IEnumerable<Menu> Menus { get; set; }

        //public IEnumerable<Comment> Comments { get; set; }

    }
}
