// See https://aka.ms/new-console-template for more information
using EFCore.DatabaseFirst.ByScaffold.Models;
using Microsoft.EntityFrameworkCore;



using (var context = new EFCoreDatabaseFirstDbContext())
{ 
     

    context.Products.Add(new() { Name = "Kalem 1", Price = 200, });
    context.Products.Add(new() { Name = "Kalem 2", Price = 300, });
    context.Products.Add(new() { Name = "Kalem 3", Price = 400, });

    //ContextId Birden çok instance (kullanıcılarla) uygulamay giriş yapıldıgında bunları loglamamıza yarayan bir random uniq bir değer ataması yapar.
    Console.WriteLine($"Context ID : {context.ContextId}");

    //Buradaki savechange içerisinden dbye kayıt etmeden önce yaptıgımız işlemlere erişebiliriz.
    context.SaveChanges();
 
}