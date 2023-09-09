using Microsoft.EntityFrameworkCore;
using StadiumRent.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumRent.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {
            //Database.SetConnectionString("Server=DESKTOP-GFSB6QJ\\SQLEXPRESS;Database=DOUblessTetreeeeeeeeeets;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            Database.EnsureCreated();
        }
        public DbSet<Stadium> Stadium { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}
