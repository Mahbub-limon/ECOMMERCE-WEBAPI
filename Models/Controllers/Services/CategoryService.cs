using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce_webApi.DTOs;
using Ecommerce_webApi.Models.Controllers.Interfaces;
using Ecommerce_webApi.Models.data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_webApi.Models.Controllers.Services
{
    //controller => Service => database
    public class CategoryService : ICategoryService 
    {
        //  private static readonly List<Category> _categories = new List<Category>();  //like as an object for Category model  //inmemory data  

        private readonly AppDbContext _appDbContext; //appDbContext is a variable and wich type is AppDbContext

        private readonly IMapper _mapper;  //Here _mapper is the variable of IMapper

        public CategoryService(AppDbContext appDbContext,IMapper mapper) //Dependence injection
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        //Model <==> DTO
         public async Task<CategoryReadDto? > GetAllCategories()   //all category replayed
         {  

            var categories = await _appDbContext.Categories.ToListAsync();  //searching data to database

            return _mapper.Map<List<CategoryReadDto>>(categories);  //Converting _categories to CategoryRedDTO
        }

         public async Task<CategoryReadDto?> GetCategoryById(Guid categoryId)
         {
            var foundCategory =await  _appDbContext.Categories.FirstOrDefault(c => c.CategoryId == categoryId);

        return foundCategory == null ? null : _mapper.Map<CategoryReadDto>(foundCategory);
            
        }

    public async Task<CategoryReadDto> CreateCategory (CategoryCrieateDto categoryData)
    {
        //CategoryCreateDto  => Category

        var newCategory =_mapper.Map<Category>(categoryData);
        newCategory.CategoryId = Guid.NewGuid();
        newCategory.Description = categoryData.Description;
        await _appDbContext.Categories.AddAsync(newCategory);  //datga ready for inserting table
        await _appDbContext.SaveChangesAsync(); // finally save in the table
        return _mapper.Map<CategoryReadDto>(newCategory);

    }
    public async Task<CategoryReadDto ?> UpdateCategoryById(Guid categoryId, CategoryUpdateDto categoryData)
    {
        var foundCategory = await _appDbContext.Categories.FirstOrDefault(Category => Category.CategoryId == categoryId);

        if(foundCategory == null)
        {
            return null;
        }
            
            //CategoryUpdateDto => Category
            _mapper.Map(categoryData,foundCategory); //Convertting categoryData to foundCategory
            await _appDbContext.SaveChangesAsync();

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
