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
                
        public string PhoneNum { get; set; }

        public IEnumerable<Ranking> Rankings { get; set; }

        public IEnumerable<Menu> Menus { get; set; }



    }
}
