using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public Restaurant Restaurant { get; set; }

        [TempData]
        public string Message { get; set; }

        public DetailModel(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public IActionResult OnGet(int id)
        {
            Restaurant = _restaurantRepository.GetById(id);

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}