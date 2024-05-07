// See https://aka.ms/new-console-template for more information
using EfCore.DAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

Console.WriteLine("Hello, World!");


using (var _context = new AppDbContext())
{

    int categoryId = 1;

   var productCount=_context.ProductCount.FromSqlRaw($"select fc_get_product_count({categoryId}) as Count ").First().Count;









    int categoryId = 1;

    var products = _context.ProductWithFeatures.FromSqlInterpolated($"pf_product_full_param ({categoryId})").ToList();



    var categories = _context.Categories.Select(x => new
    {
        CategoryName = x.Name,
        ProductCount = _context.GetProductCount(x.Id)//fuctionumuzu bu şekilde kullanabiliriz
    });




    //örnek 4 insert yapan sp

    var product = new Product()
    {
        Name = "kalem1",
        Price = 50,
        DiscountPrice = 10,
        Stock = 100,
        Barcode = 123456,
        CategoryId = 1

    };
    var newProductIdParamater=new SqlParameter("newId",SqlDbType.Int);
    newProductIdParamater.Direction=ParameterDirection.Output;//çıkış parametresi olduğunu belirtiyoruz

    _context.Database.ExecuteSqlInterpolated($"exec sp_insert_product {product.Name},{product.Price},{product.DiscountPrice},{product.Stock},{product.Barcode},{product.CategoryId},{newProductIdParamater} out");

     
    var newProductId=newProductIdParamater.Value;//insert yaptıkça dönen id yi alıyoruz,buradaki ıd her insert sonrası artan id dir







    int categoryId = 1;
    decimal price = 50;


    //örnek 3 parametreli sp
var productWithParam= await _context.ProductFulls.FromSqlInterpolated($"exec sp_get_products_full_parameters {categoryId},{price}").ToListAsync();






    //örnek 2 custom sp
   var productFull= await _context.ProductFulls.FromSqlRaw("exec sp_get_product_full").ToListAsync();



  //örnek 1 
  var product= await _context.Products.FromSqlRaw("exec sp_get_products").ToListAsync();


}