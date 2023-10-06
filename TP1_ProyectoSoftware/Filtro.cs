using Aplicacion.DTO;
using Aplicacion.Excepciones;
using Aplicacion.Interfaces.Aplicacion;

namespace Presentacion
{
    public class Filtro
    {
        private readonly IFiltrar _Filtro;

        public Filtro(IFiltrar Filtro)
        {
            _Filtro = Filtro;
        }

        public async Task RealizarFiltro()
        {
            List<Cartelera> Funciones = new List<Cartelera>();
            Console.Clear();
            bool Iterador = true; //Iterador que nos permitirá realizar el bucle con el fin de que se ingresen todos los datos correctamente
            while (Iterador)
            {
                Console.Clear();
                Console.WriteLine("Por favor, siga las siguientes indicaciones para filtrar funciones  \n1.Para filtrar por Fecha \n2.Para filtrar por Pelicula \n3.Para filtrar por ambos \n");
                try
                {
                    switch (int.Parse(Console.ReadLine())) //Ingreso de opción 
                    {
                        case 1:
                            Console.WriteLine("Por favor, ingrese la fecha con formato dd/mm");
                            string? Fecha = Verificacion_Temporal(); //Verificamos que el formato de fecha ingresado sea el correcto.
                            Funciones = await _Filtro.Filtrar(null, Fecha); //Se llama a capa de aplicación, enviandole en este caso únicamente la fecha, para que realice el filtrado.
                            Iterador = false; //Se rompe el ciclo en caso de realizar correctamente el filtrado
                            break;
                        case 2:
                            Console.WriteLine("Por favor, ingrese el titulo de la pelicula");
                            string? Titulo = Console.ReadLine().ToUpper(); //Ingresamos el titulo de la pelicula a filtrar
                            Funciones = await _Filtro.Filtrar(Titulo, null); //Se llama a capa de aplicación, enviandole en este caso únicamente el titulo de la pelicula, para que realice el filtrado.
                            Iterador = false; //Se rompe el ciclo en caso de realizar correctamente el filtrado
                            break;
                        case 3:
                            Console.WriteLine("Por favor, ingrese la fecha con formato dd/mm");
                            string? Dia = Verificacion_Temporal(); //Verificamos que el formato de fecha ingresado sea el correcto.
                            Console.WriteLine("Por favor, ingrese el titulo de la pelicula");
                            string? Nombre_Pelicula = Console.ReadLine().ToUpper(); //Ingresamos el titulo de la pelicula a filtrar
                            Funciones = await _Filtro.Filtrar(Nombre_Pelicula, Dia); //Se llama a capa de aplicación, enviandole en este caso tanto la fecha como el titulo de la pelicula, para que realice el filtrado.
                            Iterador = false; //Se rompe el ciclo en caso de realizar correctamente el filtrado
                            break;
                        default: //Controlamos cualquier otro valor númerico no ofrecido como opción que haya escogido el usuario
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Opcion numerica no valida, por favor ingrese un valor acorde a las opciones ofrecidas \nOprima cualquier tecla para continuar"); //Arreglar que pasa cuando no se mete un númerico correcto
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.ReadKey();
                            break;
                    }
                }catch (FormatException) { //Controlamos las Excepciones por formato erroneo y por overflow
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ha ingresado un formato incorrecto, por favor escoga una opcion numerica \nOprima cualquier tecla para continuar");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.ReadKey();
                }catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opcion incorrecta, Ingrese una opción numerica válida \nOprima cualquier tecla para continuar");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.ReadKey();
                }
            }
            Console.Clear();
            if (Funciones.Count() == 0) //Si la lista de funciones filtradas no tiene coincidencias se traduce a que no existen funciones encontradas acorde a las busquedas. 
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Lo sentimos, no hay funciones registradas que coincidan con la busqueda :(  \n");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else //En caso de que se hayan encontrado coincidencias, se imprimen por pantalla cada uno de los datos de "cartelera" (la clase creada en aplicación) de las Funciones de la lista. 
            {
                foreach (var func in Funciones)
                {
                    Console.WriteLine("Pelicula: " + func.Titulo + "\n" + "Género: " + func.Genero + "\n" + "Poster: " + func.Poster + "\n" + "Sinopsis: " + func.Sinopsis + "\n" + "Trailer: " + func.Trailer + "\n" + "Fecha: " + func.Fecha.Date.ToShortDateString() + "\n" + "Hora: " + func.Horario.ToString() + "\n" + "Sala: " + func.Sala + "\n" + "Capacidad: " + func.Capacidad + "\n");
                }
            }
            Console.WriteLine("Oprima cualquier tecla para continuar");
            Console.ReadKey();
        }

        private String Verificacion_Temporal() //Comprobación de que tanto la fecha como la hora se ingresen correctamente.
        {
            string Fecha = "";
            bool iterador = true; //Iterador que nos permitirá realizar el bucle con el fin de que se ingresen todos los datos correctamente
            while (iterador)
            {
                try
                {
                    Fecha = Console.ReadLine(); //Ingresamos la fecha que se desea consultar las funciones
                    DateTime Tiempo = DateTime.Parse(Fecha); //Se convierte a datetime ya que en caso de introducir un dato erroneo, se producirá la excepción de formatException
                    if (Tiempo.TimeOfDay != DateTime.Parse("00:00:00").TimeOfDay) //Se compara la hora para verificar que se haya ingresado un dia y no una hora
                    {
                        throw new FechaException(""); //Si la hora es distinta a la 00:00:00, que se setea de esa manera en los datetime cuando solo se introduce fecha,
                    }                                 // significa que en vez de una fecha se ingreso un dia. Por lo que se lanza una excepción
                    iterador = false;
                }
                catch (FormatException) //Control de excepcion de formato
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ingrese un formato adecuado (dd/mm)\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }catch (FechaException) //Se controla la excepcion de ingresar la hora cuando no corresponde.
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ha ingresado erroneamente la fecha. \nPor favor ingrese la fecha con el formato correcto. (dd/mm)");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
            return Fecha;
        }
    }
}
