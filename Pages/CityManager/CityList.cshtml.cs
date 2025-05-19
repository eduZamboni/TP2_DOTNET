using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace TP2.Pages.CityManager
{
    public class CityListModel : PageModel
    {
        public List<string> Cities { get; private set; }

        public CityListModel()
        {
            Cities = new List<string> { "Rio", "São Paulo", "Brasília" };
        }

        public void OnGet()
        {
            // A lista de cidades é inicializada no construtor
        }
    }
}