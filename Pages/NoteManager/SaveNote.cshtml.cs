using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;

namespace TP2.Pages.NoteManager
{
    public class SaveNoteModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SaveNoteModel(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public bool NoteIsSaved { get; private set; }
        public string SavedFileName { get; private set; } = string.Empty;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var filesDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "files");
                if (!Directory.Exists(filesDirectory))
                {
                    Directory.CreateDirectory(filesDirectory);
                }

                var timestamp = DateTime.Now.ToString("yyyyMMdd-HHmmss");
                SavedFileName = $"note-{timestamp}.txt";
                
                var filePath = Path.Combine(filesDirectory, SavedFileName);

                await System.IO.File.WriteAllTextAsync(filePath, Input.Content);

                NoteIsSaved = true;
                
                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Erro ao salvar o arquivo: {ex.Message}");
                return Page();
            }
        }

        public class InputModel
        {
            [Required(ErrorMessage = "O conteúdo da nota é obrigatório.")]
            [Display(Name = "Conteúdo da Nota")]
            public string Content { get; set; } = string.Empty;
        }
    }
}