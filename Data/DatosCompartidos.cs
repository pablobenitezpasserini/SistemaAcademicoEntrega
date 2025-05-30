using SistemaAcademico.Models;

namespace SistemaAcademico.Data
{
    public static class DatosCompartidos
    {
        public static List<Carrera> ListCarrera = new ();
        private static int ultimoId = 0;
        public static int ObtenerNuevoId()
        {
            ultimoId++;
            return ultimoId;
        }
    }

}
