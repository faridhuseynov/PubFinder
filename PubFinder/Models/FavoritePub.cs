using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubFinder.Models
{
    class FavoritePub
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PubId { get; set; }
        public Pub Pub { get; set; }
    }
}
