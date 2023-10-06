using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Excepciones
{
    public class FechaException : Exception
    {
        public FechaException(string Mensaje): base(Mensaje) 
        {
        }
    }
}
