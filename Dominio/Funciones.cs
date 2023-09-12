using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Funciones
    {
        public int FuncionesId { get; set; } 
        public int PeliculaId { get; set; } 
        public int SalaId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Tiempo { get; set; }
        public Peliculas Peliculas { get; set; }
        public ICollection<Tickets> Tickets { get; set; }
        public Salas Salas { get; set; }   
    }
}
