﻿using ECommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly EcommerceDbContext _context;
        public ProductsController(EcommerceDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var Response =await _context.Products.Include(x=>x.Category).OrderBy(x=>x.Pame).ToListAsync();
            return View(Response);
        }
    }
}