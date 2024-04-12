using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DAL
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //console uygulaması oldugu için burada build metodunu cagırıyoruz .net veya api projelerinde buna gerek yok.Migration sırasında Connection stringi okuması için  o yüzden build metodunu çağırıyoruz.
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        public DbSet<Product> Products { get; set; }
    }
}
