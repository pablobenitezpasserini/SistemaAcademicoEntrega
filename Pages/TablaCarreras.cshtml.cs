using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Models;

namespace SistemaAcademico.Pages
{
    public class TablaCarrerasModel : PageModel
    {
        public List<Carrera> ListaMostrarCarrera;
        public void OnGet()
        {
            ListaMostrarCarrera = DatosCompartidos.ListCarrera;
        }

    }
}
