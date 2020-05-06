using Microsoft.EntityFrameworkCore;
using RestaurantAspCore3.Data;
using RestaurantAspCore3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAspCore3.Areas.Admin.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ApplicationDbContext _db;

        public SubCategoryService(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategoriesByGategoryName(string Name)
        {
            return await _db.subCategories
                .Include(s => s.Category)
                .Where(s => s.Category.Name == Name)
                .ToListAsync();
        }
    }
}
