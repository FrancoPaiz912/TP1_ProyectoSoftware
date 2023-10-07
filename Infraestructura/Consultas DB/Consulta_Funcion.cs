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

        async Task<List<Funciones>> IConsultas.Filtrar(string? Titulo, string? dia) //Se retornan las funciones con las tablas relacionadas acorde a los filtros aplicados
        {
            return await _Contexto.Funciones.Include(s => s.Tickets)
                .Include(s => s.Salas)
                .Include(s => s.Peliculas)
                .ThenInclude(s => s.Generos)
                .Where(s => ( Titulo != null ? (s.Peliculas.Titulo.Contains(Titulo)) : true) && ( dia != null ? (s.Fecha==DateTime.Parse(dia)) : true)).ToListAsync();
        } //Se utilizan condicionales ternarios para optimizar la busqueda.

        async Task<Peliculas?> IConsultas.GetPeliculaById(int id)
        {
            Peliculas? asg= await _Contexto.Peliculas.FirstOrDefaultAsync(s => s.Peliculasid == id);
            return asg;
        }

        async Task<Salas?> IConsultas.GetSalaById(int id)
        {
            return await _Contexto.Salas.FirstOrDefaultAsync(s => s.SalaId == id);
        }

        async Task<List<Peliculas>> IConsultas.ListarPeliculas()
        {
           return await _Contexto.Peliculas.ToListAsync(); //Retorna la lista de peliculas asociadas
        }

        async Task<List<Salas>> IConsultas.ListarSalas()
        {
            return await _Contexto.Salas.ToListAsync(); //Retorna la lista de salas asociadas
        }
    }
}
