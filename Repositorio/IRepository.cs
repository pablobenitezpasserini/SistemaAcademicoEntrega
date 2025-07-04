namespace SistemaAcademico.Repositorio
{
    public interface IRepository<T> where T : class
    {
        List<T> ObtenerTodos();
        T? BuscarPorId(int id);
        void Agregar(T? entidad);
        void Editar(T? entidad);
        void EliminarPorId(int id);
    }
}
