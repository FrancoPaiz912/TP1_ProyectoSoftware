using Aplicacion.Casos_de_usos;
using Aplicación.Interfaces.Infraestructura;
using Infraestructura.EstructuraDB;
using Infraestructura.Inserts;
using Infraestructura.Querys;
using Presentacion;

class Program
{
    public static async Task Main(string[] args)
    {
        IConsultas Querys = new Consulta_Funcion(new Contexto_Cine());
        IAgregar Inserts = new Insertar_Funcion(new Contexto_Cine());
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();//Para que muestre adecuadamente el color de fondo
        
        while (await Menú(Querys,Inserts))
        {
            Console.Clear(); //Llamada al menú de opciones
        }
    }

    static async Task<bool> Menú(IConsultas Querys, IAgregar Inserts)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("*------------------------------------------------------------------*");
        Console.WriteLine("|                                                                  |");
        Console.WriteLine("|                                                                  |");
        Console.WriteLine("|                                                                  |");
        Console.WriteLine("|                    Bienvenidos al Cine Rocket                    |");
        Console.WriteLine("|                                                                  |");
        Console.WriteLine("|                                                                  |");
        Console.WriteLine("|                                                                  |");
        Console.WriteLine("*------------------------------------------------------------------*");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Por favor escoja que desea hacer ingresando el número correspondiente \n1. Listar funciones \n2. Ingresar función \n3. Salir del programa \n");
        try
        {
            int eleccion = int.Parse(Console.ReadLine()); //Se escoge lo que se desea realizar
            switch (eleccion)
            {
                case 1:
                    Filtro Filtrar= new Filtro(new Filtrar(Querys)); 
                    await Filtrar.RealizarFiltro(); //Llamamos a la clase filtrar, la cual pedirá los datos necesarios para realizar el filtrado
                    break;
                case 2:
                    AgregarFuncion Add = new AgregarFuncion(new AgregarFunciones(Inserts), new ListarFunciones(Querys)); 
                    await Add.AddFuncion(); //LLamamos a la clase agregar la cual pedirá los datos necesarios para agregar una nueva función
                    Console.WriteLine("Funcion programada con exito. \nOprima cualquier tecla para continuar");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("Gracias por elegirnos, que tenga buen día <3. \n");
                    return false;
                default: //Controlamos cualquier otro valor númerico no ofrecido como opción que haya escogido el usuario
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.WriteLine("Opción incorrecta, escoga una de las opciones brindadas por el sistema. \nOprima cualquier tecla para continuar");
                    Console.ReadKey();
                    break;
                }
            }catch (OverflowException)
        { //Excepción de desborde en caso de que se exceda la cantidad de números ingresados
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Opcion incorrecta, Ingrese una opción numerica válida \nOprima cualquier tecla para continuar");
            Console.ReadKey();
        }
        catch (FormatException)
        {//Excepcion de formato, en caso de ingresar algún caracter no númerico.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Opcion incorrecta, Ingrese una opción numerica \nOprima cualquier tecla para continuar");
            Console.ReadKey();
        }
        return true;
    }
}
