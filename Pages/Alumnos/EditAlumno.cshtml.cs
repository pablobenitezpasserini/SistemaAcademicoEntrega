using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Models;

namespace SistemaAcademico.Pages.Alumnos
{
	public class EditAlumnoModel : PageModel
	{
		[BindProperty]
		public Alumno oAlumno { get; set; }
		public void OnGet(int id)
		{
			foreach (var alumno in DatosCompartidos.ListaAlumnos)
			{
				if (alumno.Id == id)
				{
					oAlumno = alumno;
					break;
				}
			}
		}
		public IActionResult OnPost()
		{
			if (DatosCompartidos.ListaAlumnos.Any(alumno => alumno.Email == oAlumno.Email && alumno.Id != oAlumno.Id))
			{
				ModelState.AddModelError("oAlumno.Email", "El correo electrónico ya está registrado.");
			}

			if (DatosCompartidos.ListaAlumnos.Any(alumno => alumno.Dni == oAlumno.Dni && alumno.Id != oAlumno.Id))
			{
				ModelState.AddModelError("oAlumno.Dni", "El DNI ya está registrado.");
			}
			if (!ModelState.IsValid)
			{
				return Page();
			}

			foreach (var alumno in DatosCompartidos.ListaAlumnos)
			{
				if (alumno.Id == oAlumno.Id)
				{
					alumno.Nombre = oAlumno.Nombre;
					alumno.Apellido = oAlumno.Apellido;
					alumno.Dni = oAlumno.Dni;
					alumno.Email = oAlumno.Email;
					alumno.FechaNacimiento = oAlumno.FechaNacimiento;
					break;

				}
			}
			return RedirectToPage("TablaAlumnos");
		}
	}
}
