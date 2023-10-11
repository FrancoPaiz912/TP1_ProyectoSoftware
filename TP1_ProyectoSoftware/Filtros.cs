using Aplicacion.DTO;
using Aplicacion.Interfaces.Aplicacion;
using Aplicacion.Validaciones;

namespace Presentacion
{
    public class Filtros
    {
        private readonly IFuncionService FuncionesService;

        public Filtros(IFuncionService FuncionesService)
        {
            this.FuncionesService = FuncionesService;
        }

        public async Task ComenzarFiltrado()
        {
            List<Cartelera> Funciones = new List<Cartelera>();
            string Fecha;
            bool Iterador;
            do
            {
                Iterador = false;
                Console.Clear();
                Console.WriteLine("Por favor, siga las siguientes indicaciones para filtrar funciones:  \n1.Para filtrar por Fecha \n2.Para filtrar por Pelicula \n3.Para filtrar por ambos \n");
                switch (ValidacionNumerica.ComprobarParseo(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Por favor, ingrese la fecha con formato dd/mm");
                        do
                        {
                            Fecha = Console.ReadLine();
                            Iterador = ValidacionFecha.VerificacionFecha(Fecha);
                            if (Iterador)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ingrese un formato adecuado (dd/mm)\n");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            }
                        } while (Iterador);
                        Funciones = await FuncionesService.SolicitarFiltrado(null, Fecha);
                        break;
                    case 2:
                        Console.WriteLine("Por favor, ingrese el titulo de la pelicula");
                        string Titulo = Console.ReadLine().ToUpper();
                        Funciones = await FuncionesService.SolicitarFiltrado(Titulo, null);
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
                        string Nombre_Pelicula = Console.ReadLine().ToUpper();
                        Funciones = await FuncionesService.SolicitarFiltrado(Nombre_Pelicula, Fecha);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOpcion no valida, por favor ingrese un valor numerico acorde a las opciones ofrecidas \n\nOprima cualquier tecla para continuar \n"); //Arreglar que pasa cuando no se mete un numerico correcto
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.ReadKey();
                        Iterador = true;
                        break;
                }
            } while (Iterador);
            Console.Clear();
            if (Funciones.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Lo sentimos, no hay funciones registradas que coincidan con la busqueda :(  \n");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }

            else
            {
                foreach (var Func in Funciones)
                {
                    Console.WriteLine("\nPelicula: " + Func.Titulo + "\nGenero: " + Func.Genero + "\nSinopsis: " + Func.Sinopsis + "\nFecha: " + Func.Fecha.Date.ToShortDateString() + "\nHora: " + Func.Horario.ToString() + "\nSala: " + Func.Sala + "\nCapacidad: " + Func.Capacidad);
                }
            }
            Console.WriteLine("\nOprima cualquier tecla para continuar");
            Console.ReadKey();
        }
    }
}
