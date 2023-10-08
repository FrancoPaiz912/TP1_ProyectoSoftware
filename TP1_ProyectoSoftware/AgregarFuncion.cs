using Aplicacion.Interfaces.Aplicacion;
using Aplicacion.Validaciones;

namespace Presentacion
{
    public class AgregarFuncion
    {
        private readonly IAgregarFunciones Agregar;
        private readonly IListarFunciones GetLista;
        private readonly IValidacionID ValidadorID;

        public AgregarFuncion(IAgregarFunciones Agregar, IListarFunciones GetILista, IValidacionID ValidadorID)
        {
            this.Agregar = Agregar;
            this.GetLista = GetILista;
            this.ValidadorID = ValidadorID;
        }

        public async Task RecopilarDatos()
        {
            string ComprobarTiempo;
            int IdPeli, IdSala; //Variables auxiliares que nos permitiran controlar y enviar los datos correctamente
            bool Result;
            Console.Clear();
            Console.WriteLine("Por favor escoja la funcion a añadir de acuerdo a los siguientes parametros: \nID de Pelicula \n");
            foreach (var Peli in await GetLista.ListarPeliculas()) //Imprimimos los titulos registrados con sus id pertinentes(gracias a que se llama a capa de aplicacion y se retornas las peliculas registradas)
            {
                Console.WriteLine("ID: " + Peli.Peliculasid + "         - Titulo de la Pelicula: " + Peli.Titulo);
            };
            do
            {
                Console.WriteLine("Por favor escoga entre los id presentados previamente");
                IdPeli = ValidacionNumerica.ComprobarParseo(Console.ReadLine()); //Validamos que se haya ingresado un valor numerico correctamente
                if (IdPeli < 0) //Caso para el OverflowException
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opcion incorrecta, ingrese un valor numerico que se encuentre entre las opciones establecidas por el sistema siendo este mayor a 0\nOprima cualquier tecla para continuar");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.ReadKey();
                }

            } while (!await ValidadorID.ComprobarPeliculaId(IdPeli)); //Llamamos al metodo correspondiente para verificar que el usuario ingrese una id asociada a una pelicula existente en la base de datos.
            Console.Clear();
            Console.WriteLine("ID de la sala \n");
            foreach (var sala in await GetLista.ListarSalas()) //¿Hago una clase para imprimir salas en vez de imprimir por acá?
            {
                Console.WriteLine("ID:" + sala.SalaId + "    - Nombre de la sala: " + sala.Nombre + "            - Capacidad: " + sala.Capacidad);
            };
            do
            {
                Console.WriteLine("Por favor escoga entre los id presentados previamente");
                IdSala = ValidacionNumerica.ComprobarParseo(Console.ReadLine()); //Validamos que se haya ingresado un valor numerico correctamente
                if (IdSala < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opcion incorrecta, ingrese un valor numerico que se encuentre entre las opciones establecidas por el sistema siendo este mayor a 0\nOprima cualquier tecla para continuar");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.ReadKey();
                }
            } while (!await ValidadorID.ComprobarSalaId(IdSala)); //Llamamos al metodo correspondiente para verificar que el usuario ingrese una id asociada a una sala existente en la base de datos.
            Console.Clear();
            Console.WriteLine("Fecha \nFormato: dd/mm o dia en forma numerica y mes en texto (EJ: 12 de Septiembre) \n");
            do
            {
                ComprobarTiempo = Console.ReadLine();
                Result = ValidacionFecha.VerificacionFecha(ComprobarTiempo); //Validamos que se haya ingresado un valor que corresponda a una fecha. Es decir, que se peuda convertir correctamente
                if (Result) //Si se retorno true, fue porque se produjo un error de formato (una excepcion). Se indica el error.
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ingrese un formato adecuado (dd/mm)\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            } while (Result);
            DateTime Fecha = DateTime.Parse(ComprobarTiempo); //Una vez validada la fecha, se pasa a Datetime. Listo para enviar para el registro.
            Console.Clear();
            Console.WriteLine("Hora \nFormato: hh:mm o hora am/pm. \n");
            do
            {
                ComprobarTiempo = Console.ReadLine();
                Result = ValidacionHorario.VerificacionHoraria(ComprobarTiempo); //Validamos que se haya ingresado un valor que corresponda a una fecha. Es decir, que se peuda convertir correctamente
                if (Result) //Si se retorno true, fue porque se produjo un error de formato (una excepcion). Se indica el error.
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ingrese un formato adecuado (hh:mm)\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            } while (Result);
            TimeSpan Horario = DateTime.Parse(ComprobarTiempo).TimeOfDay; //Una vez validada la hora, se pasa a timespan. Listo para enviar para el registro.
            Agregar.RegistrarFuncion(IdPeli, IdSala, Fecha, Horario); //Se pasan los datos recopilados a capa de aplicacion
        }
    }
}
