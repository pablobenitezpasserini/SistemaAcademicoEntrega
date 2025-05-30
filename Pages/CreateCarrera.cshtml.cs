using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Models;


namespace SistemaAcademico.Pages
{
    public class CreateCarreraModel : PageModel
    {
        [BindProperty]
        public Carrera oCarrera { get; set; }
        public void OnGet(){}

        public static int ultimoId = 0;

        public IActionResult OnPost() {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            oCarrera.Id = DatosCompartidos.ObtenerNuevoId();
            DatosCompartidos.ListCarrera.Add(oCarrera);
            return RedirectToPage("TablaCarreras");
        }
    }
}
