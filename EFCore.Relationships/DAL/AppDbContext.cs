using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Relationships.DAL
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {        

            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=DESKTOP-KVIRVD3\\SQLEXPRESS;Initial Catalog=EFCoreRelatedDataDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        //public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Product>().Property(x=> x.Price).HasPrecision(18, 2);


          

            base.OnModelCreating(modelBuilder);
        }
    }
}
