using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty(SupportsGet = true)]
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> CuisineOptions { get; set; }

        public EditModel(IRestaurantRepository restaurantRepository, IHtmlHelper htmlHelper)
        {
            _restaurantRepository = restaurantRepository;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? id)
        {
            CuisineOptions = _htmlHelper.GetEnumSelectList<CuisineType>();

            if (id.HasValue)
            {
                // update
                Restaurant = _restaurantRepository.GetById(id.Value);

                if (Restaurant == null)
                    return RedirectToPage("./NotFound");
            }
            else
            {
                // create
                Restaurant = new Restaurant();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                CuisineOptions = _htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            Restaurant = Restaurant.Id > 0 
                ? _restaurantRepository.Update(Restaurant) 
                : _restaurantRepository.Create(Restaurant);

            _restaurantRepository.SaveChanges();

            TempData["Message"] = "Restaurant saved!";

            return RedirectToPage("./Detail", new { id = Restaurant.Id });
        }
    }
}