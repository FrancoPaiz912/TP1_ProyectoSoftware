using Aplicacion.Excepciones;
using Aplicacion.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;
using Dominio;

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

        void IServiciosFunciones.RegistrarFuncion()
        {
            var iterador = true;
            Console.WriteLine("Por favor escoja la funcion a añadir de acuerdo a los siguientes parametros: \nID de Pelicula \n");
            foreach (var Peli in _consultas.ListarPeliculas())
            {
                Console.WriteLine("ID: " + Peli.Peliculasid + "         - Titulo de la Pelicula: " + Peli.Titulo);
            };
            var IDPeli=VerificacionId(iterador,"pelicula");
            Console.Clear();
            Console.WriteLine("ID de la sala \n");
            foreach (var sala in _consultas.ListarSalas())
            {
                Console.WriteLine("ID:" + sala.SalasId + "    - Nombre de la sala: " + sala.Nombre + "            - Capacidad: " + sala.Capacidad);
            };
            int IDSala=VerificacionId(iterador, "sala");
            Console.Clear();
            iterador = true;
            Console.WriteLine("Fecha \nFormato: dd/mm ó día en forma numerica y mes en texto (EJ: 12 de Septiembre) \n");
            var dia = VerificacionTemporal(iterador).Date;
            Console.Clear();
            Console.WriteLine("Hora \nFormato: hh:mm ó hora am/pm según se requiera \n");
            var hora = VerificacionTemporal(iterador).TimeOfDay;
            Console.Clear();
            var Funcion = new Funciones 
            {
                PeliculaId = IDPeli,
                SalaId = IDSala,
                Fecha = dia, 
                Tiempo = hora, 
            };
            _Agregar.AlmacenarFuncion(Funcion); 
        }

        private int VerificacionId(bool iterador,string tipo)
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

        void IServiciosFunciones.ConsultarFunciones()
        {
            Console.Clear();
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
            Console.Clear();
        }

        List<Cartelera> FiltrarFunciones(List<Cartelera> carteleras,bool controlador)
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

        private List<Cartelera> FiltrarPelicula(List<Cartelera> carteleras,bool controlador)
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
            }catch (ExceptionString ex) {
                Console.WriteLine("Ingreselo nuevamente \n");
                peli = Console.ReadLine().ToUpper();
            }catch (Exception){}
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
            if (imprimir.Count()==0)
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
