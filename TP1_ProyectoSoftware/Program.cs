using Aplicacion.Casos_de_usos;
using Aplicacion.Interfaces.Aplicacion;
using Infraestructura.EstructuraDB;
using Infraestructura.Inserts;
using Infraestructura.Querys;

class Program
{
    public static void Main(string[] args)
    {
        IServiciosFunciones funcion = new ServiciosFunciones(new Consulta_Funcion(new Contexto_Cine()), new InsertarFuncion(new Contexto_Cine()));
        var EnUso = "si";
        var finalizar = false;
        try
        {
            while (EnUso=="si")
            {
                Console.WriteLine("Bievenido al Cine \n por favor escoja que desea hacer \n1. Listar funciones \n2. Ingresar función \n3. Salir del programa");
                int opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        funcion.ObtenerFunciones();
                        break;
                    case 2:
                        funcion.IntroducirFuncion();
                        Console.WriteLine("Funcion programada con exito.");
                        break;
                    case 3:
                        Console.WriteLine("Gracias por elegirnos, que tenga buen día!!.");
                        finalizar = true;
                        EnUso = "";
                        break;
                    default:
                        Console.WriteLine("Opción equivocada, escoga una de las opciones brindadas por el sistema.");
                        break;
                }
                if (!finalizar)
                {
                    Console.WriteLine("¿Desea realizar otra acción?");
                    EnUso = Console.ReadLine().ToLower();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Por favor le pedimos que ingrese una opción válida >:v");
        }
    }
}
