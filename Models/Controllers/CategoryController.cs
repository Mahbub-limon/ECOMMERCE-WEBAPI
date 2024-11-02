using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_webApi.DTOs;
using Microsoft.AspNetCore.Mvc; //ControllerBase

namespace Ecommerce_webApi.Models.Controllers
{
    [ApiController] //for this api controller
    [Route("api/categories/")]  //entring path, default common path for all request
    public class CategoryController:ControllerBase
    {
       private static  List<Category> categories = new List<Category>();  //like as an object for Category model

        #region  MapGet
       //GET :/api/categories => Read categories
       [HttpGet]
        public IActionResult GetCategories([FromQuery] string searchValue = "")   // "I" is the interface before ActionResult// this is made of getRequest
       { 
                // if(!string.IsNullOrEmpty(searchValue))
                // {
                //     var SearchedCategories = categories.Where(c => c.Name.Contains(searchValue,StringComparison.OrdinalIgnoreCase)).ToList();
                //     return Ok(SearchedCategories);
                // }
                

                var categoryList = categories.Select(c => new CategoryReadDto //follow CategoryReadDto pattarn
                {
                    categoryId = c.CategoryId,
                    Name = c.Name,
                    Description = c.Description,
                    CreateAdt = c.CreateAdt
                }).ToList(); //Convert ToList();

            return Ok(categoryList);
        }

#endregion

        #region MapPost
        //POST::: /api/categories => Create a category
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryCrieateDto categoryData)
        {
            if(!ModelState.IsValid) //Data annotation
            {
                return BadRequest("Invalid Data");
            }
            var newCategory = new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = categoryData.Name,
                CreateAdt = DateTime.UtcNow,
            };
            categories.Add(newCategory);

           var categoryReadDto = new CategoryReadDto{  //newCategory returing by CategoryReadDto pattarn
                categoryId = newCategory.CategoryId,
                Name =newCategory.Name,
                Description = newCategory.Description,
                CreateAdt = newCategory.CreateAdt
            };
            return Created($"/api/categories/{newCategory.CategoryId}",categoryReadDto);
        }
           #endregion

        #region  MapDelete
        //Delete:/api/cagegories/{categoryId} => Delete a category by Id
        [HttpDelete("{categoryId:guid}")]
        public IActionResult DeleteCategoryById(Guid categoryId)
        {
            var foundCategory = categories.FirstOrDefault(Category => Category.CategoryId == categoryId);

           if(foundCategory == null)
           {
                return NotFound("Category with this id does not exist");
           }
           categories.Remove(foundCategory);
           return NoContent();
        }
         #endregion
     
        #region MapPut
      //put : /api / categories/{categoryId} => update a category
      [HttpPut("{categoryId:guid}")]
      public IActionResult UpdateCategoryById(Guid categoryId,[FromBody] CategoryUpdateDto categoryData)
      {
        if(categoryData == null)
        {
            return BadRequest("Category data is missing");
        }

        var foundCategory = categories.FirstOrDefault(Category => Category.CategoryId == categoryId);
        if(foundCategory == null)
        {
            return NotFound("Category with this id does not exist");
        }
        if(!string.IsNullOrEmpty(categoryData.Name))
        {
            if(categoryData.Name.Length >= 2)
            {
                foundCategory.Name = categoryData.Name;
            }
            else
            {
              return BadRequest("Category name must be atleast 2 characters long");
            }
        }
        if(!string.IsNullOrWhiteSpace(categoryData.Description))
        {
            foundCategory.Description = categoryData.Description;
        }
        return NoContent();
      }
        #endregion
    }
  
}