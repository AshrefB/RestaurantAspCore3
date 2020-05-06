using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAspCore3.Areas.Admin.Services;

namespace RestaurantAspCore3.Areas.Admin.ApiControllers
{
    [ApiController]
    [Route("api/subCategories")]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService SubCategoryService;

        public SubCategoryController(ISubCategoryService SubCategoryService)
        {
            this.SubCategoryService = SubCategoryService;
        }

        [HttpGet]
        [Route("{Name}")]
        public async Task<IActionResult> GetSubCategoriesByCategoryName(string Name)
        {
            var SubCategories = await SubCategoryService.GetSubCategoriesByGategoryName(Name);
            return Ok(SubCategories);
        }
    }
}