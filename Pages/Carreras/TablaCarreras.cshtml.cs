using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.AccesoDatos;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using SistemaAcademico.Services;

namespace SistemaAcademico.Pages.Carreras
{
	// aguanten las facturas
	public class TablaCarrerasModel : PageModel
	{
		public List<Carrera> ListaMostrarCarrera;
		private readonly ServicioCarrera oServicioCarrera;
		public TablaCarrerasModel()
		{
            IAccesoDatos<Carrera> acceso = new AccesoDatos<Carrera>("Carreras");
            IRepository<Carrera> repo = new RepositorioCrudJson<Carrera>(acceso);
            oServicioCarrera = new ServicioCarrera(repo);
        }
		public void OnGet()
		{
			ListaMostrarCarrera = oServicioCarrera.ObtenerTodos();
		}

	}
}
