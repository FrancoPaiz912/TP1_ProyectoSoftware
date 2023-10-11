using Aplicacion.Interfaces.Aplicacion;
using Aplicacion.Validaciones;
using Dominio;

namespace Presentacion
{
    public class AgregarFuncion
    {
        private readonly IFuncionService FuncionService;
        private readonly IPeliculasService PeliculasService;
        private readonly ISalasService SalasService;

        public AgregarFuncion(IFuncionService FuncionService, IPeliculasService PeliculasService, ISalasService SalasService)
        {
            this.FuncionService = FuncionService;
            this.PeliculasService = PeliculasService;
            this.SalasService = SalasService;
        }

        public async Task RecopilarDatos()
        {
            string ComprobarTiempo;
            int IdPeli, IdSala;
            bool Result = true;
            Console.Clear();
            Console.WriteLine("Por favor escoja la funcion a añadir de acuerdo a los siguientes parametros: \nID de Pelicula \n");
            foreach (var Peli in await PeliculasService.ListarPeliculas())
            {
                Console.WriteLine("ID: " + Peli.Peliculaid + "         - Titulo de la Pelicula: " + Peli.Titulo);
            };
            Console.WriteLine("\n\nPor favor escoga entre los id presentados previamente");
            do
            {
                IdPeli = ValidacionNumerica.ComprobarParseo(Console.ReadLine());
                if (IdPeli < 0 || !await PeliculasService.ComprobarPeliculaId(IdPeli))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opcion incorrecta, ingrese un valor numerico que se encuentre entre las opciones ofrecidas previamente siendo este mayor a 0\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else Result = false;
            } while (Result);
            Console.Clear();
            Console.WriteLine("ID de la sala \n");
            foreach (var Sala in await SalasService.ListarSalas())
            {
                Console.WriteLine("ID:" + Sala.SalaId + "    - Nombre de la sala: " + Sala.Nombre + "            - Capacidad: " + Sala.Capacidad);
            }
            Console.WriteLine("\n\nPor favor escoga entre los id presentados previamente");
            do
            {
                IdSala = ValidacionNumerica.ComprobarParseo(Console.ReadLine());
                if (IdSala < 0 || !await SalasService.ComprobarSalaId(IdSala))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opcion incorrecta, ingrese un valor numerico que se encuentre entre las opciones ofrecidas previamente siendo este mayor a 0\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else Result = true;
            } while (!Result);
            Console.Clear();
            Console.WriteLine("Fecha \nFormato: dd/mm o dia en forma numerica y mes en texto (EJ: 12 de Septiembre) \n");
            do
            {
                ComprobarTiempo = Console.ReadLine();
                Result = ValidacionFecha.VerificacionFecha(ComprobarTiempo);
                if (Result)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ingrese un formato adecuado (dd/mm)\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            } while (Result);
            DateTime Fecha = DateTime.Parse(ComprobarTiempo);
            Console.Clear();
            Console.WriteLine("Hora \nFormato: hh:mm o hora am/pm. \n");
            do
            {
                ComprobarTiempo = Console.ReadLine();
                Result = ValidacionHorario.VerificacionHoraria(ComprobarTiempo);
                if (Result)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ingrese un formato adecuado (hh:mm)\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            } while (Result);
            TimeSpan Horario = DateTime.Parse(ComprobarTiempo).TimeOfDay;
            FuncionService.RegistrarFuncion(IdPeli, IdSala, Fecha, Horario);
        }
    }
}
