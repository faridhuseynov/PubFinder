using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubFinder.Models
{
    class BeerSet
    {
        public int Id { get; set; }
        public IEnumerable<SetItem> SetItems { get; set; }
        public int Price { get; set; }
        public double Rank { get; set; }
    }
}
