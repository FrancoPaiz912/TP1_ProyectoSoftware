using Aplicacion.Casos_de_usos;
using Aplicacion.Interfaces.Aplicacion;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    public class Filtro
    {
        private readonly IFiltrar _Filtro;

        public Filtro(IFiltrar Filtro)
        {
            _Filtro = Filtro;
        }

        public async Task RealizarFiltro()
        {
            List<Cartelera> Funciones = new List<Cartelera>();
            Console.Clear();
            Console.WriteLine("Por favor, siga las siguientes indicaciones para filtrar funciones  \n1.Para filtrar por Fecha \n2.Para filtrar por Pelicula \n3.Para filtrar por ambos");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Por favor, ingrese la fecha con formato dd/mm");
                    string? Fecha = Console.ReadLine();
                    Funciones = await _Filtro.Filtrar(null, Fecha);
                    break;
                case 2:
                    Console.WriteLine("Por favor, ingrese el titulo de la pelicula");
                    string? Titulo = Console.ReadLine();
                    Funciones = await _Filtro.Filtrar(Titulo, null);
                    break;
                case 3:
                    Console.WriteLine("Por favor, ingrese la fecha con formato dd/mm");
                    string? Dia = Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese el titulo de la pelicula");
                    string? Nombre_Pelicula = Console.ReadLine();
                    Funciones = await _Filtro.Filtrar(Nombre_Pelicula, Dia);
                    break;
            }
            if (Funciones.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Lo sentimos, no hay funciones en ese día :(  \n");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            foreach (var func in Funciones)
            {
                Console.WriteLine("Pelicula: " + func.Titulo + "\n" + "Género: " + func.Genero + "\n" + "Poster: " + func.Poster + "\n" + "Sinopsis: " + func.Sinopsis + "\n" + "Trailer: " + func.Trailer + "\n" + "Fecha: " + func.Fecha.Date.ToShortDateString() + "\n" + "Hora: " + func.Horario.ToString() + "\n" + "Sala: " + func.Sala + "\n" + "Capacidad: " + func.Capacidad + "\n");
            }
            Console.WriteLine("Oprima un boton para continuar");
            Console.ReadLine();
        }
    }
}
