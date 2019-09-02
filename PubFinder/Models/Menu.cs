﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubFinder.Models
{
    class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<MenuItem> MenuItems { get; set; }
        public int Price { get; set; }
        public double Rank { get; set; }
        public int PubId { get; set; }
        public Pub Pub { get; set; }
    }
}
