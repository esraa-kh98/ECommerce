using ECommerce.Data.Base;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Data.Services
{
    public class CategoryServices : EntityBaseRepository<Category>,ICategoryServices
    {
        public CategoryServices(EcommerceDbContext context):base(context)
        {
          
        }
        //public async Task CreateAsync(Category category)
        //{
        //    await _context.Categories.AddAsync(category);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var categoryId = await _context.Categories.FirstOrDefaultAsync(x => x.Id==id);
        //    if(categoryId != null)
        //    {
        //        _context.Categories.Remove(categoryId);
        //        await _context.SaveChangesAsync();
        //    }

        //}

        //public async Task<IEnumerable<Category>> GetAllAsync()
        //{
        //    var Result = await _context.Categories.ToListAsync();
        //    return Result;
        //}

        //public async Task<Category> GetByIdAsync(int id)
        //{
        //   return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        //}

        //public async Task UpdateAsync(Category category)
        //{
        //    /* var categoryId = await _context.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
        //     if(categoryId != null)
        //     {
        //         categoryId.Id = category.Id;
        //         categoryId.Name = category.Name;
        //         categoryId.Description = category.Description;
        //         await _context.SaveChangesAsync();
        //     }*/
        //    _context.Categories.Update(category);
        //    await _context.SaveChangesAsync();
        //}
    }
}
