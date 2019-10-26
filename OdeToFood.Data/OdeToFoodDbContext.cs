using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        // installed entityframeworkcore and entityframeworkcore.design, entityframeworkcore.sql in NuGet packages (v2.1.4)

        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options) 
            : base(options)
        {

        }
        public DbSet<Restaurant> Restaurant { get; set; }

        //enable-migration
        //add-migration [name]
        // update-database
    }
}
