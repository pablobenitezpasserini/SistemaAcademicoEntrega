﻿using SistemaAcademico.Models;

namespace SistemaAcademico.Data
{
    public static class DatosCompartidos
    {
        public static List<Carrera> ListCarrera = new List<Carrera>();
        public static List<Alumno> ListaAlumno = new List<Alumno>();

        private static int _ultimoCarreaId = 0;
		private static int _ultimoAlumnoId = 0;
		public static int ObtenerNuevoCarreraId()
        {
            _ultimoCarreaId++;
            return _ultimoCarreaId;
        }

		public static int ObtenerNuevoAlumnoId()
		{
			_ultimoAlumnoId++;
			return _ultimoAlumnoId;
		}
	}

}
