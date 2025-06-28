using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
using SistemaAcademico.Services;

namespace SistemaAcademico.Pages.Alumnos
{
    public class CreateAlumnoModel : PageModel
    {
		[BindProperty]
		public Alumno oAlumno { get; set; }
		private readonly ServicioAlumno oServicioAlumno;
		public CreateAlumnoModel()
		{
			oServicioAlumno = new ServicioAlumno();
		}
		public void OnGet()
        {
        }

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			oServicioAlumno.Agregar(oAlumno);

			return RedirectToPage("TablaAlumnos");
		}
	}
}
