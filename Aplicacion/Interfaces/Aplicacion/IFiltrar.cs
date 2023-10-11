using Aplicacion.DTO;

namespace Aplicacion.Interfaces.Aplicacion
{
    public interface IFiltrar
    {
        Task<List<FuncionResponse>> SolicitarFiltrado(string? Titulo, string? Fecha);
    }
}
