using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.ContextConfiguration.DAL
{
    public class AppDbContext:DbContext
    {

        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-KVIRVD3\\SQLEXPRESS;Initial Catalog=EFCoreDbContextDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Burada custom primary key belirlerken ef coru haberdar ediyoruz.
            modelBuilder.Entity<Product>().HasKey(x => x.ID);

            modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired();

            modelBuilder.Entity<Product>().Property(x=> x.Name).HasMaxLength(100);

            modelBuilder.Entity<Product>().Property(x=> x.Name).HasMaxLength(100).IsFixedLength();

            base.OnModelCreating(modelBuilder);
        }
    }
}
