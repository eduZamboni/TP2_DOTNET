using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TP2.Pages.CountryManager
{
    // Classe de domínio Country
    public class Country
    {
        public string CountryName { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
    }

    public class CreateCountryModel : PageModel
    {
        [BindProperty]
        public required InputModel Input { get; set; }
        public bool Submitted { get; private set; }
        public Country? CreatedCountry { get; private set; }

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

            // Criar instância de Country a partir do InputModel
            CreatedCountry = new Country
            {
                CountryName = Input.CountryName,
                CountryCode = Input.CountryCode
            };
            
            Submitted = true;
            return Page();
        }

        public class InputModel
        {
            [Required(ErrorMessage = "O nome do país é obrigatório.")]
            [MinLength(3, ErrorMessage = "O nome do país deve ter ao menos 3 caracteres.")]
            [Display(Name = "Nome do País")]
            public string CountryName { get; set; } = string.Empty;
            
            [Required(ErrorMessage = "O código do país é obrigatório.")]
            [StringLength(2, MinimumLength = 2, ErrorMessage = "O código do país deve ter exatamente 2 caracteres.")]
            [Display(Name = "Código do País (ISO)")]
            public string CountryCode { get; set; } = string.Empty;
        }
    }
}