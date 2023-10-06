using Aplicacion.DTO;
using Aplicacion.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;
using Dominio;
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
            List<Cartelera> Funciones = new List<Cartelera>(); //Lista de funciones (del tipo cartelera), que se devolverá
            foreach (var item in await _Consulta.Filtrar(Titulo, Fecha)) //Se crean los dto de cartelera y se añaden a la lista. Esto es posible gracias
            {                                                            //a que se llama a capa de infraestructura para recuperar los datos asociados de 
                Funciones.Add(new Cartelera                              //las funciones segun los filtros establecidos.
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
    }
}
