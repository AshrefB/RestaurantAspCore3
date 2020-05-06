using Microsoft.EntityFrameworkCore;
using RestaurantAspCore3.Data;
using RestaurantAspCore3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAspCore3.Areas.Admin.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _db;
        public CategoryService(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _db.categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _db.categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> AddCategory(Category Category)
        {
            await _db.categories.AddAsync(Category);
            await _db.SaveChangesAsync();
            return Category;
        }

        public async Task<Category> UpdateCategory(int Id, Category Category)
        {
            var CategoryDb = await _db.categories.SingleOrDefaultAsync(c => c.Id == Id);
            CategoryDb.Name = Category.Name;
            await _db.SaveChangesAsync();
            return CategoryDb;
        }
    }
}
