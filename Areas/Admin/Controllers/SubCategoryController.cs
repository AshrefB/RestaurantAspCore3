using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAspCore3.Data;
using RestaurantAspCore3.Models;
using RestaurantAspCore3.Models.ViewModels;

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

        public async Task<IActionResult> Create()
        {
            SubCategoryAndCategory subCategoryAndCategory = new SubCategoryAndCategory()
            {
                Categories = await _db.categories.ToListAsync(),
                SubCategories = await _db.subCategories.ToListAsync(),
                SubCategory = new SubCategory()
            };
            return View(subCategoryAndCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubCategory subCategory)
        {
            if(ModelState.IsValid)
            {
                _db.subCategories.Add(subCategory);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subCategory);
        }
    }
}