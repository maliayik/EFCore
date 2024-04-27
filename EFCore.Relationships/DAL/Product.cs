using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Relationships.DAL
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //Id nin otomatik artmasını kapatmış olur.
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Kdv { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal TotalAmount { get; set; } //kdv ve price çarpımını tutan prop.


        public int? CategoryId { get; set; } //bu value type oldugu için her türlü ? koyabiliriz.
        public Category? Category { get; set; } //Eğer proje propertylerin null olmasına izin veriyorsa bu şekilde tanımlanabilir.Ama disable edilmişse soru işareti koymamıza gerek yok.
        
    }

}
