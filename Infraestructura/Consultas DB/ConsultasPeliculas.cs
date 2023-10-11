using Aplicacion.Interfaces.Infraestructura.Consultas;
using Dominio;
using Infraestructura.EstructuraDB;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Consultas_DB
{
    public class ConsultasPeliculas : IConsultasPeliculas
    {
        private readonly Contexto_Cine _Contexto;

        public ConsultasPeliculas(Contexto_Cine Context)
        {
            _Contexto = Context;
        }

        async Task<Peliculas?> IConsultasPeliculas.GetPeliculaById(int Id)
        {
            return await _Contexto.Peliculas.FirstOrDefaultAsync(s => s.Peliculaid == Id);
        }

        async Task<List<Peliculas>> IConsultasPeliculas.GetPeliculas()
        {
            return await _Contexto.Peliculas.ToListAsync();
        }
    }
}
