using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAspCore3.Data;
using RestaurantAspCore3.Models;

namespace RestaurantAspCore3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.categories.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Category category = await _db.categories.FindAsync(id);
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if(ModelState.IsValid)
            {
                _db.categories.Add(category);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Category category = await _db.categories.FindAsync(id);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if(ModelState.IsValid)
            {
                _db.categories.Update(category);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Category category = await _db.categories.FindAsync(id);
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Category category = await _db.categories.FindAsync(id);
            _db.categories.Remove(category);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}