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
      
  // #region MapPost
        //POST::: /api/categories => Create a category
        // [HttpPost]
        public  IActionResult CreateCategory([FromBody] CategoryCrieateDto categoryData)
        {
            
        }       
     }
    }
