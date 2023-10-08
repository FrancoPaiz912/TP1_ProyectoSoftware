using Aplicacion.DTO;
using Aplicacion.Interfaces.Aplicacion;
using Aplicacion.Validaciones;

namespace Presentacion
{
    public class Filtros
    {
        private readonly IFiltrar Filtrar;

        public Filtros(IFiltrar Filtrar)
        {
            this.Filtrar = Filtrar;
        }

        public async Task ComenzarFiltrado()
        {
            List<Cartelera> Funciones = new List<Cartelera>(); //Se usa para recibir las funciones en cartelera e imprimir los datos
            string Fecha;
            bool Iterador;
            do
            {
                Iterador = false;
                Console.Clear();
                Console.WriteLine("Por favor, siga las siguientes indicaciones para filtrar funciones:  \n1.Para filtrar por Fecha \n2.Para filtrar por Pelicula \n3.Para filtrar por ambos \n");
                switch (ValidacionNumerica.ComprobarParseo(Console.ReadLine())) //Ingreso de opcion 
                {
                    case 1:
                        Console.WriteLine("Por favor, ingrese la fecha con formato dd/mm");
                        do
                        {
                            Fecha = Console.ReadLine();
                            Iterador = ValidacionFecha.VerificacionFecha(Fecha); //Llamamos a la clase estatica para comprobar que la fecha ingresada sea en el formato correcto
                            if (Iterador)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ingrese un formato adecuado (dd/mm)\n");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            }
                        } while (Iterador);
                        Funciones = await Filtrar.SolicitarFiltrado(null, Fecha); //Se llama a capa de aplicacion, enviandole en este caso unicamente la fecha, para que realice el filtrado.
                        break;
                    case 2:
                        Console.WriteLine("Por favor, ingrese el titulo de la pelicula");
                        string? Titulo = Console.ReadLine().ToUpper(); //Ingresamos el titulo de la pelicula a filtrar
                        Funciones = await Filtrar.SolicitarFiltrado(Titulo, null); //Se llama a capa de aplicacion, enviandole en este caso unicamente el titulo de la pelicula, para que realice el filtrado.
                        break;
                    case 3:
                        do
                        {
                            Console.WriteLine("Por favor, ingrese la fecha con formato dd/mm");
                            Fecha = Console.ReadLine();
                            Iterador = ValidacionFecha.VerificacionFecha(Fecha);
                            if (Iterador)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ingrese un formato adecuado (dd/mm)\n");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            }
                        } while (Iterador);
                        Console.WriteLine("Por favor, ingrese el titulo de la pelicula");
                        string? Nombre_Pelicula = Console.ReadLine().ToUpper(); //Ingresamos el titulo de la pelicula a filtrar
                        Funciones = await Filtrar.SolicitarFiltrado(Nombre_Pelicula, Fecha); //Se llama a capa de aplicacion, enviandole en este caso tanto la fecha como el titulo de la pelicula, para que realice el filtrado.
                        break;
                    default: //Controlamos cualquier otro valor numerico no ofrecido como opcion que haya escogido el usuario
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOpcion no valida, por favor ingrese un valor numerico acorde a las opciones ofrecidas \n\nOprima cualquier tecla para continuar \n"); //Arreglar que pasa cuando no se mete un numerico correcto
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.ReadKey();
                        Iterador = true;
                        break;
                }
            } while (Iterador);
            Console.Clear(); //Puedo hacer una clase para imprimir¿?
            if (Funciones.Count() == 0) //Si la lista de funciones filtradas no tiene coincidencias se traduce a que no existen funciones encontradas acorde a las busquedas. 
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Lo sentimos, no hay funciones registradas que coincidan con la busqueda :(  \n");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else //En caso de que se hayan encontrado coincidencias, se imprimen por pantalla cada uno de los datos de "cartelera" (la clase creada en aplicacion) de las Funciones de la lista. 
            {
                foreach (var func in Funciones)
                {
                    Console.WriteLine("\nPelicula: " + func.Titulo + "\nGenero: " + func.Genero + "\nSinopsis: " + func.Sinopsis + "\nFecha: " + func.Fecha.Date.ToShortDateString() + "\nHora: " + func.Horario.ToString() + "\nSala: " + func.Sala + "\nCapacidad: " + func.Capacidad);
                }
            }
            Console.WriteLine("\nOprima cualquier tecla para continuar");
            Console.ReadKey();
        }
    }
}
