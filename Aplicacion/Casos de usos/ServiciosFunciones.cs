using Aplicacion.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Casos_de_usos
{
    public class ServiciosFunciones : IServiciosFunciones
    {
        private readonly IConsultas _consultas;
        private readonly IAgregar _Agregar;
        public ServiciosFunciones(IConsultas consultas, IAgregar Agregar)
        {
            _consultas = consultas;
            _Agregar = Agregar;
        }

        void IServiciosFunciones.IntroducirFuncion()
        {
            Console.WriteLine("Por favor escoja la funcion a añadir de acuerdo a los siguientes parametros: \nID de Pelicula");
            foreach (var Peli in _consultas.ListarPeliculas())
            {
                Console.WriteLine("ID: " + Peli.Peliculasid + "    - Titulo de la Pelicula: " + Peli.Titulo);
            };
            var IDPeli=int.Parse(Console.ReadLine());
            Console.WriteLine("ID de la sala");
            foreach (var sala in _consultas.ListarSalas())
            {
                Console.WriteLine("ID:" + sala.SalasId + "    - Nombre de la sala: " + sala.Nombre + "            - Capacidad: " + sala.Capacidad);
            };
            var IDSala = int.Parse(Console.ReadLine());
            Console.WriteLine("Fecha");
            var dia=DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Hora");
            var hora=DateTime.Parse(Console.ReadLine());
            
            var Funcion = new Funciones
            {
                PeliculaId = IDPeli,
                SalaId = IDSala,
                Fecha = dia, //TOSHORTTIMESTRING
                Tiempo = hora, //TOSHORTDATESTRING
            };
            _Agregar.AgregarFuncion(Funcion); 
        }

        void IServiciosFunciones.ObtenerFunciones()
        {
            var funciones = _consultas.ListarFunciones(); 
            Console.WriteLine("Desea realizar un filtrado por peliculas o por funciones?");
            var bucle = "si";
            while (bucle=="si")
            {
                bool controlador = false;
                Console.WriteLine("Por favor escoga entre peliculas o funciones");
                var opcion = Console.ReadLine().ToLower();
                if (opcion == "peliculas")
                {
                    var resul = FiltrarPelicula(funciones, controlador);
                    ImpriirPeliculas(resul);
                } else if (opcion== "funciones"){
                    var resul = FiltrarFunciones(funciones, controlador);
                    ImpriirPeliculas(resul);
                }
                Console.WriteLine("¿Desea realizar otras filtraciones?");
                bucle=Console.ReadLine().ToLower();
            }
        }

        List<Cartelera> FiltrarFunciones(List<Cartelera> carteleras,bool controlador)
        {
            Console.WriteLine("Por favor, ingrese la fecha en la cual desea conocer las funciones");
            var respuesta = "no";
            var func = DateTime.Parse(Console.ReadLine());
            var Funciones = carteleras.Where(p => p.Fecha == func).ToList();
            if (!controlador)
            {
                Console.WriteLine("Desea conocer todas las funciones de una determinada pelicula para el día " + func);
                respuesta = Console.ReadLine().ToLower();
                controlador = true;
            }
            if (controlador && respuesta == "si")
            {
                return FiltrarPelicula(Funciones, controlador);
            }
            else
            {
                return Funciones;
            }
        }

        private List<Cartelera> FiltrarPelicula(List<Cartelera> carteleras,bool controlador)
        {
            Console.WriteLine("Por favor, ingrese el nombre de la pelicula");
            var respuesta = "";
            var peli = Console.ReadLine().ToUpper();
            var Peliculas = carteleras.Where(p => p.Titulo == peli).ToList();
            if (!controlador)
            {
                Console.WriteLine("Desea conocer todas las funciones de una determinada pelicula para el día " + peli);
                respuesta = Console.ReadLine().ToLower();
                controlador = true;
            }
            if (controlador && respuesta == "si")
            {
                return FiltrarFunciones(Peliculas, controlador);
            }
            else
            {
                return Peliculas;
            }
        }

        private void ImpriirPeliculas(List<Cartelera> imprimir)
        {
            if (imprimir.Count()==0)
            {
                Console.WriteLine("Lo sentimos, no hay funciones de esa pelicula:(");
            }
            foreach (var func in imprimir)
            {
                Console.WriteLine("Pelicula: " + func.Titulo + "\n" + "Poster: " + func.Poster + "\n" + "Sinopsis: " + func.Sinopsis + "\n" + "Trailer: " + func.Trailer + "\n" + "Fecha: " + func.Fecha.ToString() + "\n" + "Hora: " + func.Hora.ToString() + "\n" + "Sala: " + func.Sala + "\n" + "Capacidad: " + func.Capacidad + "\n");
            }
        }
    }
}
