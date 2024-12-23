using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Ecommerce_webApi.DTOs;
using Ecommerce_webApi.Helpers;
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
       //GET :/api/categories?pageNumber=2&& pageSize =5  
       [HttpGet]
         public async Task<IActionResult> GetCategories([FromQuery] QueryParameters queryParameters)  
        {
          //validate the query parameters
        queryParameters.Validate();
        var categoryList = await _categoryService.GetAllCategories(queryParameters); 
        return Ok(ApiReponse<PaginatedResult<CategoryReadDto>>.SuccessResponse(categoryList,200,"Category returned successgully"));
        }
      #endregion

      //Get:/api/categories /{categoryId} => Read a category by Id
      [HttpGet("{vategoryId:guid}")]
      public async Task<IActionResult> GetCategoryById(Guid categoryId)
      {
        var category =await _categoryService.GetCategoryById(categoryId);
        if(category == null)
        {
          return NotFound(ApiReponse<object>.ErrorResponse(new List<string> {"Category with this ID does not exist"},404 ,"validation failed"));
        }

        return Ok(ApiReponse<CategoryReadDto>.SuccessResponse(category,200,"Category is returned successfully"));
      }

      //post : /api/categories => Create a category 
      [HttpPost]
      public async Task<IActionResult> CreateCategory([FromBody] CategoryCrieateDto categoryData)
      {
        var CategoryReadDto = await _categoryService.CreateCategory(categoryData);

        return Created(nameof(GetCategoryById),ApiReponse<CategoryReadDto>.SuccessResponse(CategoryReadDto,201,"Category created successfully")); 
      }
      
      //PUT : /api/categories/{categoryId} => Update a category
      [HttpPut("{categoryId : guid}")]
      public async Task<IActionResult> UpdateCategoryById(Guid categoryId,[FromBody] CategoryUpdateDto categoryData)
      {
        var updateCategory = await _categoryService.UpdateCategoryById(categoryId,categoryData);
        if(updateCategory == null)
        {
          return NotFound(ApiReponse<object>.ErrorResponse(new List<string>{"Category with this ID does not exist"},404,"validation failed"));
        }
        return Ok(ApiReponse<CategoryReadDto>.SuccessResponse(updateCategory,200,"Category Update successfully"));
      }


      //Delete : /api/Categories/{categoryId} => Delete a category by id
      [HttpDelete("{catetegory:guid}")]
      public async Task<IActionResult> DeleteCategoryById(Guid categoryId)
      {
        var foundCategory = await _categoryService.DeleteCategoryById(categoryId);
        if(!foundCategory)
        {
          return NotFound(ApiReponse<object>.ErrorResponse(new List<string> {"Category with this ID does not exist "},404,"validation failed"));
        }

        return Ok(ApiReponse<object>.SuccessResponse(null,204,"Category deleted successfully"));

      }
     }
    }
