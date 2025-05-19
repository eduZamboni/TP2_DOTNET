using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TP2.Pages.CityManager
{
    public class CityDetailsModel : PageModel
    {
        public string CityName { get; private set; } = string.Empty;

        public void OnGet(string cityName)
        {
            // Recebendo o parâmetro diretamente no método
            CityName = cityName;
            
            // Alternativamente, poderíamos usar:
            // CityName = RouteData.Values["cityName"]?.ToString() ?? string.Empty;
        }
    }
}