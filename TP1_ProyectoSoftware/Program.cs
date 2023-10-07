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
        
        while (await Menu(Querys,Inserts))//Llamada al menu de opciones
        {
            Console.Clear(); 
        }
    }

    static async Task<bool> Menu(IConsultas Querys, IAgregar Inserts)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("*----------------------------------------------------------------*");
        Console.WriteLine("|                                                                |");
        Console.WriteLine("|                                                                |");
        Console.WriteLine("|                                                                |");
        Console.WriteLine("|                   Bienvenido al Cine Rocket                    |");
        Console.WriteLine("|                                                                |");
        Console.WriteLine("|                                                                |");
        Console.WriteLine("|                                                                |");
        Console.WriteLine("*----------------------------------------------------------------*");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nPor favor escoja que desea hacer ingresando el numero correspondiente: \n1. Listar funciones \n2. Registrar funcion \n3. Salir del programa \n");
        switch (ValidacionNumerica.ComprobarParseo(Console.ReadLine()))
        {
            case 1:
                Filtros IniciarFiltrado = new Filtros(new Filtrar(Querys));
                await IniciarFiltrado.ComenzarFiltrado(); //Llamamos a la clase filtrar, la cual pedira los datos necesarios para realizar el filtrado
                break;
            case 2:
                AgregarFuncion AgregarFuncion = new AgregarFuncion(new RegistrarFuncion(Inserts), new ListarFunciones(Querys), new ValidacionID(Querys));
                await AgregarFuncion.RecopilarDatos(); //LLamamos a la clase agregar la cual pedirá los datos necesarios para agregar una nueva funciun
                Console.WriteLine("Funcion programada con exito. \nOprima cualquier tecla para continuar");
                Console.ReadKey();
                break;
            case 3:
                Console.WriteLine("Gracias por elegirnos, que tenga buen día <3. \n");
                return false; //Al finalizar el programa, no es necesario incluir un break.
            case 400: //Caso para el FormatException
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opcion incorrecta, Ingrese una opcion numerica \nOprima cualquier tecla para continuar");
                Console.ReadKey();
                break;
            case 409: //Caso para el OverflowException
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opcion incorrecta, Ingrese una opcion numerica valida \nOprima cualquier tecla para continuar");
                Console.ReadKey();
                break;
            default: //Controlamos cualquier otro valor númerico no ofrecido como opción que haya escogido el usuario
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opcion incorrecta, escoga una de las opciones brindadas por el sistema. \nOprima cualquier tecla para continuar");
                Console.ReadKey();
                break;
        }
        return true;
    }
}
