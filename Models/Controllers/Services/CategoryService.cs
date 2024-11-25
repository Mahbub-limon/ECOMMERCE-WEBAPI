using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_webApi.DTOs;
using Ecommerce_webApi.Models.Controllers.Interfaces;

namespace Ecommerce_webApi.Models.Controllers.Services
{
    //controller => Service => database
    public class CategoryService : ICategoryService 
    {
         private static readonly List<Category> _categories = new List<Category>();  //like as an object for Category model
    
        //Model <==> DTO
         public List<CategoryReadDto> GetAllCategories()   //all category replayed
         {
            return _categories.Select(c => new CategoryReadDto
            {
                categoryId  = c.CategoryId,
                Name = c.Name,
                Description = c.Description,
                CreateAdt = c.CreateAdt
            }).ToList();
         }

         public CategoryReadDto? GetCategoryById(Guid categoryId)
         {
            var foundCategory = _categories.FirstOrDefault(c => c.CategoryId == categoryId);

            if(foundCategory == null)
            {
                return null;
            }
            return new CategoryReadDto
            {
                categoryId = foundCategory.CategoryId,
                Name = foundCategory.Name,
                Description = foundCategory.Description,
                CreateAdt = foundCategory.CreateAdt
            };
        }

    public CategoryReadDto CreateCategory (CategoryCrieateDto categoryData)
    {
        var newCategory = new Category
        {
            CategoryId = Guid.NewGuid(),
            Name = categoryData.Name,
            Description = categoryData.Description,
            CreateAdt = DateTime.UtcNow
        };

        _categories.Add(newCategory);

        return new CategoryReadDto
        {
            categoryId = newCategory.CategoryId,
            Name  = newCategory.Name,
            Description = newCategory.Description,
            CreateAdt = newCategory.CreateAdt,
        };
    }
    public CategoryReadDto ? UpdateCategoryById(Guid categoryId, CategoryUpdateDto categoryData)
    {
        var foundCategory = _categories.FirstOrDefault(Category => Category.
        CategoryId == categoryId);

        if(foundCategory == null)
        {
            return null;
        }
             
            foundCategory.Name = categoryData.Name;
            foundCategory.Description = categoryData.Description;

            return new CategoryReadDto
            {
                categoryId = foundCategory.CategoryId,
                Name = foundCategory.Name,
                Description = foundCategory.Description,
                CreateAdt = foundCategory.CreateAdt
            };
    }

            public bool DeleteCategoryById(Guid categoryId)
            {
                var foundCategory = _categories.FirstOrDefault(category => category.
                CategoryId == categoryId);

                if(foundCategory == null)
                {
                    return false;
                }

                _categories.Remove(foundCategory);
                return true;
            }
    }
}         
