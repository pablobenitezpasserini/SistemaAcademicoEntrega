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

            nuevaCarrera.Id = ObtenerNuevoId();

            carreras.Add(nuevaCarrera);

            //GuardarCarreras(carreras);
        }

        private static int ObtenerNuevoId()
        {
            int lastId = 0;
            
            var listaCarreras = ObtenerCarreras();
            
            foreach(var carrera in listaCarreras) 
            {
                if(carrera.Id >= lastId)
                {
                    lastId = carrera.Id;
                }
            }

            lastId++;

            return lastId;
        }
    }
}
