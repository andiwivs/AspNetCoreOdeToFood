using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IRestaurantRepository _restaurantRepository;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public ListModel(IConfiguration config, IRestaurantRepository restaurantRepository)
        {
            _config = config;
            _restaurantRepository = restaurantRepository;
        }

        public void OnGet()
        {
            Message = _config["RestaurantsMessage"];
            Restaurants = _restaurantRepository.GetByName(SearchTerm);
        }
    }
}