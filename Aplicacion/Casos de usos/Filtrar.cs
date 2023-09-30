using Aplicacion.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Casos_de_usos
{
    public class Filtrar : IFiltrar
    {
        private readonly IConsultas _Consulta;
        public Filtrar(IConsultas consulta)
        {
            _Consulta = consulta;
        }

        async Task<List<Cartelera>> IFiltrar.Filtrar(string? Titulo = null, string? Fecha= null)
        {
            List<Cartelera> Funciones = new List<Cartelera>();
            foreach (var item in await _Consulta.Filtrar(Titulo, Fecha))
            {
                Funciones.Add(new Cartelera
                {
                    Titulo=item.Peliculas.Titulo,
                    Sinopsis = item.Peliculas.Sinopsis,
                    Poster = item.Peliculas.Poster,
                    Trailer = item.Peliculas.Trailer,
                    Sala = item.Salas.Nombre,
                    Capacidad = item.Salas.Capacidad,
                    Fecha =item.Fecha,
                    Horario = item.Horario,
                    Genero = item.Peliculas.Generos.Nombre
                });
            };
            return Funciones;
        }


        /*List<Cartelera> IFiltrar.FiltrarFunciones(List<Cartelera> carteleras, bool controlador)
        {
            Console.Clear();
            Console.WriteLine("Por favor, ingrese la fecha en la cual desea conocer las funciones \nEn formato dd/mm ó ingresando los dias en formato numerico y los meses en texto(EJ: 12 de Septiembre)\n");
            var respuesta = "no";
            var func = _verificador.Verificacion(true);
            var Funciones = carteleras.Where(p => p.Fecha == func).ToList();
            if (!controlador)
            {
                Console.WriteLine("¿Desea conocer todas las funciones de una determinada pelicula para el día " + func.Date.ToShortDateString() + "?\n");
                respuesta = Console.ReadLine().ToLower();
                controlador = true;
            }
            if (controlador && respuesta == "si")
            {
                return _Filtrar.FiltrarPeliculas(Funciones, controlador);
            }
            else
            {
                return Funciones;
            }
        }*/
    }
}
