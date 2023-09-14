using Aplicacion.Excepciones;
using Aplicacion.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;

namespace Aplicacion.Casos_de_usos
{
    public class ListarFunciones : IListarFunciones
    {
        private readonly IConsultas _consultas;
        public ListarFunciones(IConsultas consultas)
        {
            _consultas = consultas;
        }
        void IListarFunciones.ConsultarFunciones()
        {
            Console.Clear();
            var funciones = _consultas.ListarFunciones();

            Console.WriteLine("En este apartado podrás conocer las proximas funciones para determinada pelicula, para un determinado día o , en caso de desearlo, las funciones de una pelicula para un día en especifico. \n");
            var Filtrar = "si";
            while (Filtrar == "si")
            {
                bool controlador = false;
                Console.WriteLine("Escriba 'peliculas' para saber las proximas funciones de una determinada pelicula ó 'funciones' para saber las funciones para determinado día \n");
                var opcion = Console.ReadLine().ToLower();
                if (opcion == "peliculas")
                {
                    var resul = FiltrarPelicula(funciones, controlador);
                    ImprimirFunciones(resul);
                }
                else if (opcion == "funciones")
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
                Filtrar = Console.ReadLine().ToLower();
            }
            Console.Clear();
        }

        List<Cartelera> FiltrarFunciones(List<Cartelera> carteleras, bool controlador)
        {
            Console.Clear();
            Console.WriteLine("Por favor, ingrese la fecha en la cual desea conocer las funciones \nEn formato dd/mm ó ingresando los dias en formato numerico y los meses en texto(EJ: 12 de Septiembre)\n");
            var respuesta = "no";
            var func = VerificacionTemporal(true);
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

        private List<Cartelera> FiltrarPelicula(List<Cartelera> carteleras, bool controlador)
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
                return FiltrarFunciones(Peliculas, controlador);
            }
            else
            {
                return Peliculas;
            }
        }

        private void ImprimirFunciones(List<Cartelera> imprimir)
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
        private DateTime VerificacionTemporal(bool iterador)
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
