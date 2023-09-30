using Aplicacion.Casos_de_usos;
using Aplicación.Interfaces.Infraestructura;
using Dominio;
using Infraestructura.EstructuraDB;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Querys
{
    public class Consulta_Funcion : IConsultas
    {
        private readonly Contexto_Cine _Contexto;

        public Consulta_Funcion(Contexto_Cine context)
        {
            _Contexto = context;
        }

        async Task<List<Funciones>> IConsultas.Filtrar(string? Titulo, string? dia)
        {
            return await _Contexto.Funciones.Include(s => s.Tickets)
                .Include(s => s.Salas)
                .Include(s => s.Peliculas)
                .ThenInclude(s => s.Generos)
                .Where(s => ( Titulo != null ? (s.Peliculas.Titulo.Contains(Titulo)) : true) && ( dia != null ? (s.Fecha==DateTime.Parse(dia)) : true)).ToListAsync();
        }

        async Task<List<Peliculas>> IConsultas.ListarPeliculas()
        {
           return await _Contexto.Peliculas.ToListAsync();
        }

        async Task<List<Salas>> IConsultas.ListarSalas()
        {
            return await _Contexto.Salas.ToListAsync();
        }
    }
}
