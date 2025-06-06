using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TP2.Pages.CityManager
{
    public class CreateCityModel : PageModel
    {
        [BindProperty]
        public required InputModel Input { get; set; }
        public bool Submitted { get; private set; }

        public void OnGet()
        {
            Input = new InputModel();
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

        public class InputModel
        {
            [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
            [MinLength(3, ErrorMessage = "O nome da cidade deve ter ao menos 3 caracteres.")]
            [Display(Name = "Nome da Cidade")]
            public string CityName { get; set; } = string.Empty;
        }
    }
}