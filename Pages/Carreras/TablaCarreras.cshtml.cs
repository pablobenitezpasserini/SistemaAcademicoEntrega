using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
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
			oServicioCarrera = new ServicioCarrera();
		}
		public void OnGet()
		{
			ListaMostrarCarrera = oServicioCarrera.ObtenerTodos();
		}

	}
}
