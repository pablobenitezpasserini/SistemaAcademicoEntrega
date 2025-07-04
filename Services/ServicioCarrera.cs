using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;

namespace SistemaAcademico.Services
{
    public class ServicioCarrera
    {
		private readonly IRepository<Carrera> _repo;
		public ServicioCarrera(IRepository<Carrera> repo)
		{
			_repo = repo;
		}
		public List<Carrera> ObtenerTodos()
		{
			return _repo.ObtenerTodos();
		}
		public Carrera? BuscarPorId(int id)
		{
			return _repo.BuscarPorId(id);
		}
		public void Editar(Carrera carrera)
		{
			_repo.Editar(carrera);
		}
		public void EliminarPorId(int id)
		{
			_repo.EliminarPorId(id);
		}
		public void Agregar(Carrera carrera)
		{
			_repo.Agregar(carrera);
		}
	}
}
