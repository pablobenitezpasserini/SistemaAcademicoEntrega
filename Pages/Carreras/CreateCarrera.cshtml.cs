using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Models;


namespace SistemaAcademico.Pages.Carreras
{
	public class CreateCarreraModel : PageModel
	{
		[BindProperty]
		public Carrera oCarrera { get; set; }
		public void OnGet() { }

		public IActionResult OnPost()
		{

			if (!ModelState.IsValid)
			{
				return Page();
			}

			oCarrera.Id = DatosCompartidos.ObtenerNuevoCarreraId();
			DatosCompartidos.ListCarreras.Add(oCarrera);
			return RedirectToPage("TablaCarreras");
		}
	}
}
