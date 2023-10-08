using Aplicacion.DTO;

namespace Aplicacion.Interfaces.Aplicacion
{
    public interface IFiltrar
    {
        Task<List<Cartelera>> SolicitarFiltrado(string? Titulo, string? Fecha);

    }
}
