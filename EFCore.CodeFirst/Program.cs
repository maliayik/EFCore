// See https://aka.ms/new-console-template for more information

using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();
using (var context = new AppDbContext())
{
    var product =  await context.Products.ToListAsync();

    product.ForEach(p =>
    {
        Console.WriteLine($"{p.Name} - {p.Price} - {p.Stock}");
    });
}
