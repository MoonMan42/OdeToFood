using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurant
{
    public class DeleteModel : PageModel
    {
        private IRestaurantData restaurantData;


        public Core.Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantData data)
        {
            this.restaurantData = data;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetRestaurantById(restaurantId);

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            var restaurant = restaurantData.Delete(restaurantId);
            restaurantData.Commit();

            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{restaurant.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}