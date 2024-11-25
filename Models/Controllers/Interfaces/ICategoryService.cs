using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_webApi.DTOs;

namespace Ecommerce_webApi.Models.Controllers.Interfaces
{
    public interface ICategoryService
    {
         List<CategoryReadDto>GetAllCategories();

         CategoryReadDto? GetCategoryById(Guid categoryId);
         CategoryReadDto CreateCategory (CategoryCrieateDto categoryData);

     CategoryReadDto ? UpdateCategoryById(Guid categoryId, CategoryUpdateDto categoryData);    //Abstrach Category
    bool DeleteCategoryById(Guid categoryId);
    }
}