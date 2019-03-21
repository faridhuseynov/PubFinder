using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubFinder.Models
{
    class AppDbContext:DbContext
    {
        public AppDbContext():base("AppConnection")
        {

        }

    }
}
