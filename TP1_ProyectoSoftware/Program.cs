using Aplicacion;
using Aplicacion.Casos_de_usos;
using Aplicacion.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;
using Infraestructura.EstructuraDB;
using Infraestructura.Inserts;
using Infraestructura.Querys;
using System.Net.Http.Headers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

class Program
{
    public static void Main(string[] args)
    {
        //IConsultas Querys = new Consulta_Funcion(new Contexto_Cine());
        //IAgregar Inserts = new InsertarFuncion(new Contexto_Cine());
        //IServiciosFunciones Servicio = new ServiciosFunciones(Querys, Inserts);
        IConsultas Querys = new Consulta_Funcion(new Contexto_Cine());
        IAgregar Inserts = new Insertar_Funcion(new Contexto_Cine());

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();
        Console.WriteLine("Bievenido al Cine \n");
        var continuar = true;
        while (continuar)
        {
            continuar =Menú(Querys, Inserts);
            if (continuar)
            {
                continuar = true;
            }
        }
    }

    static bool Menú(IConsultas Querys, IAgregar Inserts)
    {
        IImprimir impresor = new ImprimirFunciones();
        IAgregarFunciones Agregar = new AgregarFunciones(Querys, Inserts);
        IListarFunciones Listar = new ListarFunciones(Querys, impresor);
        IVerificacionTemporal Verificador_Tiempo = new VerificacionTemporal();
        IVerficacionID Verificador_ID = new VerificacionId(Querys);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Por favor escoja que desea hacer ingresando el número correspondiente \n1. Listar funciones \n2. Ingresar función \n3. Salir del programa \n");
        try
        {
            int eleccion = int.Parse(Console.ReadLine());
            switch (eleccion)
            {
                case 1:
                    IFiltrarFunciones filtroFuncion = new FiltrarFuncion(new FiltrarPelicula(),Verificador_Tiempo);
                    IFiltrarPeliculas filtroPelicula = new FiltrarPelicula(new FiltrarFuncion(new FiltrarPelicula(), Verificador_Tiempo));
                    Listar.ConsultarFunciones(filtroFuncion,filtroPelicula,Verificador_Tiempo);
                    break;
                case 2:
                    Agregar.RegistrarFuncion(Verificador_ID, Verificador_Tiempo);
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
            Console.WriteLine("Opcion incorrecta, Ingrese una opción numerica\n");
        }
        return true;
    }
}
