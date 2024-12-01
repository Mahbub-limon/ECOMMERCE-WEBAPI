using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_webApi.Models.data
{
    public class AppDbContext : DbContext  // DbContext inheraite to the AppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)   //have to do
        {

        }
        //Table Creating from Model which name is Category Model
        public DbSet<Category> Categories {get;set;}

    }
}