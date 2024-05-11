using Concurrency.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Concurrency.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Update(int id)
        {
            var product = await _context.Products.FindAsync(id);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            try
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            catch (DbUpdateConcurrencyException exception)
            {
                //hata verilen satırı alıyoruz.
                var exceptionEntry = exception.Entries.First();

                //update için kullanıcının girmiş olduğu değerleri alıyoruz.
                var currentProduct = exceptionEntry.Entity as Product;

                //veritabanındaki değerleri alıyoruz.
                var databaseValues = await exceptionEntry.GetDatabaseValuesAsync();              
                

                var clientValues = exceptionEntry.CurrentValues;

                if(databaseValues ==null)
                {
                    ModelState.AddModelError(string.Empty,"Bu ürün başka bir kullanıcı tarafından silinmiş olabilir.");
                }
                else
                {
                    //veritabanındaki değerleri product nesnesine çeviriyoruz.
                    var databaseProduct = databaseValues.ToObject() as Product;

                    ModelState.AddModelError(string.Empty,"Bu ürün başka bir kullanıcı tarafından güncellenmiş olabilir.");
                    ModelState.AddModelError(string.Empty, $"Güncellenen Değer: Name: {databaseProduct.Name}, Price:{databaseProduct.Price}, Stock:{databaseProduct.Stock}");
                }

                return View(product);
            }           

           
        }


        public async Task<IActionResult> List()
        {
            return View( await _context.Products.ToListAsync());
        }
    }
}
