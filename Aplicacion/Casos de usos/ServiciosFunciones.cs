using Aplicacion.Excepciones;
using Aplicacion.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;
using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            int IDPeli = 0,IDSala = 0;
            DateTime dia = DateTime.Parse("12/12/1212");
            TimeSpan hora = DateTime.Parse("00:00:00").TimeOfDay;
            var iterador = true;
            Console.WriteLine("Por favor escoja la funcion a añadir de acuerdo a los siguientes parametros: \nID de Pelicula");
            foreach (var Peli in _consultas.ListarPeliculas())
            {
                Console.WriteLine("ID: " + Peli.Peliculasid + "    - Titulo de la Pelicula: " + Peli.Titulo);
            };
            while (iterador)
            {
                try
                {
                    IDPeli = int.Parse(Console.ReadLine());
                    iterador = false;
                    if (IDPeli>_consultas.ListarPeliculas().Count())
                    {
                        throw new PeliculaInexistenteException("El ID ingresado, no se encuentra asociado a ninguna pelicula, por favor ingrese uno válido");
                    }
                }
                catch (PeliculaInexistenteException)
                {
                    iterador = true;
                }
            }
            iterador = true;
            Console.WriteLine("ID de la sala");
            foreach (var sala in _consultas.ListarSalas())
            {
                Console.WriteLine("ID:" + sala.SalasId + "    - Nombre de la sala: " + sala.Nombre + "            - Capacidad: " + sala.Capacidad);
            };
            while (iterador)
            {
                try
                {
                    IDSala = int.Parse(Console.ReadLine());
                    iterador = false;
                    if (IDSala > _consultas.ListarSalas().Count())
                    {
                        throw new PeliculaInexistenteException("El ID ingresado, no se encuentra asociado a ninguna Sala, por favor ingrese uno válido");
                    }
                }
                catch (PeliculaInexistenteException)
                {
                    iterador = true;
                }
            }
            iterador = true;
            Console.WriteLine("Fecha");
            while (iterador)
            {
                try
                {
                    dia = DateTime.Parse(Console.ReadLine()).Date;
                    iterador = false;
                    if (IDSala > _consultas.ListarSalas().Count())
                    {
                        throw new PeliculaInexistenteException("El ID ingresado, no se encuentra asociado a ninguna Sala, por favor ingrese uno válido");
                    }
                }
                catch (PeliculaInexistenteException)
                {
                    iterador = true;
                }
            }
           
            
            Console.WriteLine("Hora");
            hora=DateTime.Parse(Console.ReadLine()).TimeOfDay;
            
            var Funcion = new Funciones 
            {
                PeliculaId = IDPeli,
                SalaId = IDSala,
                Fecha = dia, 
                Tiempo = hora, 
            };
            _Agregar.AgregarFuncion(Funcion); 
        }

        private void InspeccionDeDatos()
        {

        }

        void IServiciosFunciones.ObtenerFunciones()
        {
            var funciones = _consultas.ListarFunciones();
            
            Console.WriteLine("En este apartado podrás conocer las proximas funciones para determinada pelicula, para un determinado día o , en caso de desearlo, las funciones de una pelicula para un día en especifico. \n");
            var Filtrar = "si";
            while (Filtrar=="si")
            {
                bool controlador = false;
                Console.WriteLine("Escriba 'peliculas' para saber las proximas funciones de una determinada pelicula ó 'funciones' para saber las funciones para determinado día \n");
                var opcion = Console.ReadLine().ToLower();
                if (opcion == "peliculas")
                {
                    var resul = FiltrarPelicula(funciones, controlador);
                    ImprimirFunciones(resul);
                } else if (opcion== "funciones")
                {
                    var resul = FiltrarFunciones(funciones, controlador);
                    ImprimirFunciones(resul);
                }
                  else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción erronea, escoja entre las opciones indicadas arriba \n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.WriteLine("¿Desea conocer las funciones? \n");
                Console.WriteLine("Ingrese 'Si' para llevar a cabo una nueva consulta o aprete Enter para regresar al menú \n");
                Filtrar=Console.ReadLine().ToLower();
            }
        }

        List<Cartelera> FiltrarFunciones(List<Cartelera> carteleras,bool controlador)
        {
            Console.WriteLine("Por favor, ingrese la fecha en la cual desea conocer las funciones (En formato dd/mm ó ingresando los dias en formato numerico y los meses en texto)\n");
            var respuesta = "no";
            var func =DateTime.Parse("12/12/1212");
            try
            {
                func = DateTime.Parse(Console.ReadLine());
            }catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error!! Debe de ingresar una fecha correcta \n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Ingrese la fecha nuevamente");
                func = DateTime.Parse(Console.ReadLine());
            }
            var Funciones = carteleras.Where(p => p.Fecha == func).ToList();
            if (!controlador)
                {
                    Console.WriteLine("¿Desea conocer todas las funciones de una determinada pelicula para el día " + func.Date.ToShortDateString() + "?\n");
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
            Console.WriteLine("Por favor, ingrese el nombre de la pelicula \n");
            var respuesta = "";
            var peli = "";
            try
            {
                peli = Console.ReadLine().ToUpper();
                if (ulong.Parse(peli).GetType() != "".GetType())
                {
                    throw new ExceptionString("El nombre ingresado tiene solamente números, de ser correcto el nombre de la película por favor vuelva a ingresarlo");
                }
            }catch (ExceptionString ex) {
                Console.WriteLine("Ingreselo nuevamente \n");
                peli = Console.ReadLine().ToUpper();
            }
            var Peliculas = carteleras.Where(p => p.Titulo == peli).ToList();
            if (!controlador)
            {
                Console.WriteLine("¿Ingrese 'si' para conocer todas las funciones en una fecha en especifica para la pelicula " + peli + "?\n");
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

        private void ImprimirFunciones(List<Cartelera> imprimir)
        {
            if (imprimir.Count()==0)
            {
                Console.WriteLine("Lo sentimos, no hay funciones de esa pelicula  :(  \n");
            }
            foreach (var func in imprimir)
            {
                Console.WriteLine("Pelicula: " + func.Titulo + "\n" + "Género: " + func.genero + "\n" + "Poster: " + func.Poster + "\n" + "Sinopsis: " + func.Sinopsis + "\n" + "Trailer: " + func.Trailer + "\n" + "Fecha: " + func.Fecha.Date.ToShortDateString() + "\n" + "Hora: " + func.Hora.ToString() + "\n" + "Sala: " + func.Sala + "\n" + "Capacidad: " + func.Capacidad + "\n");
            }
        }
    }
}
