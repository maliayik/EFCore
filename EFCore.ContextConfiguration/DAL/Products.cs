using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.ContextConfiguration.DAL
{
    //Tablo isimlerini değiştirmek için kullanılan Data Annotations Yöntemi
    [Table("ProductTb",Schema ="products")]
    public class Product
    {        
        public int ID { get; set; }
        [StringLength(150,MinimumLength =50)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Barcode { get; set; }
    }
}
