using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.AccesoDatos;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using SistemaAcademico.Services;

namespace SistemaAcademico.Pages.Alumnos
{
    public class TablaAlumnosModel : PageModel
    {
		public List<Alumno> listaAlumnosMotrar;
		private readonly ServicioAlumno oServicioAlumno;
		public TablaAlumnosModel()
		{
            IAccesoDatos<Alumno> acceso = new AccesoDatos<Alumno>("Alumnos");
            IRepository<Alumno> repo = new RepositorioCrudJson<Alumno>(acceso);
            oServicioAlumno = new ServicioAlumno(repo);
        }
		public void OnGet()
		{
			listaAlumnosMotrar = oServicioAlumno.ObtenerTodos();
		}
	}
}
