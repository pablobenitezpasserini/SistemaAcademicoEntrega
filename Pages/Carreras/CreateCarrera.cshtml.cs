using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.AccesoDatos;
using SistemaAcademico.Data;
using SistemaAcademico.Helpers;
using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using SistemaAcademico.Services;


namespace SistemaAcademico.Pages.Carreras
{
	public class CreateCarreraModel : PageModel
	{
		[BindProperty]
		public Carrera oCarrera { get; set; }
		public List<string> Modalidades {  get; set; } = new List<string>();
		private readonly ServicioCarrera oServicioCarrera;

		public CreateCarreraModel()
		{
			IAccesoDatos<Carrera> acceso = new AccesoDatos<Carrera>("Carreras");
			IRepository<Carrera> repo = new RepositorioCrudJson<Carrera>(acceso);
			oServicioCarrera = new ServicioCarrera(repo);
		}
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

			oServicioCarrera.Agregar(oCarrera);

			return RedirectToPage("TablaCarreras");
		}
	}
}
