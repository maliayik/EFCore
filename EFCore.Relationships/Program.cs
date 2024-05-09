// See https://aka.ms/new-console-template for more information
using EFCore.Relationships.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

Console.WriteLine("Hello, World!");
using (var context = new AppDbContext())
{
    //isimsiz yansıtma 1. örnek
    var products = context.Products.Include(x => x.Category).Select(x => new
    {
        //Annonymous (isimsiz) bir yansıtma  yapmış olduk.
        CategoryName = x.Category.Name,
        ProductName = x.Name,
        ProductPrice = x.Price
    }).Where(x => x.ProductPrice > 100).ToList();



    //isimsiz yansıtma 2. örnek

    var products2 = context.Categories.Include(x => x.Products).ThenInclude(x => x.ProductFeature).Select(x => new
    {
        //burada yine isimsiz bir yansıtma yapıyoruz ve yansıtmanın içinde join select gibi linq sorguları yazabiliyoruz.

        CategoryName = x.Name,
        ProductName = String.Join(",", x.Products.Select(x => x.Name)),//product nameleri virgülle                                                         ayrılmış bir şekilde yazdırmış olduk.
        TotalPrice = x.Products.Sum(x => x.Price)

        //buradaki data where şartında yazmıs oldugumuz değerlerle birlikte bize sonuç döndürür.
        //yani where şartını sonradan oluşturmaz hepsini birlikte gerçekleştirir.
    }).Where(y => y.TotalPrice > 100).OrderBy(x => x.TotalPrice).ToList();


    //isimsit yansıtma örnek 3

    //Eğerki İsimsiz yansıtma yapacağımız entityler içerisinde  navigation propertyler var ise include kullanmamız gerekmemektedir, select ifadesi ile bu propertylere erişebiliriz.
    var products = context.Products.Select(x => new
    {
        //Annonymous (isimsiz) bir yansıtma  yapmış olduk.
        CategoryName = x.Category.Name,
        ProductName = x.Name,
        ProductPrice = x.Price,
        ProductColor=x.ProductFeature.Color
    }).Where(x => x.ProductPrice > 100).ToList();


}


