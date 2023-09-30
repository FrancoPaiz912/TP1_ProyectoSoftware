using Aplicacion.Excepciones;
using Aplicacion.Interfaces.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*namespace Aplicacion.Casos_de_usos
{
    public class FiltrarPelicula : IFiltrarPeliculas //NO SE USA
    {
        private readonly IFiltrar _Filtrar;
        public FiltrarPelicula(IFiltrar Filtro)
        {
            _Filtrar = Filtro;
        }

        public FiltrarPelicula()
        {

        }
        List<Cartelera> IFiltrarPeliculas.FiltrarPeliculas(List<Cartelera> carteleras, bool controlador)
        {
            Console.Clear();
            Console.WriteLine("Por favor, ingrese el nombre de la pelicula o al un fragmento de este para conocer las funciones que coinciden con el nombre \n");
            var respuesta = "";
            var peli = "";
            try
            {
                peli = Console.ReadLine().ToUpper();
                if (int.Parse(peli).GetType() != "".GetType())
                {
                    throw new ExceptionString("El nombre ingresado tiene solamente números, de ser correcto el nombre de la película por favor vuelva a ingresarlo");
                }
            }
            catch (ExceptionString ex)
            {
                Console.WriteLine("Ingreselo nuevamente \n");
                peli = Console.ReadLine().ToUpper();
            }
            catch (Exception) { }
            var Peliculas = carteleras.Where(p => p.Titulo.Contains(peli)).ToList();
            if (!controlador)
            {
                Console.WriteLine("¿Ingrese 'si' para conocer todas las funciones en una fecha en especifica para la pelicula " + peli + "?\n");
                respuesta = Console.ReadLine().ToLower();
                controlador = true;
            }
            if (controlador && respuesta == "si")
            {
                return _Filtrar.FiltrarFunciones(Peliculas, controlador);
            }
            else
            {
                return Peliculas;
            }
        }
    }
}
*/
