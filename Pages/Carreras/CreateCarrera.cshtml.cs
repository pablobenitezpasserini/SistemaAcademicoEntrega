using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Helpers;
using SistemaAcademico.Models;
using SistemaAcademico.Services;


namespace SistemaAcademico.Pages.Carreras
{
	public class CreateCarreraModel : PageModel
	{
		public List<string> Modalidades {  get; set; } = new List<string>();

		[BindProperty]
		public Carrera oCarrera { get; set; }
		public void OnGet() 
		{
			Modalidades = OpcionesModalidad.lista;
		}

		public IActionResult OnPost()
		{
			Modalidades = OpcionesModalidad.lista;

			if (!ModelState.IsValid)
			{
				return Page();
			}


			ServicioCarrera.AgregarCarrera(oCarrera);
			/*oCarrera.Id = DatosCompartidos.ObtenerNuevoCarreraId();
			DatosCompartidos.ListCarreras.Add(oCarrera);*/

			return RedirectToPage("TablaCarreras");
		}
	}
}
