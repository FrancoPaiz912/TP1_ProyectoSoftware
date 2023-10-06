using Aplicacion.Excepciones;
using Aplicacion.Interfaces.Aplicacion;
using Microsoft.SqlServer.Server;

namespace Presentacion
{
    public class AgregarFuncion
    {
        private readonly IAgregarFunciones _Agregar;
        private readonly IListarFunciones _GetInformacion;

        public AgregarFuncion(IAgregarFunciones Agregar, IListarFunciones getInformacion)
        {
            _Agregar = Agregar;
            _GetInformacion = getInformacion;
        }

        public async Task AddFuncion()
        {
            Console.Clear();
            Console.WriteLine("Por favor escoja la funcion a añadir de acuerdo a los siguientes parametros: \nID de Pelicula \n");
            int Cantidad=0; //Variable que nos permitirá saber el rango de id validas(comenzando desde 0), tanto de peliculas como de salas que el usuario tendra permitido ingresar
            foreach (var Peli in await _GetInformacion.GetPeliculas()) //Imprimimos los titulos registrados con sus id pertinentes(gracias a que se llama a capa de aplicación y se retornas las peliculas registradas)
            {
                Console.WriteLine("ID: " + Peli.Peliculasid + "         - Titulo de la Pelicula: " + Peli.Titulo);
                Cantidad++;
            };
            int IDPeli = Verificacion_ID("pelicula",Cantidad); //Llamamos al método correspondiente para verificar que el usuario ingrese una id correctamente (existente en el rango anteriormente mencionado)
            Console.Clear();
            Console.WriteLine("ID de la sala \n"); 
            Cantidad= 0; //Se setea para, en base a la cantidad de veces que se recorre el foreach se vaya sumando... Dado que me dijo que estaba mal que lo haga en funcion de la cantidad de datos en la base de datos
            foreach (var sala in await _GetInformacion.GetSalas()) //Lo mismo que antes solo que para las salas
            {
                Console.WriteLine("ID:" + sala.SalaId + "    - Nombre de la sala: " + sala.Nombre + "            - Capacidad: " + sala.Capacidad);
                Cantidad++;
            };
            int IDSala = Verificacion_ID("sala", Cantidad); //Lo mismo que antes solo que para las salas
            Console.Clear();
            Console.WriteLine("Fecha \nFormato: dd/mm o dia en forma numerica y mes en texto (EJ: 12 de Septiembre) \n");
            DateTime Fecha = Verificacion_Temporal("FECHA").Date; //Se llama al método correspondiente para verificar el ingreso válido de la fecha
            Console.Clear();
            Console.WriteLine("Hora \nFormato: hh:mm o hora am/pm. \n");
            TimeSpan Horario = Verificacion_Temporal("HORARIO").TimeOfDay; //Se llama al método correspondiente para verificar el ingreso válido de la hora
            _Agregar.RegistrarFuncion(IDPeli,IDSala,Fecha,Horario); //Se pasan los datos recopilados a capa de aplicación
        }

        private int Verificacion_ID(string tipo, int Cantidad) //Verifica que el ID ingresado por el usuario se encuentre asociado a una sala/pelicula en la base de datos
        {
            bool iterador = true; //Iterador que nos permitirá realizar el bucle con el fin de que se ingresen todos los datos correctamente
            int ID = 0; //Valor a devolver una vez se ingrese una id existente en la base de datos
            while (iterador)
            {
                try
                {
                    ID = int.Parse(Console.ReadLine());
                    if (tipo == "pelicula" && ID > Cantidad) //Si el id ingresado excede al mayor de los id registrados lanzamos una excepcion (en ambos casos, solo que uno para pelicula y otro para salas)
                    {
                        throw new IDInexistenteException("El ID ingresado no se encuentra asociado a ninguna " + tipo);
                    }
                    else if (tipo == "sala" && ID > Cantidad)
                    {
                        throw new IDInexistenteException("El ID ingresado no se encuentra asociado a ninguna " + tipo); // Esto no debería de imprimirse en presentación?
                    }
                    iterador = false;
                }
                catch (IDInexistenteException) //Control de excepcion de id no asociado a una sala/pelicula
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Por favor ingrese uno valido");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                catch (FormatException) //El ya conocido error de formato
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Por favor, ingrese el valor en un formato numerico \n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                catch (OverflowException) //Control del ya conocido overflow
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Por favor, ingrese un valor númerico coherente \n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
            return ID;
        }

        private DateTime Verificacion_Temporal(string Tiempo) //Se verifica que el la fecha y hora sean en el formato correcto.
        {
            bool iterador = true; //El ya conocido iterador para el bucle
            DateTime Fecha = DateTime.Parse("12-03-1492"); //Variable auxiliar la cual se le cambiaran los datos para devolver un datetime acorde a los datos validos ingresados por el usuario
            while (iterador)
            {
                try
                {
                    if (Tiempo.ToUpper() == "FECHA") //Si se desea comprobar la fecha
                    {
                        Fecha = DateTime.Parse(Console.ReadLine()); 
                        if (Fecha.TimeOfDay != DateTime.Parse("00:00:00").TimeOfDay) //Si se ingreso un horario (cosa que no corresponde), se lanza una excepcion.
                        {
                            throw new FechaException("");
                        }
                    }
                    if (Tiempo.ToUpper() == "HORARIO")
                    {
                        Fecha = DateTime.Parse(Console.ReadLine());
                        if (Fecha.Date != DateTime.Parse("12-03-1492")) //Si se ingreso una fecha (cosa que no corresponde), se lanza una excepcion.
                        {
                            throw new HorarioException("");
                        }
                        
                    }
                    iterador = false;
                }
                catch (FormatException) //Error de formato
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ingrese un formato adecuado \n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                catch (HorarioException) //Error al ingresar un horario, se ingreso una fecha
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ha ingresado erroneamente el horario. \nPor favor ingrese el horario con el formato correcto. (hh:mm)");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }catch (FechaException) //Error al ingresar una fecha, se ingreso un horario.
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ha ingresado erroneamente la fecha. \nPor favor ingrese la fecha con el formato correcto. (dd/mm)");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
            return Fecha;
        }
    }
}
