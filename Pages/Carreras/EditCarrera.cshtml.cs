using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Helpers;
using SistemaAcademico.Models;
using SistemaAcademico.Services;

namespace SistemaAcademico.Pages.Carreras
{
	public class EditCarreraModel : PageModel
	{
		public List<string> Modalidades = new List<string>();
		[BindProperty]
		public Carrera oCarrera { get; set; }
		public void OnGet(int id)
		{
			Modalidades = OpcionesModalidad.lista;

			Carrera? carrera = ServicioCarrera.BuscarPorId(id);
			if (carrera != null)
			{
				oCarrera = carrera;
			}
		}
		public IActionResult OnPost()
		{
            Modalidades = OpcionesModalidad.lista;

            if (!ModelState.IsValid)
			{
				return Page();
			}
			
			ServicioCarrera.EditarCarrera(oCarrera);

			return RedirectToPage("TablaCarreras");
		}

	}
}
