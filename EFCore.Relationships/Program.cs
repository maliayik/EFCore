// See https://aka.ms/new-console-template for more information
using AutoMapper.QueryableExtensions;
using EFCore.Relationships.DAL;
using EFCore.Relationships.DTOs;
using EFCore.Relationships.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Runtime.Serialization;

Console.WriteLine("Hello, World!");
using (var _context = new AppDbContext())
{

    //1. kullanım bu yöntemin dez avantajı tüm product entitylerini çekip sonra maplemek.
    var product = _context.Products.ToList();
    var productDto= ObjectMapper.Mapper.Map<List<ProductDto>>(product);

    //2. kullanımda sadece dto içerisinde yer alan propertyler çekilir.
    var productDto=_context.Products.ProjectTo<ProductDto>(ObjectMapper.Mapper.ConfigurationProvider).ToList();


}


