﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubFinder.Models
{
    class Comment
    {
        public int Id { get; set; }
        public string Feedback { get; set; }
        //public int Weight { get; set; }
        public int PubId { get; set; }
        public Pub Pub { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
