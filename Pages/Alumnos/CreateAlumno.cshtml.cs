using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Models;

namespace SistemaAcademico.Pages.Alumnos
{
    public class CreateAlumnoModel : PageModel
    {
        public void OnGet()
        {
        }

		[BindProperty]
		public Alumno oAlumno { get; set; }

		public IActionResult OnPost()
		{
			if (DatosCompartidos.ListaAlumnos.Any(alumno => alumno.Email == oAlumno.Email))
			{
				ModelState.AddModelError("oAlumno.Email", "El correo electrónico ya está registrado.");
			}

			if (DatosCompartidos.ListaAlumnos.Any(alumno => alumno.Dni == oAlumno.Dni))
			{
				ModelState.AddModelError("oAlumno.Dni", "El DNI ya está registrado.");
			}

			if (!ModelState.IsValid)
			{
				return Page();
			}

			oAlumno.Id = DatosCompartidos.ObtenerNuevoAlumnoId();
			DatosCompartidos.ListaAlumnos.Add(oAlumno);
			return RedirectToPage("TablaAlumnos");
		}
	}
}
