using Aplicacion.Excepciones;
using Aplicacion.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;
using Dominio;

namespace Aplicacion.Casos_de_usos
{
    public  class AgregarFunciones : IAgregarFunciones
    {
        private readonly IConsultas _consultas;
        private readonly IAgregar _Agregar;
        public AgregarFunciones(IConsultas consultas, IAgregar Agregar)
        {
            _consultas = consultas;
            _Agregar = Agregar;
        }

        void IAgregarFunciones.RegistrarFuncion()
        {
            var iterador = true;
            Console.WriteLine("Por favor escoja la funcion a añadir de acuerdo a los siguientes parametros: \nID de Pelicula \n");
            foreach (var Peli in _consultas.ListarPeliculas())
            {
                Console.WriteLine("ID: " + Peli.Peliculasid + "         - Titulo de la Pelicula: " + Peli.Titulo);
            };
            var IDPeli = VerificacionId(iterador, "pelicula");
            Console.Clear();
            Console.WriteLine("ID de la sala \n");
            foreach (var sala in _consultas.ListarSalas())
            {
                Console.WriteLine("ID:" + sala.SalasId + "    - Nombre de la sala: " + sala.Nombre + "            - Capacidad: " + sala.Capacidad);
            };
            int IDSala = VerificacionId(iterador, "sala");
            Console.Clear();
            iterador = true;
            Console.WriteLine("Fecha \nFormato: dd/mm ó día en forma numerica y mes en texto (EJ: 12 de Septiembre) \n");
            var dia = VerificacionTemporal(iterador).Date;
            Console.Clear();
            Console.WriteLine("Hora \nFormato: hh:mm ó hora am/pm según se requiera \n");
            var hora = VerificacionTemporal(iterador).TimeOfDay;
            Console.Clear();
            var Funcion = new Funciones
            {
                PeliculaId = IDPeli,
                SalaId = IDSala,
                Fecha = dia,
                Tiempo = hora,
            };
            _Agregar.AlmacenarFuncion(Funcion);
        }

        private int VerificacionId(bool iterador, string tipo)
        {
            var ID = 0;
            while (iterador)
            {
                try
                {
                    ID = int.Parse(Console.ReadLine());
                    iterador = false;
                    if (tipo == "pelicula" && (ID > _consultas.ListarPeliculas().Count() || ID == 0))
                    {
                        throw new IDInexistenteException("El ID ingresado no se encuentra asociado a ninguna " + tipo + ", por favor ingrese uno válido \n");
                    }
                    else if (tipo == "sala" && (ID > _consultas.ListarSalas().Count() || ID == 0))
                    {
                        throw new IDInexistenteException("El ID ingresado no se encuentra asociado a ninguna " + tipo + ", por favor ingrese uno válido \n");
                    }
                }
                catch (IDInexistenteException)
                {
                    iterador = true;
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

        private DateTime VerificacionTemporal(bool iterador)
        {
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
