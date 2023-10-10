using Aplicacion.DTO;

namespace Aplicacion.Interfaces.Aplicacion
{
    public interface IFuncionService
    {
        void RegistrarFuncion(int IdPelicula, int IdSala, DateTime Fecha, TimeSpan Horario);

        Task<List<Cartelera>> SolicitarFiltrado(string? Titulo, string? Fecha);
    }
}
