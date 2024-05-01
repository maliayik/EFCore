using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.DAL
{   //where koşullarında olan alanları indexlemek doğru olacaktır.
    [Index(nameof(Name),nameof(Price))] //birden fazla index olusturulabilir.
    [Index(nameof(Stock))] //tek bir index olusturulabilir.
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }//discountprice pricedan küçük olmalıdır bunun için kural ekliyoruz.
        public int Stock { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ProductFeature ProductFeature { get; set; }
    }
}
