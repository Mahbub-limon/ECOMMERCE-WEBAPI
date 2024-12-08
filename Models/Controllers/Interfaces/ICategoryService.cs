using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_webApi.DTOs;

namespace Ecommerce_webApi.Models.Controllers.Interfaces
{
    public interface ICategoryService
    {
         Task<List<CategoryReadDto>> GetAllCategories();
         Task<CategoryReadDto?>  GetCategoryById(Guid categoryId);
         Task<CategoryReadDto> CreateCategory (CategoryCrieateDto categoryData);
         Task<CategoryReadDto ?> UpdateCategoryById(Guid categoryId, CategoryUpdateDto categoryData);    //Abstrach Category
         Task<bool> DeleteCategoryById(Guid categoryId);
    }
}