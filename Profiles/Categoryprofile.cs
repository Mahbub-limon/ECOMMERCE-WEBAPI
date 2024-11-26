using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce_webApi.DTOs;
using Ecommerce_webApi.Models;

namespace Ecommerce_webApi.Profiles
{
    public class Categoryprofile : Profile
    {
        public Categoryprofile(){  //Constructor 
            //have to define Mapping
            CreateMap<Category,CategoryReadDto>();  // model to DTO
            CreateMap<CategoryCrieateDto,Category>();
            CreateMap<CategoryUpdateDto,Category>();
        }
    }
}