using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCore.DatabaseFirst.ByScaffold.Models
{
    public partial class EFCoreDatabaseFirstDbContext : DbContext
    {
        public EFCoreDatabaseFirstDbContext()
        {
        }

        public EFCoreDatabaseFirstDbContext(DbContextOptions<EFCoreDatabaseFirstDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=DESKTOP-KVIRVD3\\SQLEXPRESS;Initial Catalog=EFCoreDatabaseFirstDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

        }

        public override int SaveChanges()
        {
            //change tracker sayesinde memorydeki veriye erişebiliyoruz.Fakat bu kodu böyle yazmaktansa merkezi biryere taşımamız gerekiyor dbcontex içerisinde savechange override edip kullanıcaz.
            try
            {
                ChangeTracker.Entries().ToList().ForEach(e =>
            {
                //burada product entitiysine erişiyoruz.
                if (e.Entity is Product p)
                {
                    //changetracker sayesinde tek seferde databaseye veriyi kayıt etmeden önce  örnek olarak createdate alanını eğerki enttiytype added ise ekliyoruz.
                    if (e.State == EntityState.Added)
                    {
                        p.CreateDate = DateTime.Now;
                    }
                }
            });
                return base.SaveChanges();
            }
            //asıl savechange bu base olan biz override ettiğimiz metodu başka classlardan cağırıp buraya erişiyoruz.

            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException);
                // Daha fazla işlem yapabilirsiniz: Loglama, hata ayıklama, vb.
                throw;



            }
        }
    }
}
