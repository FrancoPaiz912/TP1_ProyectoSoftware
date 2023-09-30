using Aplicacion.Excepciones;
using Aplicacion.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;
using Infraestructura.Inserts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("Por favor escoja la funcion a añadir de acuerdo a los siguientes parametros: \nID de Pelicula \n");
            int Cantidad=0; 
            foreach (var Peli in await _GetInformacion.GetPeliculas())
            {
                Console.WriteLine("ID: " + Peli.Peliculasid + "         - Titulo de la Pelicula: " + Peli.Titulo);
                Cantidad++;
            };
            int IDPeli = Verificacion_ID("pelicula",Cantidad);
            Console.Clear();
            Console.WriteLine("ID de la sala \n");
            foreach (var sala in await _GetInformacion.GetSalas())
            {
                Console.WriteLine("ID:" + sala.SalaId + "    - Nombre de la sala: " + sala.Nombre + "            - Capacidad: " + sala.Capacidad);
            };
            int IDSala = Verificacion_ID("sala", Cantidad);
            Console.Clear();
            Console.WriteLine("Fecha \nFormato: dd/mm o dia en forma numerica y mes en texto (EJ: 12 de Septiembre) \n");
            DateTime Fecha = Verificacion_Temporal().Date;
            Console.Clear();
            Console.WriteLine("Hora \nFormato: hh:mm o hora am/pm. \n");
            TimeSpan Horario = Verificacion_Temporal().TimeOfDay;
            _Agregar.RegistrarFuncion(IDPeli,IDSala,Fecha,Horario);
        }

        int Verificacion_ID(string tipo, int Cantidad)
        {
            bool iterador = true;
            var ID = 0;
            while (iterador)
            {
                try
                {
                    ID = int.Parse(Console.ReadLine());
                    if (tipo == "pelicula" && ID > Cantidad) //Mepa que a esto se referia con lo de la base de datos... mmmm 
                    {
                        throw new IDInexistenteException("El ID ingresado no se encuentra asociado a ninguna " + tipo);
                    }
                    else if (tipo == "sala" && ID > Cantidad)
                    {
                        throw new IDInexistenteException("El ID ingresado no se encuentra asociado a ninguna " + tipo);
                    }
                    iterador = false;
                }
                catch (IDInexistenteException)
                {
                    Console.WriteLine("Por favor ingrese uno valido");
                    iterador = true; //Comprobar si al llegar acá soguen siendo true o no
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Por favor, ingrese el valor en un formato numerico \n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Por favor, ingrese un valor númerico coherente \n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
            return ID;
        }

        DateTime Verificacion_Temporal()
        {
            bool iterador = true;
            DateTime tiempo = DateTime.Parse("12/12/1212");
            while (iterador)
            {
                try
                {
                    tiempo = DateTime.Parse(Console.ReadLine());
                    iterador = false;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ingrese un formato adecuado \n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    iterador = true;
                }
            }
            return tiempo;
        }
    }
}
