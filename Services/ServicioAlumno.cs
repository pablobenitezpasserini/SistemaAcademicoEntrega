﻿using SistemaAcademico.Models;
using System.Text.Json;
using System.Xml.Linq;

namespace SistemaAcademico.Services
{
	public class ServicioAlumno
	{
		private readonly RepositorioCrudJson<Alumno> crud;
		public ServicioAlumno()
		{
			crud = new RepositorioCrudJson<Alumno>("Alumnos");
		}
		public List<Alumno> ObtenerTodos()
		{
			return crud.ObtenerTodos();
		}
		public Alumno? BuscarPorId(int id)
		{
			return crud.BuscarPorId(id);
		}
		public void Editar(Alumno alumno)
		{
			crud.Editar(alumno);
		}
		public void EliminarPorId(int id)
		{
			crud.EliminarPorId(id);
		}
		public void Agregar(Alumno alumno)
		{
			crud.Agregar(alumno);
		}
	}
}
