using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.AccesoDatos;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using SistemaAcademico.Services;

namespace SistemaAcademico.Pages.Alumnos
{
    public class EliminarAlumnoModel : PageModel
    {
		[BindProperty]
		public Alumno oAlumno { get; set; }
		private readonly ServicioAlumno oServicioAlumno;
		public EliminarAlumnoModel()
		{
            IAccesoDatos<Alumno> acceso = new AccesoDatos<Alumno>("Alumnos");
            IRepository<Alumno> repo = new RepositorioCrudJson<Alumno>(acceso);
            oServicioAlumno = new ServicioAlumno(repo);
        }

		public IActionResult OnGet(int id)
		{
			var alumno = oServicioAlumno.BuscarPorId(id);
			if (alumno == null)
			{
				return RedirectToPage("Index");
			}

			oAlumno = alumno;
			return Page();
		}

		public IActionResult OnPost()
		{
			oServicioAlumno.EliminarPorId(oAlumno.Id);

			return RedirectToPage("TablaAlumnos");
		}
	}
}
