using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Inventaris.Models;
using Inventaris.Data;

namespace Inventaris.Controllers
{
    public class HomeController : Controller
    {
        private readonly InventarisContext _context;

        public HomeController(InventarisContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var supplierCount = _context.Supplier.Count();
            var categoryCount = _context.Category.Count();
            var itemCount = _context.Item.Count();

            ViewBag.SupplierCount = supplierCount;
            ViewBag.CategoryCount = categoryCount;
            ViewBag.ItemCount = itemCount;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
