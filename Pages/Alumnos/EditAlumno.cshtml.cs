using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
using SistemaAcademico.Services;

namespace SistemaAcademico.Pages.Alumnos
{
	public class EditAlumnoModel : PageModel
	{
		[BindProperty]
		public Alumno oAlumno { get; set; }
		public void OnGet(int id)
		{
			Alumno? alumno = ServicioAlumno.BuscarPorId(id);

			if(alumno != null) 
			{
				oAlumno = alumno;
			}
		}
		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			ServicioAlumno.EditarAlumno(oAlumno);
			
			return RedirectToPage("TablaAlumnos");
		}
	}
}
