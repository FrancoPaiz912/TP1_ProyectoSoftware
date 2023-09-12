// See https://aka.ms/new-console-template for more information
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
        Console.WriteLine("Bievenido al Cine \n por favor escoja que desea hacer \n1. Listar funciones \n2. Ingresar función ");

        try
        {
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    funcion.ObtenerFunciones();
                    break;
                case 2:
                    funcion.IntroducirFuncion();
                    Console.WriteLine("Funcion programada con exito");
                    break;
                default:
                    Console.WriteLine("Opción equivocada, escoga una de las anteriores");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("No seas pelotudo");
        }

    }

    static void Opciones()
    {

    }
}
