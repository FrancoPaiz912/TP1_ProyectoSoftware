using Aplicación.Interfaces.Infraestructura;
using Dominio;
using Infraestructura.EstructuraDB;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Querys
{
    public class ConsultasFunciones : IConsultas
    {
        private readonly Contexto_Cine _Contexto;

        public ConsultasFunciones(Contexto_Cine Context)
        {
            _Contexto = Context;
        }

        async Task<List<Funciones>> IConsultas.Filtrar(string? Titulo, string? Fecha) 
        {
            return await _Contexto.Funciones.Include(s => s.Tickets)
                .Include(s => s.Salas)
                .Include(s => s.Peliculas)
                .ThenInclude(s => s.Generos)
                .Where(s => (Titulo != null ? (s.Peliculas.Titulo.Contains(Titulo)) : true) && (Fecha != null ? (s.Fecha == DateTime.Parse(Fecha)) : true)).ToListAsync();
        } 

        async Task<Peliculas?> IConsultas.GetPeliculaById(int Id)
        {
            Peliculas? asg = await _Contexto.Peliculas.FirstOrDefaultAsync(s => s.Peliculasid == Id);
            return asg;
        }

        async Task<Salas?> IConsultas.GetSalaById(int Id)
        {
            return await _Contexto.Salas.FirstOrDefaultAsync(s => s.SalaId == Id);
        }

        async Task<List<Peliculas>> IConsultas.GetPeliculas()
        {
            return await _Contexto.Peliculas.ToListAsync(); 
        }

        async Task<List<Salas>> IConsultas.GetSalas()
        {
            return await _Contexto.Salas.ToListAsync(); 
        }
    }
}
