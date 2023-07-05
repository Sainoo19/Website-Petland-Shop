using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Petland_Shop.Models;

namespace Petland_Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly DbMarketsContext _context;
        public ProductController(DbMarketsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var product = _context.Products.Include(x => x.Cat).FirstOrDefault(x => x.ProductId == id);
            if (product == null) return RedirectToAction("Index");
            return View(product);
        }

        public IActionResult CheckOut()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult WishList()
        {
            return View();
        }
    }
}
