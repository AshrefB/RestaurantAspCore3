using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAspCore3.Data;

namespace RestaurantAspCore3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SubCategoryController(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        public async Task<IActionResult> Index()
        {
            var subCategories = await _db.subCategories.Include(s => s.Category).ToListAsync();
            return View(subCategories);
        }
    }
}