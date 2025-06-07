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
		public void OnGet()
		{
			ListaMostrarCarrera = ServicioCarrera.ObtenerCarreras();
		}

	}
}
