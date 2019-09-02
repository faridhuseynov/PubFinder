﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubFinder.Models
{
    class MenuItem
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}