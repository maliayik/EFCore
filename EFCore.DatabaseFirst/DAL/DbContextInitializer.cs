using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.DatabaseFirst.DAL
{   
    public class DbContextInitializer
    {
        public static IConfigurationRoot Configuration;//appsetting.jsonu okumak için.
        public static DbContextOptionsBuilder<AppDbContext> optionsBuilder;//veritabanı optionsları için


        public static void Build()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration=builder.Build(); //configuration sayesinde  herhangi bir keyvaluemizi                                       istedigimiz  yerde cagırıp kullanabiliriz.
            optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SqlCon"));
        }

    }
}
