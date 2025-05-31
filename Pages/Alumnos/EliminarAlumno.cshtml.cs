using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Models;

namespace SistemaAcademico.Pages.Alumnos
{
    public class EliminarAlumnoModel : PageModel
    {
		[BindProperty]
		public Alumno oAlumno { get; set; }
		public void OnGet(int id)
		{
			foreach (var alumno in DatosCompartidos.ListaAlumnos)
			{
				if (alumno.Id == id)
				{
					oAlumno = alumno;
					break;
				}

			}
		}

		public IActionResult OnPost()
		{
			Alumno eliminarAlumno = null;

			foreach (var alumno in DatosCompartidos.ListaAlumnos)
			{
				if (alumno.Id == oAlumno.Id)
				{
					eliminarAlumno = alumno;
					break;
				}
			}

			if (eliminarAlumno != null)
			{
				DatosCompartidos.ListaAlumnos.Remove(eliminarAlumno);
			}

			return RedirectToPage("TablaAlumnos");
		}
	}
}
