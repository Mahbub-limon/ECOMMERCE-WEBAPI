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
                var categoryList = categories.Select(c => new CategoryReadDto //follow CategoryReadDto pattarn
                {
                    categoryId = c.CategoryId,
                    Name = c.Name,
                    Description = c.Description,
                    CreateAdt = c.CreateAdt
                }).ToList(); //Convert ToList();

            return Ok(ApiReponse<List<CategoryReadDto>>.SuccessResponse(categoryList,200,"Category returned successgully"));
        }

#endregion

        #region MapPost
        //POST::: /api/categories => Create a category
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryCrieateDto categoryData)
        {
        
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
            return Created($"/api/categories/{newCategory.CategoryId}",ApiReponse<CategoryReadDto>.SuccessResponse(categoryReadDto,201,"Categeories Created successfully"));
        }
           #endregion
     
        #region MapPut
      //put : /api / categories/{categoryId} => update a category
      [HttpPut("{categoryId:guid}")]
      public IActionResult UpdateCategoryById(Guid categoryId,[FromBody] CategoryUpdateDto categoryData)
      {
        var foundCategory = categories.FirstOrDefault(Category => Category.CategoryId == categoryId);
        if(foundCategory == null)
        {
            return NotFound("Category with this id does not exist");
        }
                foundCategory.Name = categoryData.Name;
                foundCategory.Description = categoryData.Description;
               
                return Ok(ApiReponse<object>.SuccessResponse(null,204,"Category Update successfully"));
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
           return Ok(ApiReponse<object>.SuccessResponse(null,204,"Category deleted successfully"));
        }
         #endregion
    }
  
}