using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_webApi.Models.Controllers
{
    public class PaginatedResult<T>
    {
        public IEnumerable<T> Items {get ; set; } = new List<T>();

        public int TotalCount {get ; set;}

        public int PageNumber {get ; set;}
        public int pageSize {get ; set;}

    }
}