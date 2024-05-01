using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.DAL
{
    [Keyless] //keyless atributesi ile işaretliyoruz.
    public class ProductFull
    {
        //Burada rawsql de yazılan sorguya karşılık gelen entity oluşturuldu.
        public int Product_ID { get; set; } //EFCore primary key olarak algılamaması için Id yerine                                       Product_ID kullanıldı.
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }       
    }
}
