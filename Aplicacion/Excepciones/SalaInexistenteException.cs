using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Excepciones
{
    public class SalaInexistenteException : Exception
    {
        public SalaInexistenteException(string mensaje) : base(mensaje) 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}
