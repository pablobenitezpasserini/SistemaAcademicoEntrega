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
		public void OnGet()
        {
        }

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			ServicioAlumno.AgregarAlumno(oAlumno);

			return RedirectToPage("TablaAlumnos");
		}
	}
}
