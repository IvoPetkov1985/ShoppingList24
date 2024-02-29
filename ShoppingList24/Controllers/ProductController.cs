using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingList24.Data;
using ShoppingList24.Data.Models;
using ShoppingList24.Models.Product;

namespace ShoppingList24.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShoppingList24DbContext context;

        public ProductController(ShoppingList24DbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await context.Products
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync();

            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductFormModel model)
        {
            var product = new Product()
            {
                Name = model.Name
            };

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await context.Products.FindAsync(id);

            return View(new ProductViewModel()
            {
                Name = product.Name
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductViewModel model)
        {
            var product = await context.Products.FindAsync(id);

            product.Name = model.Name;

            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await context.Products.FindAsync(id);

            context.Products.Remove(product);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
