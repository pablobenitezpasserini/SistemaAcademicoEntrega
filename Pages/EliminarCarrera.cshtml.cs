using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Models;

namespace SistemaAcademico.Pages
{
    public class EliminarCarreraModel : PageModel
    {
        [BindProperty]

        public Carrera oCarrera { get; set; }
        public void OnGet(int id)
        {
            foreach(var carrera  in DatosCompartidos.ListCarrera)
            {
                if(carrera.Id == id)
                {
                    oCarrera = carrera;
                    break;
                }
                    
            }
        }

        public IActionResult OnPost()
        {
            Carrera eliminarCarrera = null;

            foreach(var carrera in DatosCompartidos.ListCarrera){
                if(carrera.Id == oCarrera.Id)
                {
                    eliminarCarrera = carrera;
                    break;
                }
            }

            if(eliminarCarrera != null)
            {
                DatosCompartidos.ListCarrera.Remove(eliminarCarrera);
            }

            return RedirectToPage("TablaCarreras");
        }
    }
}
