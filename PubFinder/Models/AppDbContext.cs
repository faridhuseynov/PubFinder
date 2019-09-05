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

       
        public DbSet<User> Users { get; set; }
        public DbSet<IdentityRole> IdentityRoles { get; set; }
        public DbSet<Pub> Pubs { get; set; }
        public DbSet<FavoritePub> FavoritePubs { get; set; }
        public DbSet<BeerSet> BeerSets { get; set; }
        public DbSet<SetItem> SetItems { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Comment> Comments { get; set; }

        
        //public DbSet<Event> Events { get; set; }
        //public DbSet<Comment> Comments { get; set; }

    }
}
