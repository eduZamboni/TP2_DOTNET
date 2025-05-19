using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TP2.Pages.NoteManager
{
    public class ViewNotesModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ViewNotesModel(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public List<FileInfo> NoteFiles { get; private set; } = new List<FileInfo>();
        public string SelectedFileName { get; private set; } = string.Empty;
        public string FileContent { get; private set; } = string.Empty;
        public string ErrorMessage { get; private set; } = string.Empty;

        public IActionResult OnGet(string fileName = "")
        {
            try
            {
                // Caminho para o diretório de arquivos
                var filesDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "files");

                // Obtém todos os arquivos .txt no diretório
                var directoryInfo = new DirectoryInfo(filesDirectory);
                NoteFiles = directoryInfo.GetFiles("*.txt")
                                       .OrderByDescending(f => f.LastWriteTime)
                                       .ToList();

                if (!string.IsNullOrEmpty(fileName))
                {
                    SelectedFileName = fileName;
                    var filePath = Path.Combine(filesDirectory, fileName);
                    
                    if (System.IO.File.Exists(filePath) && Path.GetDirectoryName(filePath) == filesDirectory)
                    {
                        FileContent = System.IO.File.ReadAllText(filePath);
                    }
                    else
                    {
                        ErrorMessage = "O arquivo solicitado não existe.";
                    }
                }

                return Page();
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Erro ao acessar os arquivos: {ex.Message}";
                return Page();
            }
        }
    }
}