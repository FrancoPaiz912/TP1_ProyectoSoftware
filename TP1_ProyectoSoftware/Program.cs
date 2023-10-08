using Aplicacion.Casos_de_usos;
using Aplicación.Interfaces.Infraestructura;
using Aplicacion.Validaciones;
using Infraestructura.EstructuraDB;
using Infraestructura.Inserts;
using Infraestructura.Querys;
using Presentacion;

class Program
{
    public static async Task Main(string[] args)
    {
        IConsultas Querys = new ConsultasFunciones(new Contexto_Cine());
        IAgregar Inserts = new InsertarFuncion(new Contexto_Cine());
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();//Para que muestre adecuadamente el color de fondo

        while (await Menu(Querys, Inserts))//Llamada al menu de opciones
        {
            Console.Clear();
        }
    }

    static async Task<bool> Menu(IConsultas Querys, IAgregar Inserts)
    {
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
                Filtros IniciarFiltrado = new Filtros(new Filtrar(Querys));
                await IniciarFiltrado.ComenzarFiltrado(); //Llamamos a la clase filtrar, la cual pedira los datos necesarios para realizar el filtrado
                break;
            case 2:
                AgregarFuncion AgregarFuncion = new AgregarFuncion(new RegistrarFuncion(Inserts), new ListarFunciones(Querys), new ValidacionID(Querys));
                await AgregarFuncion.RecopilarDatos(); //LLamamos a la clase agregar la cual pedirá los datos necesarios para agregar una nueva funciun
                Console.WriteLine("Funcion programada con exito. \n\nOprima cualquier tecla para continuar");
                break;
            case 3:
                Console.WriteLine("Gracias por elegirnos, que tenga buen día <3. \n\n");
                return false; //Al finalizar el programa, no es necesario incluir un break.
            default: //Controlamos cualquier otro valor númerico no ofrecido como opción que haya escogido el usuario
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opcion incorrecta, escoga uno de los valores numericos correspondiente a las opciones brindadas por el sistema.\n\nOprima cualquier tecla para continuar");
                break;
        }
        Console.ReadKey();
        return true;
    }
}
