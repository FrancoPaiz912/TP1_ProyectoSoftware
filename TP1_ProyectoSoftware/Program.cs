using Aplicacion.Casos_de_usos;
using Aplicacion.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;
using Infraestructura.EstructuraDB;
using Infraestructura.Inserts;
using Infraestructura.Querys;
using Microsoft.Extensions.Options;
using System;

class Program
{
    public static void Main(string[] args)
    {
        IConsultas Querys = new Consulta_Funcion(new Contexto_Cine());
        IAgregar Inserts = new InsertarFuncion(new Contexto_Cine());
        IServiciosFunciones funcion = new ServiciosFunciones(Querys, Inserts);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();
        Console.WriteLine("Bievenido al Cine \n");
        var continuar = true;
        while (continuar)
        {
            
            continuar =Menú(funcion);
            if (continuar)
            {
                continuar = true; 
            }
        }
    }

    static bool Menú(IServiciosFunciones funcion)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Por favor escoja que desea hacer \n1. Listar funciones \n2. Ingresar función \n3. Salir del programa \n");
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
                    Console.WriteLine("Funcion programada con exito. \n");
                    break;
                case 3:
                    Console.WriteLine("Gracias por elegirnos, que tenga buen día <3. \n");
                    return false;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción incorrecta, escoga una de las opciones brindadas por el sistema. \n");
                    break;
                }
            }catch (OverflowException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Opcion incorrecta, Ingrese una opción numerica válida \n");
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Opcion incorrecta, Ingrese una opción numerica válida\n");
        }
        return true;
    }
}
