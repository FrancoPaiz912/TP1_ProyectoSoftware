using Aplicacion.DTO;
using Aplicacion.Excepciones;
using Aplicacion.Interfaces.Aplicacion;
using Aplicacion.Validaciones;
using System;

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
            List<Cartelera> Funciones = new List<Cartelera>(); //Se usa para recibir las funciones en cartelera e imprimir los datos
            Console.Clear();
            string Fecha;
            int Result;
            bool Iterador = true; //Iterador que nos permitira realizar el bucle con el fin de que se ingresen todos los datos correctamente
            while (Iterador)
            {
                Console.Clear();
                Console.WriteLine("Por favor, siga las siguientes indicaciones para filtrar funciones:  \n1.Para filtrar por Fecha \n2.Para filtrar por Pelicula \n3.Para filtrar por ambos \n");
                switch (ValidacionNumerica.Comprobar_Parseo(Console.ReadLine())) //Ingreso de opcion 
                {
                    case 1:
                        Console.WriteLine("Por favor, ingrese la fecha con formato dd/mm");
                        do
                        {
                            Fecha = Console.ReadLine();
                            Result = ValidacionFecha.Verificacion_Fecha(Fecha);
                            if (Result == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ingrese un formato adecuado (dd/mm)\n");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            }
                            if (Result == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ha ingresado un horario. \nPor favor ingrese la fecha con el formato correcto. (dd/mm)");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            }
                        } while (Result != 0);
                        Funciones = await _Filtro.Filtrar(null, Fecha); //Se llama a capa de aplicacion, enviandole en este caso unicamente la fecha, para que realice el filtrado.
                        Iterador = false; //Se rompe el ciclo en caso de realizar correctamente el filtrado
                        break;
                    case 2:
                        Console.WriteLine("Por favor, ingrese el titulo de la pelicula");
                        string? Titulo = Console.ReadLine().ToUpper(); //Ingresamos el titulo de la pelicula a filtrar
                        Funciones = await _Filtro.Filtrar(Titulo, null); //Se llama a capa de aplicacion, enviandole en este caso unicamente el titulo de la pelicula, para que realice el filtrado.
                        Iterador = false; //Se rompe el ciclo en caso de realizar correctamente el filtrado
                        break;
                    case 3:
                        Console.WriteLine("Por favor, ingrese la fecha con formato dd/mm");
                        do
                        {
                            Fecha = Console.ReadLine();
                            Result = ValidacionFecha.Verificacion_Fecha(Fecha);
                            if (Result == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ingrese un formato adecuado (dd/mm)\n");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            }
                            if (Result == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ha ingresado un horario. \nPor favor ingrese la fecha con el formato correcto. (dd/mm)");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            }
                        } while (Result != 0);
                        Console.WriteLine("Por favor, ingrese el titulo de la pelicula");
                        string? Nombre_Pelicula = Console.ReadLine().ToUpper(); //Ingresamos el titulo de la pelicula a filtrar
                        Funciones = await _Filtro.Filtrar(Nombre_Pelicula, Fecha); //Se llama a capa de aplicacion, enviandole en este caso tanto la fecha como el titulo de la pelicula, para que realice el filtrado.
                        Iterador = false; //Se rompe el ciclo en caso de realizar correctamente el filtrado
                        break;
                    case 400: //Caso para el FormatException
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opcion incorrecta, Ingrese una opcion numerica \nOprima cualquier tecla para continuar");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.ReadKey();
                        break;
                    case 409: //Caso para el OverflowException
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opcion incorrecta, Ingrese una opcion numerica valida \nOprima cualquier tecla para continuar");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.ReadKey();
                        break;
                    default: //Controlamos cualquier otro valor numerico no ofrecido como opcion que haya escogido el usuario
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opcion numerica no valida, por favor ingrese un valor acorde a las opciones ofrecidas \nOprima cualquier tecla para continuar"); //Arreglar que pasa cuando no se mete un numerico correcto
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.ReadKey();
                        break;
                }
            }
            Console.Clear();
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
                    Console.WriteLine("Pelicula: " + func.Titulo + "\n" + "Genero: " + func.Genero + "\n" + "Poster: " + func.Poster + "\n" + "Sinopsis: " + func.Sinopsis + "\n" + "Trailer: " + func.Trailer + "\n" + "Fecha: " + func.Fecha.Date.ToShortDateString() + "\n" + "Hora: " + func.Horario.ToString() + "\n" + "Sala: " + func.Sala + "\n" + "Capacidad: " + func.Capacidad + "\n");
                }
            }
            Console.WriteLine("Oprima cualquier tecla para continuar");
            Console.ReadKey();
        }
    }
}
