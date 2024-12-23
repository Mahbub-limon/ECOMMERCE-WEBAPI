using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_webApi.DTOs;
using Ecommerce_webApi.Helpers;

namespace Ecommerce_webApi.Models.Controllers.Interfaces
{
    public interface ICategoryService
    {
         Task<PaginatedResult<CategoryReadDto>> GetAllCategories(QueryParameters queryParameters);
         Task<CategoryReadDto?>  GetCategoryById(Guid categoryId);
         Task<CategoryReadDto> CreateCategory (CategoryCrieateDto categoryData);
         Task<CategoryReadDto ?> UpdateCategoryById(Guid categoryId, CategoryUpdateDto categoryData);    //Abstrach Category
         Task<bool> DeleteCategoryById(Guid categoryId);
    }
}