using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAspCore3.Areas.Admin.Services;
using RestaurantAspCore3.Data;
using RestaurantAspCore3.Models;

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
        [Route("{Id}")]
        public async Task<IActionResult> GetCategoryById(int Id)
        {
            var Category = await CategoryService.GetCategoryById(Id);
            return Ok(Category);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category Category)
        {
            if (ModelState.IsValid)
            {
                var AddedCategory = await CategoryService.AddCategory(Category);
                return Ok(AddedCategory);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> UpdateCategory(int Id, Category Category)
        {
            if (ModelState.IsValid)
            {
                var UpdatedCategory = await CategoryService.UpdateCategory(Id, Category);
                return Ok(UpdatedCategory);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteCategory(int Id)
        {
            var DeletedCategory = await CategoryService.DeleteCategory(Id);
            return Ok(DeletedCategory);
        }
    }
}