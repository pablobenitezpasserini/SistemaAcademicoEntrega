using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Helpers;
using SistemaAcademico.Models;

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

			foreach (var carrera in DatosCompartidos.ListCarreras)
			{
				if (carrera.Id == id)
				{
					oCarrera = carrera;
					break;
				}
			}
		}
		public IActionResult OnPost()
		{
            Modalidades = OpcionesModalidad.lista;

            if (!ModelState.IsValid)
			{
				return Page();
			}

			foreach (var carrera in DatosCompartidos.ListCarreras)
			{
				if (carrera.Id == oCarrera.Id)
				{
					carrera.Nombre = oCarrera.Nombre;
					carrera.Modalidad = oCarrera.Modalidad;
					carrera.DuracionAnios = oCarrera.DuracionAnios;
					carrera.TituloOtorgado = oCarrera.TituloOtorgado;
					break;
				}
			}
			return RedirectToPage("TablaCarreras");
		}

	}
}
