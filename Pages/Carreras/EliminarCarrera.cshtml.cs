using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
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
			oServicioCarrera = new ServicioCarrera();
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
