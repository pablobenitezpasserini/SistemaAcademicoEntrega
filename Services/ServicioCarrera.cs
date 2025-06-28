using SistemaAcademico.Models;
using System.Text.Json;

namespace SistemaAcademico.Services
{
    public class ServicioCarrera
    {
		private readonly RepositorioCrudJson<Carrera> crud;
		public ServicioCarrera()
		{
			crud = new RepositorioCrudJson<Carrera>("Carreras");
		}
		public List<Carrera> ObtenerTodos()
		{
			return crud.ObtenerTodos();
		}
		public Carrera? BuscarPorId(int id)
		{
			return crud.BuscarPorId(id);
		}
		public void Editar(Carrera carrera)
		{
			crud.Editar(carrera);
		}
		public void EliminarPorId(int id)
		{
			crud.EliminarPorId(id);
		}
		public void Agregar(Carrera carrera)
		{
			crud.Agregar(carrera);
		}
	}
}
