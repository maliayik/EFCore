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
        public DbSet<BasePerson> Persons { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-KVIRVD3\\SQLEXPRESS;Initial Catalog=EFCoreInheritanceDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TPT
            modelBuilder.Entity<BasePerson>().ToTable("Persons");
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Manager>().ToTable("Managers");


            base.OnModelCreating(modelBuilder);
        }
    }
}
