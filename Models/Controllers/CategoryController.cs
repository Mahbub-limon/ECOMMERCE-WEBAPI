using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Ecommerce_webApi.DTOs;
using Ecommerce_webApi.Models.Controllers.Interfaces;
using Ecommerce_webApi.Models.Controllers.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer; //ControllerBase

namespace Ecommerce_webApi.Models.Controllers
{
    [ApiController] //for this api controller
    [Route("v1/api/categories/")]  //entring path, default common path for all request
    public class CategoryController:ControllerBase
    {
      private ICategoryService _categoryService;  //_categoryService is a variable which type of CategoryService

        public CategoryController(CategoryService categoryService)    //categoryService is variable . here type is CategoryService
        {
           //_categoryService = new CategoryService();
           _categoryService = categoryService;         //here 2 line is same.this is done by different path.which name is dependency injection
        }

        #region  MapGet
       //GET :/api/categories => Read categories
       [HttpGet]
         public IActionResult GetCategories()  
        {
        var categoryList = _categoryService.GetAllCategories(); 
        return Ok(ApiReponse<List<CategoryReadDto>>.SuccessResponse(categoryList,200,"Category returned successgully"));
        }
   #endregion

        // //GET: /api/categories/{categoryId} => Read a category by Id
        // [HttpGet("{categoryId:guid}")]
        // public IActionResult GetCategoryById(Guid categoryId)
        //     {
        //         var foundCategory = categories.FirstOrDefault(c => c.CategoryId == categoryId);

        //         if(foundCategory == null)
        //         {
        //             return NotFound(ApiReponse<object>.ErrorResponse(new List<string>
        //             {"Category with this ID does not exist"},404,"validation failed"));
        //         }

        //         var categoryReadDto  = new CategoryReadDto
        //         {
        //             categoryId = foundCategory.CategoryId,
        //             Name = foundCategory.Name,
        //             Description = foundCategory.Description,
        //             CreateAdt = foundCategory.CreateAdt
        //         };


        //         return Ok(ApiReponse<CategoryReadDto>.SuccessResponse(categoryReadDto,200,"Categories is returned successfully"));
        

        // #region MapPost
        //POST::: /api/categories => Create a category
        // [HttpPost]
        public  IActionResult CreateCategory([FromBody] CategoryCrieateDto categoryData)
        {
            
        }
           
    
    //     #region MapPut

    //   //put : /api / categories/{categoryId} => update a category
    //   [HttpPut("{categoryId:guid}")]
    //   public IActionResult UpdateCategoryById(Guid categoryId,[FromBody] CategoryUpdateDto categoryData)
    //   {
        
    //     var foundCategory = categories.FirstOrDefault(Category => Category.CategoryId == categoryId);
    //     if(foundCategory == null)
    //     {
    //         return NotFound(ApiReponse<object>.ErrorResponse(new List<string>
    //         {"Category with this ID does not exist"},404,"validation failed"));
    //     }
    //             foundCategory.Name = categoryData.Name;
    //             foundCategory.Description = categoryData.Description;
               
    //             return Ok(ApiReponse<object>.SuccessResponse(null,204,"Category Update successfully"));
    //   }
    //     #endregion
    
    //     #region  MapDelete   
    //     //Delete:/api/cagegories/{categoryId} => Delete a category by Id
    //     [HttpDelete("{categoryId:guid}")]
    //     public IActionResult DeleteCategoryById(Guid categoryId)
    //     {
    //         var foundCategory = categories.FirstOrDefault(Category => Category.CategoryId == categoryId);

    //        if(foundCategory == null)
    //        {
    //            return NotFound(ApiReponse<object>.ErrorResponse(new List<string> {"Category with this ID does not exist "},404,"validation failed"));
    //        }
    //        categories.Remove(foundCategory);      
    //        return Ok(ApiReponse<object>.SuccessResponse(null,204,"Category deleted successfully"));
    //       }
    //     }
    //       #endregion
     }
    }
