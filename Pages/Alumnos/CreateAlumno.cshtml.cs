using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.AccesoDatos;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
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
            IAccesoDatos<Alumno> acceso = new AccesoDatos<Alumno>("Alumnos");
            IRepository<Alumno> repo = new RepositorioCrudJson<Alumno>(acceso);
            oServicioAlumno = new ServicioAlumno(repo);
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
