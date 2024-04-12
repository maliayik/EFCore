using EFCore.DatabaseFirst.DAL;
using Microsoft.EntityFrameworkCore;


DbContextInitializer.Build();

using (var context = new AppDbContext(DbContextInitializer.optionsBuilder.Options))
{
    var product = await context.Products.ToListAsync();

    product.ForEach(p =>
    {
        Console.WriteLine($"Ürünler: {p.Id} : {p.Name}");
    });

}