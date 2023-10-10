using Aplicacion.Casos_de_usos;
using Aplicacion.Interfaces.Infraestructura.Consultas;
using Aplicacion.Interfaces.Infraestructura.CUD;
using Aplicacion.Validaciones;
using Infraestructura.Consultas_DB;
using Infraestructura.EstructuraDB;
using Infraestructura.Inserts;
using Infraestructura.Querys;
using Presentacion;

class Program
{
    public static async Task Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();

        while (await Menu())
        {
            Console.Clear();
        }
    }

    static async Task<bool> Menu()
    {
        IConsultasFuncion QueryFuncion = new ConsultasFunciones(new Contexto_Cine());
        IAgregarFuncion InsertFuncion = new InsertarFuncion(new Contexto_Cine());
        IConsultasSalas QuerySalas = new ConsultasSalas(new Contexto_Cine());
        IConsultasPeliculas QueryPeliculas = new ConsultasPeliculas(new Contexto_Cine());
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("*----------------------------------------------------------------*");
        Console.WriteLine("|                                                                |");
        Console.WriteLine("|                  Bienvenido al Cine Rocket                     |");
        Console.WriteLine("|                    1. Listar funciones                         |");
        Console.WriteLine("|                    2. Registrar funcion                        |");
        Console.WriteLine("|                    3. Salir del programa                       |");
        Console.WriteLine("|                                                                |");
        Console.WriteLine("*----------------------------------------------------------------*");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Por favor, escoga una opcion:");
        switch (ValidacionNumerica.ComprobarParseo(Console.ReadLine()))
        {
            case 1:
                Filtros IniciarFiltrado = new Filtros(new FuncionService(InsertFuncion, QueryFuncion));
                await IniciarFiltrado.ComenzarFiltrado();
                break;
            case 2:
                AgregarFuncion AgregarFuncion = new AgregarFuncion(new FuncionService(InsertFuncion, QueryFuncion), new PeliculasService(QueryPeliculas), new SalasService(QuerySalas));
                await AgregarFuncion.RecopilarDatos();
                Console.WriteLine("Funcion programada con exito. \n\nOprima cualquier tecla para continuar");
                break;
            case 3:
                Console.WriteLine("Gracias por elegirnos, que tenga buen día <3. \n\n");
                return false;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opcion incorrecta, escoga uno de los valores numericos correspondiente a las opciones brindadas por el sistema.\n\nOprima cualquier tecla para continuar");
                break;
        }
        Console.ReadKey();
        return true;
    }
}
