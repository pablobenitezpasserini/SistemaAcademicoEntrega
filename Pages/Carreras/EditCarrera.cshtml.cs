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
		[BindProperty]
		public Carrera oCarrera { get; set; }
		public List<string> Modalidades = new List<string>();
		private readonly ServicioCarrera oServicioCarrera;

		public EditCarreraModel()
		{
			oServicioCarrera = new ServicioCarrera();
		}
		public void OnGet(int id)
		{
			Modalidades = OpcionesModalidad.lista;

			Carrera? carrera = oServicioCarrera.BuscarPorId(id);

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
			
			oServicioCarrera.Editar(oCarrera);

			return RedirectToPage("TablaCarreras");
		}

	}
}
