using Aplicacion.Excepciones;
using Aplicacion.Interfaces.Aplicacion;
using Aplicacion.Validaciones;
using Microsoft.SqlServer.Server;

namespace Presentacion
{
    public class AgregarFuncion
    {
        private readonly IAgregarFunciones _Agregar;
        private readonly IListarFunciones _GetInformacion;
        private readonly IValidacionID _ValidadorID;

        public AgregarFuncion(IAgregarFunciones Agregar, IListarFunciones GetInformacion, IValidacionID ValidadorID)
        {
            _Agregar = Agregar;
            _GetInformacion = GetInformacion;
            _ValidadorID = ValidadorID;
        }

        public async Task AddFuncion()
        {
            string Comprobar_Tiempo;
            int Result, IDPeli, IDSala; //Variables auxiliares que nos permitiran controlar y enviar los datos correctamente
            Console.Clear();
            Console.WriteLine("Por favor escoja la funcion a añadir de acuerdo a los siguientes parametros: \nID de Pelicula \n");
            foreach (var Peli in await _GetInformacion.GetPeliculas()) //Imprimimos los titulos registrados con sus id pertinentes(gracias a que se llama a capa de aplicacion y se retornas las peliculas registradas)
            {
                Console.WriteLine("ID: " + Peli.Peliculasid + "         - Titulo de la Pelicula: " + Peli.Titulo);
            };
            do{
                Console.WriteLine("Por favor escoga entre los id presentados previamente");
                IDPeli = ValidacionNumerica.Comprobar_Parseo(Console.ReadLine()); //Validamos que se haya ingresado un valor numerico correctamente
                if (IDPeli == 400) //Caso para el OverflowException
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opcion incorrecta, Ingrese una opcion numerica \nOprima cualquier tecla para continuar");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.ReadKey();
                }
                if (IDPeli == 409) //Caso para el OverflowException
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opcion incorrecta, Ingrese una opcion numerica valida \nOprima cualquier tecla para continuar");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.ReadKey();
                }

            }while (! await _ValidadorID.ComprobarPeliculaId(IDPeli)); //Llamamos al metodo correspondiente para verificar que el usuario ingrese una id asociada a una pelicula existente en la base de datos.
            Console.Clear();
            Console.WriteLine("ID de la sala \n"); 
            foreach (var sala in await _GetInformacion.GetSalas()) //Lo mismo que antes solo que para las salas
            {
                Console.WriteLine("ID:" + sala.SalaId + "    - Nombre de la sala: " + sala.Nombre + "            - Capacidad: " + sala.Capacidad);
            };
            do
            {
                Console.WriteLine("Por favor escoga entre los id presentados previamente");
                IDSala = ValidacionNumerica.Comprobar_Parseo(Console.ReadLine()); //Validamos que se haya ingresado un valor numerico correctamente
                if (IDSala == 400) //Caso para el OverflowException
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opcion incorrecta, Ingrese una opcion numerica \nOprima cualquier tecla para continuar");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.ReadKey();
                }
                if (IDSala == 409) //Caso para el OverflowException
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opcion incorrecta, Ingrese una opcion numerica valida \nOprima cualquier tecla para continuar");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.ReadKey();
                }
            } while (! await _ValidadorID.ComprobarSalaId(IDSala)); //Llamamos al metodo correspondiente para verificar que el usuario ingrese una id asociada a una sala existente en la base de datos.
            Console.Clear();
            Console.WriteLine("Fecha \nFormato: dd/mm o dia en forma numerica y mes en texto (EJ: 12 de Septiembre) \n");
            do {
                Comprobar_Tiempo = Console.ReadLine();
                Result=ValidacionFecha.Verificacion_Fecha(Comprobar_Tiempo); //Validamos que se haya ingresado un valor que corresponda a una fecha. Es decir, que se peuda convertir correctamente
                if (Result==1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ingrese un formato adecuado (dd/mm)\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                if (Result==2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ha ingresado un horario. \nPor favor ingrese la fecha con el formato correcto. (dd/mm)");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            } while (Result!=0);
            DateTime Fecha = DateTime.Parse(Comprobar_Tiempo); //Una vez validada la fecha, se pasa a Datetime. Listo para enviar para el registro.
            Console.Clear();
            Console.WriteLine("Hora \nFormato: hh:mm o hora am/pm. \n");
            do
            {
                Comprobar_Tiempo = Console.ReadLine();
                Result = ValidacionHorario.Verificacion_Horario(Comprobar_Tiempo); //Validamos que se haya ingresado un valor que corresponda a una fecha. Es decir, que se peuda convertir correctamente
                if (Result == 1) //Si se retorno 1, fue porque se produjo un error de formato (una excepcion). Se indica el error.
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ingrese un formato adecuado (hh:mm)\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                if (Result == 2) //Si se retorno 2, fue porque se produjo un error de formato (una excepcion). Se indica el error.
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ha ingresado una fecha. \nPor favor ingrese un horario con el formato correcto. (hh:mm)");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            } while (Result != 0);

            TimeSpan Horario = DateTime.Parse(Comprobar_Tiempo).TimeOfDay; //Una vez validada la hora, se pasa a timespan. Listo para enviar para el registro.
            _Agregar.RegistrarFuncion(IDPeli,IDSala,Fecha,Horario); //Se pasan los datos recopilados a capa de aplicacion
        }
    }
}
