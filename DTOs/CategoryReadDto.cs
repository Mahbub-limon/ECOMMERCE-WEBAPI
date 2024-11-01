using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_webApi.DTOs
{
    public class CategoryReadDto
    {
        public Guid categoryId {get ; set;}
        public string? Name {get; set;}
        public string? Description {get; set;} = string.Empty;
        public DateTime CreateAdt{get; set;}
    }
}