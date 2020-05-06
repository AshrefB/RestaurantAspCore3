using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAspCore3.Areas.Admin.Services;
using RestaurantAspCore3.Data;

namespace RestaurantAspCore3.Areas.Admin.ApiControllers
{
    [ApiController]
    [Route("/api/categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService CategoryService;
        public CategoryController(ICategoryService CategoryService)
        {
            this.CategoryService = CategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var Categories = await CategoryService.GetCategories();
            return Ok(Categories);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCategoryById(int Id)
        {
            var Category = await CategoryService.GetCategoryById(Id);
            return Ok(Category);
        }
    }
}