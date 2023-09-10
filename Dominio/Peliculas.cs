using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Peliculas
    {
        public int Peliculasid { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string Poster { get; set; }
        public string Trailer { get; set; }
        public int Genero { get; set; } 
        public Generos Generos { get; set; }
        public ICollection<Funciones> Funciones { get; set; } 
    }
}
