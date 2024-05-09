using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Relationships.DAL
{
    public class AppDbContext:DbContext
    {
        private DbConnection connection;

        public AppDbContext(DbConnection connection)
        {
            connection = connection;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-KVIRVD3\\SQLEXPRESS;Initial Catalog=EFCoreRelationshipDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<ProductFeature> ProductFeatures { get; set; }

        //public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.TotalAmount).HasComputedColumnSql("[Price]*[Kdv]");


            modelBuilder.Entity<Product>().Property(x => x.Id).ValueGeneratedNever();//None
            modelBuilder.Entity<Product>().Property(x => x.TotalAmount).ValueGeneratedOnAddOrUpdate();//Computed
            modelBuilder.Entity<Product>().Property(x => x.TotalAmount).ValueGeneratedOnAdd();//Identity








            //one-to-one
            //modelBuilder.Entity<Product>().HasOne(x=> x.ProductFeature).WithOne(x=>x.Product).HasForeignKey<ProductFeature>(x=>x.ProductId);

            //one-to-many
            //modelBuilder.Entity<Category>().HasMany(x=> x.Products).WithOne(y=> y.Category).HasForeignKey(x=>x.CategoryId);

            //one-to-one
            //modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.Id);

            modelBuilder.Entity<ProductFeature>().HasMany(x=> x.Product).WithOne(x => x.ProductFeature)

            //many to many
            //modelBuilder.Entity<Student>()
            //    .HasMany(x => x.Teachers)
            //    .WithMany(x => x.Students)
            //    .UsingEntity<Dictionary<string, object>>(
            //    "StudentTeacherTb",
            //    x => x.HasOne<Teacher>().WithMany().HasForeignKey("Teacher_ID").HasConstraintName("FK_TeacherId"),
            //    y => y.HasOne<Student>().WithMany().HasForeignKey("Student_Id").HasConstraintName("FK_StudentId")
            //    ); ;

            base.OnModelCreating(modelBuilder);
        }
    }
}
