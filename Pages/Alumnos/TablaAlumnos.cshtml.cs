using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
using SistemaAcademico.Services;

namespace SistemaAcademico.Pages.Alumnos
{
    public class TablaAlumnosModel : PageModel
    {
		public List<Alumno> listaAlumnosMotrar;
		public void OnGet()
		{
			listaAlumnosMotrar = ServicioAlumno.ObtenerAlumnos();
		}
	}
}
