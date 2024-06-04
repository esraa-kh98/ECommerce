using ECommerce.Data;
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
    public class CategoriesController : Controller
    {
        private readonly ICategoryServices _services;
        public CategoriesController(ICategoryServices services)
        {
            _services = services;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var Response = await _services.GetAllAsync();
            return View(Response);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                await _services.CreateAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var category = await _services.GetByIdAsync(id);
            if (category != null)
            {
                return View(category);
            }
            return View("NotFound");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _services.GetByIdAsync(id);
            if (category != null)
            {
                return View(category);
            }
            return View("NotFound");
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Category category)
        //{
        //    if (id != category.Id)
        //    {
        //        return View("NotFound");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            await _services.UpdateAsync(category);
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            // Handle exceptionq
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(category);
        

            public async Task<IActionResult> Edit(Category category)
             {
                 if (!ModelState.IsValid) 
                 {
                     return View("NotFound");
                 }
                 await _services.UpdateAsync(category);
                 return RedirectToAction(nameof(Index));
             }
        
        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        }
    }
