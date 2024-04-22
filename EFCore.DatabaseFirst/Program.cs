using EFCore.DatabaseFirst.DAL;
using Microsoft.EntityFrameworkCore;


DbContextInitializer.Build();

using (var context = new AppDbContext(DbContextInitializer.optionsBuilder.Options))
{


    //Add metodu için state çalışma mekanizması

    var newProduct = new Product { Name = "Kalem", Price = 200 }; //track edilmeyen data olduugu için detached olur.

    Console.WriteLine($"ilk state : {context.Entry(newProduct).State}");

    await context.AddAsync(newProduct); // ilk track işlemi burada başlar.

    Console.WriteLine($"Add işleminden sonraki state : {context.Entry(newProduct).State}");

    context.SaveChanges();

    Console.WriteLine($"SaveChanges işleminden sonraki state : {context.Entry(newProduct).State}");

    //--------------------------------------------------------------------------------------------------

    //Update metodu için state çalışma mekanizması

    //ilk datayı getirir.
    var product = await context.Products.FirstAsync();

    Console.WriteLine($"ilk state : {context.Entry(product).State}");

    // update işlemi yapmak için update metodunu çağırmaya gerek yok burda zaten veri ataması yapıyoruz yani modified etmiş oluyoruz.
    product.Price = 200;



    Console.WriteLine($"Update işleminden sonraki state : {context.Entry(product).State}");

    context.SaveChanges();

    Console.WriteLine($"SaveChanges işleminden sonraki state : {context.Entry(product).State}");

    //Update metodu EFCore tarafından track edilemeyen veriler için kullanılır aşağıdaki örnekteki gibi.
    context.Update(new Product { Id = 2, Price = 1000 });

    //burada data oldugu için update metoduna ihtiyaç yok direk olarak ıdsi 5 olan price değerini güncelleyebiliriz.
    var hasProduct = context.Products.First(x => x.Id == 5);

    hasProduct.Price = 1000;


    //------------------------------------------------------------------------------------------------

    //Delete metodu için state çalışma mekanizması


    Console.WriteLine($"ilk state : {context.Entry(product).State}");

    //burada state deleted olarak atanır.
    context.Remove(product);

    Console.WriteLine($"delete işleminden sonraki state : {context.Entry(product).State}");

    context.SaveChanges();

    //burada state detached olur çünkü artık mevcut veri yok track edilen veri silindiği için.
    Console.WriteLine($"SaveChanges işleminden sonraki state : {context.Entry(product).State}");



    //-----------------------------------------------------------------------------------------------

   



















}