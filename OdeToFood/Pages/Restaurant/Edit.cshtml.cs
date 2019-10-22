using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurant
{
    public class EditModel : PageModel
    {
        private IHtmlHelper HtmlHelper { get; set; }
        private IRestaurantData restaurantData;

        [BindProperty]
        public Core.Restaurant restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData data, IHtmlHelper htmlHelper)
        {
            restaurantData = data;
            HtmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restaurantId)
        {

            Cuisines = HtmlHelper.GetEnumSelectList<CuisineType>();

            if (restaurantId.HasValue)
                restaurant = restaurantData.GetRestaurantById(restaurantId.Value);
            else
            {
                restaurant = new Core.Restaurant();
                
            }

            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) // populate the page. 
            {
                Cuisines = HtmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if (restaurant.Id > 0) // edit existing new restaurant 
            {
                restaurant = restaurantData.Update(restaurant);
            }
            else // add a new restaurant 
            {
                restaurantData.Add(restaurant);
            }

            restaurantData.Commit();
            TempData["Message"] = "Restaurant saved!";
            return RedirectToPage("./Detail", new { restaurantId = restaurant.Id});          
        }
    }
}