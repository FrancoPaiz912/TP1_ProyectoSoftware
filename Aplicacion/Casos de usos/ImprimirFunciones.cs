using Aplicacion.Interfaces.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Casos_de_usos
{
    public class ImprimirFunciones :IImprimir
    {
        void IImprimir.Imprimir(List<Cartelera> imprimir)
        {
            Console.Clear();
            if (imprimir.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Lo sentimos, no hay funciones en ese día :(  \n");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            foreach (var func in imprimir)
            {
                Console.WriteLine("Pelicula: " + func.Titulo + "\n" + "Género: " + func.genero + "\n" + "Poster: " + func.Poster + "\n" + "Sinopsis: " + func.Sinopsis + "\n" + "Trailer: " + func.Trailer + "\n" + "Fecha: " + func.Fecha.Date.ToShortDateString() + "\n" + "Hora: " + func.Hora.ToString() + "\n" + "Sala: " + func.Sala + "\n" + "Capacidad: " + func.Capacidad + "\n");
            }
        }
    }
}
