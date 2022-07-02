using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCarSell.DataAccess.Entities;

namespace WebCarSell.DataAccess.Context
{
    public class ApplicationContext :DbContext
    {
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car_body> car_Bodies { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options)
        {
        }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

    }
}
