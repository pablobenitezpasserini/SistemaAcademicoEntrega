using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.AccesoDatos;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using SistemaAcademico.Services;

namespace SistemaAcademico.Pages.Carreras
{
	public class EliminarCarreraModel : PageModel
	{
		[BindProperty]
		public Carrera oCarrera { get; set; }
		private readonly ServicioCarrera oServicioCarrera;

		public EliminarCarreraModel()
		{
            IAccesoDatos<Carrera> acceso = new AccesoDatos<Carrera>("Carreras");
            IRepository<Carrera> repo = new RepositorioCrudJson<Carrera>(acceso);
            oServicioCarrera = new ServicioCarrera(repo);
        }
		public IActionResult OnGet(int id)
		{
			var carrera = oServicioCarrera.BuscarPorId(id);

			if (carrera == null) 
			{
				return RedirectToPage("Index");
			}

			oCarrera = carrera;
			return Page();
		}

		public IActionResult OnPost()
		{
			oServicioCarrera.EliminarPorId(oCarrera.Id);

			return RedirectToPage("TablaCarreras");
		}
	}
}
