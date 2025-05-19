using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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
        public List<InputModel> Inputs { get; set; } = new List<InputModel>();
        public bool Submitted { get; private set; }
        public List<Country> CreatedCountries { get; private set; } = new List<Country>();

        public void OnGet()
        {
            Inputs = Enumerable.Range(0, 5).Select(_ => new InputModel()).ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Criar instância de Country a partir do InputModel
            CreatedCountries = new List<Country>();
            foreach (
                var input in Inputs.Where(
                    i => !string.IsNullOrWhiteSpace(i.CountryName) && !string.IsNullOrWhiteSpace(i.CountryCode)
                    )
                )

            {
                CreatedCountries.Add(new Country
                {
                    CountryName = input.CountryName,
                    CountryCode = input.CountryCode
                });
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