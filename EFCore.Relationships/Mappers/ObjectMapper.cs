using AutoMapper;
using EFCore.Relationships.DAL;
using EFCore.Relationships.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Relationships.Mappers
{
    //console uygulaması olduğu için bu clası kendımız olusturuyoruz,
    //DI container yapısı olan uygulamada direk programcs içerisinde tanımlayabiliriz.
    public class ObjectMapper
    {
        //uygulama ilk çalıştıgında bu nesne çalışmayacak biz ne zaman erişirsek o zaman çalışacak.
        private static readonly Lazy<IMapper> lazy=new Lazy<IMapper>(()=>
        {
            var config=new MapperConfiguration(cfg=>
            {
                cfg.AddProfile<CustomMapping>();
            });
            return config.CreateMapper();
        });

        //yukarda tanımladıgımız  lazy nesnesine erişmek için bu propertyi kullanıyoruz.
        public static IMapper Mapper=>lazy.Value;

    }



    //kime mapleyeceğimizi belirtmek için profile sınıfını kullanıyoruz.
    internal class CustomMapping:Profile
    {
        public CustomMapping()
        {
            //sadece productdtoyu producta maplemek istiyorsak reverse map yazmamıza gerek yok.
            //ama tam tersi mapleme yapmak istiyorsak reverse map yazmamız gerekiyor.
           CreateMap<ProductDto,Product>().ReverseMap();
        }
    }
}
