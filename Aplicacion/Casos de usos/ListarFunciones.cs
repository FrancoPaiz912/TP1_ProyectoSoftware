using Aplicacion.Excepciones;
using Aplicacion.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;

namespace Aplicacion.Casos_de_usos
{
    public class ListarFunciones : IListarFunciones
    {
        private readonly IConsultas _consultas;
        private readonly IImprimir _imprimir;
        
        public ListarFunciones(IConsultas consultas, IImprimir imprimir)
        {
            _consultas = consultas;
            _imprimir = imprimir;
        }
        void IListarFunciones.ConsultarFunciones(IFiltrarFunciones _Funciones, IFiltrarPeliculas _Peliculas, IVerificacionTemporal verificador)
        {
            Console.Clear();
            var funciones = _consultas.ListarFunciones();

            Console.WriteLine("En este apartado podrás conocer las proximas funciones para determinada pelicula, para un determinado día o , en caso de desearlo, las funciones de una pelicula para un día en especifico. \n");
            var Filtrar = "si";
            while (Filtrar == "si")
            {
                bool controlador = false;
                Console.WriteLine("Escriba 'peliculas' para saber las proximas funciones de una determinada pelicula ó 'funciones' para saber las funciones para determinado día \n");
                var opcion = Console.ReadLine().ToLower();
                if (opcion == "peliculas")
                {
                    var resul = _Peliculas.FiltrarPeliculas(funciones, controlador);
                    _imprimir.Imprimir(resul);
                }
                else if (opcion == "funciones")
                {
                    var resul = _Funciones.FiltrarFunciones(funciones, controlador);
                    _imprimir.Imprimir(resul);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción erronea, escoja entre las opciones indicadas arriba \n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.WriteLine("¿Desea conocer las funciones? \n");
                Console.WriteLine("Ingrese 'Si' para llevar a cabo una nueva consulta o aprete Enter para regresar al menú \n");
                Filtrar = Console.ReadLine().ToLower();
            }
            Console.Clear();
        }
    }
}
