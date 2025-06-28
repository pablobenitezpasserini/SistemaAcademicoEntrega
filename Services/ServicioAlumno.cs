using SistemaAcademico.Models;
using System.Text.Json;
using System.Xml.Linq;

namespace SistemaAcademico.Services
{
	public class ServicioAlumno
	{
		private static string path = "Data/Alumnos.json";

		public static string LeerTextoDelArchivo()
		{
			if (File.Exists(path))
			{
				return File.ReadAllText(path);
			}
			else
			{
				return "[]";
			}
		}

		public static List<Alumno> ObtenerAlumnos()
		{
			string json = LeerTextoDelArchivo();

			var lista = JsonSerializer.Deserialize<List<Alumno>>(json);

			return lista ?? new List<Alumno>();
		}

		public static void AgregarAlumno(Alumno nuevoAlumno)
		{
			var alumnos = ObtenerAlumnos();

			nuevoAlumno.Id = ObtenerNuevoId(alumnos);

			alumnos.Add(nuevoAlumno);

			GuardarAlumnos(alumnos);
		}

		public static void GuardarAlumnos(List<Alumno> alumnos)
		{
			string json = JsonSerializer.Serialize(alumnos);

			File.WriteAllText(path, json);
		}

		public static void EliminarPorId(int id)
		{
			var lista = ObtenerAlumnos();
			Alumno? alumnoAEliminar = BuscarAlumnoPorId(lista, id);

			if (alumnoAEliminar != null)
			{
				lista.Remove(alumnoAEliminar);
				GuardarAlumnos(lista);
			}
		}

		public static void EditarAlumno(Alumno alumnoEditado)
		{
			var lista = ObtenerAlumnos();
			var alumno = BuscarAlumnoPorId(lista, alumnoEditado.Id);

			if (alumno != null)
			{
				alumno.Nombre = alumnoEditado.Nombre;
				alumno.Apellido = alumnoEditado.Apellido;
				alumno.Dni = alumnoEditado.Dni;
				alumno.Email = alumnoEditado.Email;
				alumno.FechaNacimiento = alumnoEditado.FechaNacimiento;
				GuardarAlumnos(lista);
			}

		}
		public static Alumno? BuscarPorId(int id)
		{
			var lista = ObtenerAlumnos();

			return BuscarAlumnoPorId(lista, id);
		}
		private static Alumno? BuscarAlumnoPorId(List<Alumno> lista, int id)
		{
			foreach (var alumno in lista)
			{
				if (alumno.Id == id)
				{
					return alumno;
				}
			}
			return null;
		}
		private static int ObtenerNuevoId(List<Alumno> listaAlumnos)
		{
			int lastId = 0;

			foreach (var alumno in listaAlumnos)
			{
				if (alumno.Id > lastId)
				{
					lastId = alumno.Id;
				}
			}

			lastId++;

			return lastId;
		}
	}
}
