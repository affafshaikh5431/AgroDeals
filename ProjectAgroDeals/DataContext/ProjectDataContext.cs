using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjectAgroDeals.Models;

namespace ProjectAgroDeals.DataContext
{
    public class ProjectDataContext:DbContext
    {
        public ProjectDataContext():base("MyCon")
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Units> Units { get; set; }

        public DbSet<Cart> Cart { get; set; }

        public DbSet<Message> Message { get; set; }

    }
}