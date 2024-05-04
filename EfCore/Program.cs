// See https://aka.ms/new-console-template for more information
using EfCore.DAL;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text;

Console.WriteLine("Hello, World!");




using (var context = new AppDbContext())
{
    
    
    var productsWithFeatures=context.Products.TagWith("Bu query ürünler ve ürünlere bağlı özellikleri getirir.").Include(x=>x.ProductFeature).Where(x=> x.Price>100).ToList();
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    //ignore query filter
    var products= context.Products.IgnoreQueryFilters().ToList();



    #region Pagination
    GetProducts(1, 3).ForEach(x =>
{
   Console.WriteLine($"{x.Id} {x.Name}");

});

    static async List<Product> GetProducts(int page, int pageSize)
    {
        // page =1 pagesize=3 => ilk 3 kayıt => skip:0 take:3 => ilk 3 kayıtı getirir.
        //burada her sayfada 3 kayıt getirmesi için algoritma oluşturuyoruz.
        //(page-1)*pageSize) algoritması bize girilen sayfa numarasına göre 3 kaydı getirir.

        return context.Products.Where(x => x.Price > 100).OrderByDescending(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();

    } 
    #endregion








    //raw sql sorguları
    var products = context.Products.FromSqlRaw("select * from Products").ToList();

    var id = 5;

    //parametreli sorgu string format il 0. indexe id yi atıyoruz
    var products2 = context.Products.FromSqlRaw("select * from Products where Id={0}", id).ToList();



    var productInterpolated = context.Products.FromSqlInterpolated($"select * from Products where Id={id}").ToList();














    //left join
    var leftJoinResult = await (from p in context.Products
                                join pf in context.ProductFeatures on p.Id equals pf.ProductId into pflist
                                from pf in pflist.DefaultIfEmpty()
                                select new { p.Name, pf.Color }).ToListAsync();





    //right join
    var rightJoinResult = await (from pf in context.ProductFeatures
                                 join p in context.Products on pf.ProductId equals p.Id into plist
                                 from p in plist.DefaultIfEmpty()
                                 select new { pf.Color, p.Name }).ToListAsync();

    var outherJoin = leftJoinResult.Union(rightJoinResult);




    //üçlü join

    //var result = (from c in context.Categories
    //                               join p in context.Products on c.Id equals p.CategoryId
    //                               join pf in context.ProductFeatures on p.Id equals pf.ProductId
    //                                select new { c.Name, p.Name, pf.Name }).ToList();





    //ikili join
    var result2 = (from c in context.Categories
                   join p in context.Products on c.Id equals p.CategoryId
                   select p).ToList();






    //bir datayı formatlıyarak almak için yeni bir nesne olusturup metodumuzu kullanarak gelen datayı formatlıyarak olusturdugumuz nesneye atıyoruz
    var person = context.People.ToList().Select(x => new { PersonName = x.Name, PersonPhone = FormatPhone(x.Phone) }).ToList();

    //telefon numarasının ilk karakterini almayan almayarak formatlayan metot
    string FormatPhone(string phone)
    {
        return phone.Substring(1, phone.Length - 1);
    }

}