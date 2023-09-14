using Aplicacion.Interfaces.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class VerificacionTemporal : IVerificacionTemporal
    {
        DateTime IVerificacionTemporal.Verificacion(bool iterador)
        {
            DateTime tiempo = DateTime.Parse("12/12/1212");
            while (iterador)
            {
                try
                {
                    tiempo = DateTime.Parse(Console.ReadLine());
                    iterador = false;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ingrese un formato adecuado \n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    iterador = true;
                }
            }
            return tiempo;
        }
    }
}
