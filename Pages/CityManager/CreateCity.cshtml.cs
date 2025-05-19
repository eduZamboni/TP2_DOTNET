using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TP2.Pages.CityManager
{
    public class CreateCityModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
        public string? CityName { get; set; }

        public bool Submitted { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Submitted = true;
            return Page();
        }
    }
}