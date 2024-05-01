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
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<ProductFull> ProductFulls { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-KVIRVD3\\SQLEXPRESS;Initial Catalog=EFCoreDbContextDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().HasCheckConstraint("PriceDiscountCheck","[Price] > [DiscountPrice]"); //discountprice pricedan küçük olmalıdır bunun için kural ekliyoruz.







            //Index
            modelBuilder.Entity<Product>().HasIndex(x=> x.Name); //tek bir index

            modelBuilder.Entity<Product>().HasIndex(x=> new {x.Name,x.Price});//birden fazla index


            modelBuilder.Entity<Product>().HasIndex(x => x.Name).IncludeProperties(x => new { x.Price, x.Stock }); //index içerisinde başka alanlarıda tutmak için



            modelBuilder.Entity<ProductFull>().HasNoKey();

            modelBuilder.Entity<Product>().Ignore(x=> x.Price);

            modelBuilder.Entity<Product>().Property(x=> x.Name).IsUnicode(false);

            modelBuilder.Entity<Product>().Property(x=> x.Price).HasColumnType("decimal(18,2)");

            //OWNED ENTITY
            modelBuilder.Entity<Manager>().OwnsOne(m => m.Person,x=>
            {
                x.Property(x => x.FirstName).HasColumnName("ManagerFirstName");
            });
            modelBuilder.Entity<Employee>().OwnsOne(e => e.Person);

            base.OnModelCreating(modelBuilder);
        }
    }
}
