using Aplicacion.Excepciones;
using Aplicacion.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Casos_de_usos
{
    public class VerificacionId : IVerficacionID
    {
        private readonly IConsultas _consultas;

        public VerificacionId(IConsultas consultas)
        {
            _consultas = consultas;
        }

        int IVerficacionID.Verificacion(bool iterador, string tipo)
        {
            var ID = 0;
            while (iterador)
            {
                try
                {
                    ID = int.Parse(Console.ReadLine());
                    iterador = false;
                    if (tipo == "pelicula" && (ID > _consultas.ListarPeliculas().Count() || ID == 0))
                    {
                        throw new IDInexistenteException("El ID ingresado no se encuentra asociado a ninguna " + tipo + ", por favor ingrese uno válido \n");
                    }
                    else if (tipo == "sala" && (ID > _consultas.ListarSalas().Count() || ID == 0))
                    {
                        throw new IDInexistenteException("El ID ingresado no se encuentra asociado a ninguna " + tipo + ", por favor ingrese uno válido \n");
                    }
                }
                catch (IDInexistenteException)
                {
                    iterador = true;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Por favor, ingrese el valor en un formato numerico \n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Por favor, ingrese un valor númerico coherente \n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
            return ID;
        }
    }
}
