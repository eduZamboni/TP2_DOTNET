using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TP2.Pages.CityManager
{
    public class CreateCityModel : PageModel
    {
        public string? CityName { get; private set; }
        public bool Submitted { get; private set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
            {
                ModelState.AddModelError(nameof(cityName), "O nome da cidade é obrigatório.");
                return Page();
            }

            CityName = cityName;
            Submitted = true;

            return Page();
        }
    }
}