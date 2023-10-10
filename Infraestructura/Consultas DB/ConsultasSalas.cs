using Aplicacion.Interfaces.Infraestructura.Consultas;
using Dominio;
using Infraestructura.EstructuraDB;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Consultas_DB
{
    public class ConsultasSalas : IConsultasSalas
    {
        private readonly Contexto_Cine _Contexto;

        public ConsultasSalas(Contexto_Cine Context)
        {
            _Contexto = Context;
        }

        async Task<Salas?> IConsultasSalas.GetSalaById(int Id)
        {
            return await _Contexto.Salas.FirstOrDefaultAsync(s => s.SalaId == Id);
        }

        async Task<List<Salas>> IConsultasSalas.GetSalas()
        {
            return await _Contexto.Salas.ToListAsync();
        }
    }
}
