using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_webApi.Helpers
{
    public class QueryParameters
    {
        private const int MaxPageSize = 50;
       // [FromQuery] int pageNumber = 1 ,[FromQuery] int pageSize = 6,[FromQuery] string? search = null,[FromQuery] string? sortOrder = null

        public int pageNumber {get; set;} =1;
        public int PageSize {get; set;} =6;
        public string? Search {get; set;}
        public string? sortOrder {get;set;}


        public QueryParameters Validate(){
            if(pageNumber < 1)
            {
                pageNumber =1;
            }
            if(PageSize <1)
            {
                PageSize = 6;
            }
            if(PageSize > MaxPageSize)
            {
                PageSize = MaxPageSize;
            }
            return this;
        }



    }
}