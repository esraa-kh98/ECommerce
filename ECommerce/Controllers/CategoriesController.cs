using ECommerce.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ECommerce.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly EcommerceDbContext _context;
        public CategoriesController(EcommerceDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Response = _context.Categories.ToList();
            return View(Response);
        }
    }
}
