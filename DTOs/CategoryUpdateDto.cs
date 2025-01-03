using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_webApi.DTOs
{
    public class CategoryUpdateDto
    {
         [StringLength(100, MinimumLength =2 ,ErrorMessage ="Category name must be between 2 and 100 character")]
        public string Name {get; set;} =string.Empty;

         [StringLength(500, MinimumLength =2, ErrorMessage = "Category description must be between 2 and 500 character")]
        public string Description {get; set;} = string.Empty;
    }
}