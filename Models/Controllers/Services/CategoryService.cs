using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce_webApi.DTOs;
using Ecommerce_webApi.Models.Controllers.Interfaces;

namespace Ecommerce_webApi.Models.Controllers.Services
{
    //controller => Service => database
    public class CategoryService : ICategoryService 
    {
         private static readonly List<Category> _categories = new List<Category>();  //like as an object for Category model
    
        private readonly IMapper _mapper;  //Here _mapper is the variable of IMapper

        public CategoryService(IMapper mapper)
        {
            _mapper = mapper;
        }

        //Model <==> DTO
         public List<CategoryReadDto> GetAllCategories()   //all category replayed
         {  
            return _mapper.Map<List<CategoryReadDto>>(_categories);  //Converting _categories to CategoryRedDTO
        }

         public CategoryReadDto? GetCategoryById(Guid categoryId)
         {
            var foundCategory = _categories.FirstOrDefault(c => c.CategoryId == categoryId);

        return foundCategory == null ? null : _mapper.Map<CategoryReadDto>(foundCategory);
            
        }

    public CategoryReadDto CreateCategory (CategoryCrieateDto categoryData)
    {
        //CategoryCreateDto  => Category

        var newCategory =_mapper.Map<Category>(categoryData);
        newCategory.CategoryId = Guid.NewGuid();
        newCategory.Description = categoryData.Description;


        _categories.Add(newCategory);

        return _mapper.Map<CategoryReadDto>(newCategory);
    }
    public CategoryReadDto ? UpdateCategoryById(Guid categoryId, CategoryUpdateDto categoryData)
    {
        var foundCategory = _categories.FirstOrDefault(Category => Category.
        CategoryId == categoryId);

        if(foundCategory == null)
        {
            return null;
        }
            

             _mapper.Map(categoryData,foundCategory); //Convertting categoryData to foundCategory

            return _mapper.Map<CategoryReadDto>(foundCategory);
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
