// See https://aka.ms/new-console-template for more information
using EFCore.DatabaseFirst.ByScaffold.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");


using (var context = new EFCoreDatabaseFirstDbContext())
{
    var product = await context.Products.ToListAsync();

    product.ForEach(p =>
    {
        Console.WriteLine($"Ürünler: {p.Id} : {p.Name}");
    });



    //Aşağıda package manager consol içerisinde yazmıs oldugmuz scaffold komutu var bu komut dbfirst yaklaşımı için context sınıfımızı otomatik olarak olusturmamıza yarar.

    // Scaffold - DbContext "Data Source=DESKTOP-KVIRVD3\SQLEXPRESS;Initial Catalog=EFCoreDatabaseFirstDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models
    //
}