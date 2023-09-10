// See https://aka.ms/new-console-template for more information
using Aplicación.Caso_de_usos;
using Aplicación.Interfaces.Aplicacion;
using Infraestructura.EstructuraDB;
using Infraestructura.Querys;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Bievenido al Cine \n por favor escoja que desea hacer \n1. Listar funciones \n2. Ingresar película ");
        int opcion = int.Parse(Console.ReadLine());
        switch (opcion)
        {
            case 1:
                IListarFunciones funcion = new ListarFunciones(new Consulta_Funcion(new Contexto_Cine()));
                funcion.ObtenerFunciones();
                Console.WriteLine("Se ha imprimido");
                break;
            case 2:

            default:
                Console.WriteLine("Opción equivocada");
                break;
        }
    }
}
