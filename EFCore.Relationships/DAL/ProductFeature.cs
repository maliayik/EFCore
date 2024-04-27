using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Relationships.DAL
{
    public class ProductFeature
    {       
        public int Id { get; set; }      
        public int ProductId { get; set; }
        public Product  Product { get; set; } //buradaki navigation propertyleri kaldırırsak productfeature üzerinden hiç bir şekilde product ekleme işlemi yapamayız. böyle bir senaryoya ihtiyacımız olursa kullanılabilir.
    }
}
