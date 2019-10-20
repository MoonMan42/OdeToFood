using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurant
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public OdeToFood.Core.Restaurant restaurant { get; set; }

        public DetailModel(IRestaurantData data)
        {
            this.restaurantData = data;
        }
        public IActionResult OnGet(int restaurantId)
        {
            restaurant = restaurantData.GetRestaurantById(restaurantId);
            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}