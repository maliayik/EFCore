using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.DatabaseFirst.DAL
{
    public class AppDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }


        //bir class içerisinde paremetre alan bir ctor tanımladıgımızda default ctor'a erişmek için onuda tanımlamamız gerekir.dinamik bir yapı kurmus oluruz.Ya aşağıdaki yorum satırındaki gibi override edip buradan db yolunu belirtiyoruz yada multithreadproje için her bir db yolunu ayrı ayrı belirtebiliriz.
        public AppDbContext()
        {
            
        }

        //veri tabanı ayarlarımızı aşağıda tanımladıgımız contextoptions nesnesi üzerinden yapıcaz.
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }





        //appsetttings jsonda connection string girdigimiz için buraya ihtiyacımız yok.
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-KVIRVD3\\SQLEXPRESS;Initial Catalog=EFCoreDatabaseFirstDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //}
    }
}
