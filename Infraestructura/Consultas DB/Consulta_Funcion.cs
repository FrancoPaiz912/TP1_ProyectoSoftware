﻿using Aplicacion.Casos_de_usos;
using Aplicación.Interfaces.Infraestructura;
using Dominio;
using Infraestructura.EstructuraDB;

namespace Infraestructura.Querys
{
    public class Consulta_Funcion : IConsultas
    {
        private readonly Contexto_Cine _Contexto;

        public Consulta_Funcion(Contexto_Cine context)
        {
            _Contexto = context;
        }

        List<Cartelera> IConsultas.ListarFunciones()
        {
            return (from Funciones in _Contexto.Funciones
                   join Peliculas in _Contexto.Peliculas on Funciones.PeliculaId equals Peliculas.Peliculasid
                   join Salas in _Contexto.Salas on Funciones.SalaId equals Salas.SalasId
                   join Genero in _Contexto.Generos on Peliculas.Genero equals Genero.GenerosId
                   select new Cartelera
                   {
                       Titulo = Peliculas.Titulo,
                       Sinopsis = Peliculas.Sinopsis,
                       Poster = Peliculas.Poster,
                       Trailer = Peliculas.Trailer,
                       Sala = Salas.Nombre,
                       Capacidad = Salas.Capacidad,
                       Fecha = Funciones.Fecha,
                       Hora = Funciones.Tiempo,
                       genero = Genero.Nombre,
                   }).ToList();
        }

        List<Peliculas> IConsultas.ListarPeliculas()
        {
           return _Contexto.Peliculas.ToList();
        }

        List<Salas> IConsultas.ListarSalas()
        {
            return _Contexto.Salas.ToList();
        }
    }
}
