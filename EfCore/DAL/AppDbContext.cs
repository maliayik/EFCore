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
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductFull> ProductFulls { get; set; }
        public DbSet<ProductWithFeature>  ProductWithFeatures { get; set; }
        public DbSet<ProductCount> ProductCount { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-KVIRVD3\\SQLEXPRESS;Initial Catalog=EFCoreDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public IQueryable<ProductWithFeature> GetProductWithFeatures(int categoryId)
        {
           return FromExpression(()=> GetProductWithFeatures(categoryId));
        }

        //EF Core içerisinde bu metodu direkt olarak çağırmamız için içerisine exception yazdık.
        public int GetProductCount(int categoryId)
        {
            throw new NotSupportedException("Bu method ef core tarafından çalıştırılmaktadır.");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDbFunction(typeof(AppDbContext).GetMethod(nameof(GetProductWithFeatures), new[] { typeof(int) })!).HasName("pf_product_full_param");


            modelBuilder.HasDbFunction(typeof(AppDbContext).GetMethod(nameof(GetProductCount), new[] { typeof(int) })!).HasName("fc_get_product_count");


            modelBuilder.Entity<ProductCount>().HasNoKey();

            modelBuilder.Entity<ProductFull>().ToFunction("fc_product_full");


            base.OnModelCreating(modelBuilder);
        }
    }
}
