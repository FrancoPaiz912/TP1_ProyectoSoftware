using Aplicacion.DTO;
using Dominio;

namespace Presentacion
{
    public static class ImprimirDatos
    {
        public static void ImprimirCartelera(List<Cartelera> Funciones)
        {
            Console.Clear();
            if (Funciones.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Lo sentimos, no hay funciones registradas que coincidan con la busqueda :(  \n");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                foreach (var Func in Funciones)
                {
                    Console.WriteLine("\nPelicula: " + Func.Titulo + "\nGenero: " + Func.Genero + "\nSinopsis: " + Func.Sinopsis + "\nFecha: " + Func.Fecha.Date.ToShortDateString() + "\nHora: " + Func.Horario.ToString() + "\nSala: " + Func.Sala + "\nCapacidad: " + Func.Capacidad);
                }
            }
        }

        public static void ImprimirPeliculas(List<Peliculas> Peliculas)
        {
            foreach (var Peli in Peliculas)
            {
                Console.WriteLine("ID: " + Peli.Peliculasid + "         - Titulo de la Pelicula: " + Peli.Titulo);
            };
        }

        public static void ImprimirSalas(List<Salas> Salas)
        {
            foreach (var Sala in Salas)
            {
                Console.WriteLine("ID:" + Sala.SalaId + "    - Nombre de la sala: " + Sala.Nombre + "            - Capacidad: " + Sala.Capacidad);
            };
        }
    }
}
