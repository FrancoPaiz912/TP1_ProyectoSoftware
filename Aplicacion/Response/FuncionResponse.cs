﻿namespace Aplicacion.DTO
{
    public class FuncionResponse
    {
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string Sala { get; set; }
        public int Capacidad { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Horario { get; set; }
        public string Genero { get; set; }
    }
}
