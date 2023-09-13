using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Excepciones
{
    public class PeliculaInexistenteException : Exception
    {
        public PeliculaInexistenteException(string mensaje): base(mensaje) 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }   
    }
}
