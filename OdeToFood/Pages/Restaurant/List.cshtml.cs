using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;
using OdeToFood.Core;

namespace OdeToFood.Pages.Restaurant
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantData restaurant;
        public IEnumerable<OdeToFood.Core.Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IRestaurantData restaurant)
        {
            this.restaurant = restaurant;
        }

        public void OnGet()
        {            
            Restaurants = restaurant.GetRestaurantByName(SearchTerm);
        }
       
    }
}