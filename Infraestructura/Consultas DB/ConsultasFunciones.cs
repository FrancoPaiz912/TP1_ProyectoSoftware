using Aplicacion.Interfaces.Infraestructura.Consultas;
using Dominio;
using Infraestructura.EstructuraDB;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Querys
{
    public class ConsultasFunciones : IConsultasFuncion
    {
        private readonly Contexto_Cine _Contexto;

        public ConsultasFunciones(Contexto_Cine Context)
        {
            _Contexto = Context;
        }

        async Task<List<Funciones>> IConsultasFuncion.Filtrar(string? Titulo, string? Fecha)
        {
            return await _Contexto.Funciones.Include(s => s.Tickets)
                .Include(s => s.Salas)
                .Include(s => s.Peliculas)
                .ThenInclude(s => s.Generos)
                .Where(s => (Titulo != null ? (s.Peliculas.Titulo.Contains(Titulo)) : true) && (Fecha != null ? (s.Fecha == DateTime.Parse(Fecha)) : true)).ToListAsync();
        }
    }
}
