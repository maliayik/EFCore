// See https://aka.ms/new-console-template for more information
using EFCore.Relationships.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

Console.WriteLine("Hello, World!");
using (var context = new AppDbContext())
{   

    //Lazy Loading

    var category = await context.Categories.FirstAsync();

    //burada category.Products diyerek productsa ulaşmaya çalıştığımızda lazy loading sayesinde productsa ulaşabiliriz.
    var products = category.Products;     
    
    
    foreach(var item in products)
    {
        //(N+1) problemi oluşabilir.
       var productFeature = item.ProductFeature;    
    }
    
    
    
    
    
    
    
    
    
    
    
    ////Explicit Loading
    //var category = context.Categories.First();

    //var product = context.Products.First();
    //if(true)
    //{
    //    context.Entry(category).Collection(x=> x.Products).Load();

    //    context.Entry(product).Reference(x => x.ProductFeature).Load();

    //    category.Products.ForEach(product =>
    //    {
    //        Console.WriteLine($"{product.Name}");
    //    });
    //}
}





//    //Eager Loading
//    var category = new Category() { Name = "Kalemler" };

//    //kategori üzerinden hem product hemde product feature ekliyoruz.
//    category.Products.Add(new () { Name = "Kurşun Kalem", Price = 5, Stock = 100,ProductFeature=new() { Color="Red",Width=200} });

//    var categoryWithProducts = context.Categories.Include(x=> x.Products).ThenInclude(x=> x.ProductFeature).First();

//    categoryWithProducts.Products.ForEach(product =>
//    {
//      Console.WriteLine($"{categoryWithProducts.Name}{product.Name} {product.ProductFeature.Color}");
//    });

//    var product = context.Products.Include(x=> x.ProductFeature).Include(x=> x.Category).First();   
//}


