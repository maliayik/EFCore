using EfCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.DAL
{
    public class AppDbContext:DbContext
    {
        private readonly int Barcode;

        public AppDbContext(int barcode)
        {
            Barcode = barcode;
        }

        public AppDbContext()
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductEssential>  ProductEssentials { get; set; }
        public DbSet<ProductFull> ProductFulls { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-KVIRVD3\\SQLEXPRESS;Initial Catalog=EFCoreDbContextDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False").UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //global query filter
            modelBuilder.Entity<Product>().Property(x=> x.IsDeleted).HasDefaultValue(false);

            modelBuilder.Entity<Product>().HasQueryFilter(p=> !p.IsDeleted && p.Barcode==Barcode);



            modelBuilder.Entity<ProductEssential>().HasNoKey().ToSqlQuery("Select Name,Price from Products");

            modelBuilder.Entity<ProductFull>().ToView("productwithfeature");
            base.OnModelCreating(modelBuilder);
        }
    }
}
