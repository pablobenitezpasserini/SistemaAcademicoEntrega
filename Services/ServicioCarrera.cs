using SistemaAcademico.Models;
using System.Text.Json;

namespace SistemaAcademico.Services
{
    public class ServicioCarrera
    {
        private static string path = "Data/Carreras.json";

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

        public static List<Carrera> ObtenerCarreras() 
        {
            string json = LeerTextoDelArchivo();
            
            var lista = JsonSerializer.Deserialize<List<Carrera>>(json);

            return lista ?? new List<Carrera>();
        }

        public static void AgregarCarrera(Carrera nuevaCarrera)
        {
            var carreras = ObtenerCarreras();

            nuevaCarrera.Id = ObtenerNuevoId(carreras);

            carreras.Add(nuevaCarrera);

            GuardarCarreras(carreras);
        }

		public static void GuardarCarreras(List<Carrera> carreras)
		{
			string json = JsonSerializer.Serialize(carreras);

            File.WriteAllText(path, json);
		}

        public static void EliminarPorId(int id) 
        {
            var lista = ObtenerCarreras();
            Carrera? carreraAEliminar = null;

            foreach (var carrera in lista)
            {
                if(carrera.Id == id)
                {
                    carreraAEliminar = carrera;
                    break;
                }
            }

            if (carreraAEliminar != null) 
            {
                lista.Remove(carreraAEliminar);
                GuardarCarreras(lista);
            }
        }
        public static Carrera? BuscarPorId(int id)
        {
            var lista = ObtenerCarreras();

            foreach (var carrera in lista) 
            {
                if (carrera.Id == id) 
                {
                    return carrera;
                }
            }
            return null;
        }
		private static int ObtenerNuevoId(List<Carrera> listaCarreras)
        {
            int lastId = 0;
            
            foreach (var carrera in listaCarreras) 
            {
                if(carrera.Id > lastId)
                {
                    lastId = carrera.Id;
                }
            }

            lastId++;

            return lastId;
        }
    }
}
