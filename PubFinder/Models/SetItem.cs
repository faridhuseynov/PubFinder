using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubFinder.Models
{
    class SetItem
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public int BeerSetId { get; set; }
        public BeerSet BeerSet { get; set; }
    }
}
