using Aplicacion.Interfaces.Aplicacion;
using Aplicacion.Validaciones;

namespace Presentacion
{
    public class AgregarFuncion
    {
        private readonly IAgregarFunciones Agregar;
        private readonly IGetInformacion GetLista;
        private readonly IValidacionID ValidadorID;

        public AgregarFuncion(IAgregarFunciones Agregar, IGetInformacion GetILista, IValidacionID ValidadorID)
        {
            this.Agregar = Agregar;
            this.GetLista = GetILista;
            this.ValidadorID = ValidadorID;
        }

        public async Task RecopilarDatos()
        {
            string ComprobarTiempo;
            int IdPeli, IdSala; 
            bool Result;
            Console.Clear();
            Console.WriteLine("Por favor escoja la funcion a añadir de acuerdo a los siguientes parametros: \nID de Pelicula \n");
            foreach (var Peli in await GetLista.ListarPeliculas()) 
            {
                Console.WriteLine("ID: " + Peli.Peliculasid + "         - Titulo de la Pelicula: " + Peli.Titulo);
            };
            do
            {
                Console.WriteLine("Por favor escoga entre los id presentados previamente");
                IdPeli = ValidacionNumerica.ComprobarParseo(Console.ReadLine()); 
                if (IdPeli < 0) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opcion incorrecta, ingrese un valor numerico que se encuentre entre las opciones establecidas por el sistema siendo este mayor a 0\nOprima cualquier tecla para continuar");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.ReadKey();
                }

            } while (!await ValidadorID.ComprobarPeliculaId(IdPeli)); 
            Console.Clear();
            Console.WriteLine("ID de la sala \n");
            foreach (var sala in await GetLista.ListarSalas())
            {
                Console.WriteLine("ID:" + sala.SalaId + "    - Nombre de la sala: " + sala.Nombre + "            - Capacidad: " + sala.Capacidad);
            };
            do
            {
                Console.WriteLine("Por favor escoga entre los id presentados previamente");
                IdSala = ValidacionNumerica.ComprobarParseo(Console.ReadLine());
                if (IdSala < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opcion incorrecta, ingrese un valor numerico que se encuentre entre las opciones establecidas por el sistema siendo este mayor a 0\nOprima cualquier tecla para continuar");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.ReadKey();
                }
            } while (!await ValidadorID.ComprobarSalaId(IdSala)); 
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
            Agregar.RegistrarFuncion(IdPeli, IdSala, Fecha, Horario); 
        }
    }
}
