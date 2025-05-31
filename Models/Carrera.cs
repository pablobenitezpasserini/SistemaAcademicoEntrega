﻿using System.ComponentModel.DataAnnotations;

namespace SistemaAcademico.Models
{
    public class Carrera
    {
        public int Id { get; set; }
		[Required(ErrorMessage = "El nombre no puede estar vacio")]
		public string? Nombre { get; set; }
		[Display(Name = "Duración en años")]
		[Required(ErrorMessage = "La duracion no puede estar vacia")]
		[Range(1, 10, ErrorMessage = "La duracion debe ser entre 1 y 10 años")]
		public int? DuracionAnios { get; set; }
		[Display(Name = "Titulo otorgado")]
		[Required(ErrorMessage = "El titulo no puede estar vacio")]
		public string? TituloOtorgado { get; set; }
		[Required(ErrorMessage = "La modalidad no puede estar vacia")]
		public string? Modalidad { get; set; }
    }
}
