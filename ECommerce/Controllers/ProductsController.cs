﻿using ECommerce.Data;
using ECommerce.Data.Services;
using ECommerce.Data.Static;
using ECommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProductsController : Controller
    {
        private readonly IProductServices _services;
        private readonly ICategoryServices _categoryServices;
        public ProductsController(IProductServices services, ICategoryServices categoryServices)
        {
            _services = services;
            _categoryServices = categoryServices;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index(string SearchTerm)
        {
            //var Response =await _context.Products.Include(x=>x.Category).OrderBy(x=>x.Pame).ToListAsync();
            //return View(Response);
            var Response = await _services.GetAllAsync(x => x.Category);
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Response = Response.Where(x => x.Name.Contains(SearchTerm)).ToList();
            }
            return View(Response);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var Response = await _services.GetByIdAsync(id, x => x.Category);
            return View(Response);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = await _categoryServices.GetAllAsync();
            return View();
        }
        [HttpPost,ActionName(nameof(Create))]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if(ModelState.IsValid)
            {
                await _services.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View("NotFound");
        }
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.CategoryId = await _categoryServices.GetAllAsync();
            var productId = await _services.GetByIdAsync(id, x => x.Category);
            return View(productId);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _services.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
