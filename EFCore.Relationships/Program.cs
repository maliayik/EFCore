// See https://aka.ms/new-console-template for more information
using EFCore.Relationships.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

Console.WriteLine("Hello, World!");
using (var _context = new AppDbContext())
{







    //Aşağıda kategori ve ürün ekleme işlemi yapılmakta. Ürünler kategoriler ile birbirine bağlı olduğu için önce kategori sonra o kategoriye bağlı ürün ekleniyor.
    //Bu tür işlemlerde iki savechanges kullansak bile transaction içerisine aldığımız için eğer ki bir hata olursa rollback yapacaktır.
    //transaction içerisine almazsak eğer  ilk işlem db ye kayıt olurken ikincisi olmayabilir.Veri bütünü bozulabilir.
    using (var transaction=_context.Database.BeginTransaction())
    {
        try
        {
            var category = new Category() { Name = "Telefonlar" };
            _context.Categories.Add(category);
            _context.SaveChanges();


        


            Product product = new()
            {
                Name = "Samsung",
                Price = 5000,
                CategoryId = category.Id //buradaki category ıd yukarıdaki sorgudan gelen categoryId,
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            transaction.Commit();
        }
        catch
        {
            // EFCORE transaction işlemlerinde bir hata olursa kendisi otomatik rollback yapar bu yüzden eğer ki herhangi
            // bir loglama işlemi yapmayacaksak transaction içerisine try catch bloğu yazmamıza gerek yoktur.
            transaction.Rollback();
        }
        

    }


    var category = new Category() { Name = "Telefonlar" };
    _context.Categories.Add(category);


    Product product = new()
    {
        Name = "Samsung",
        Price = 5000,
        Category = category
    };
    _context.Products.Add(product);
    _context.SaveChanges();
   



}


