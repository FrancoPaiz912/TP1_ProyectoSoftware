using Dominio;

namespace Aplicacion.Interfaces.Infraestructura.Consultas
{
    public interface IConsultasSalas
    {
        Task<List<Salas>> GetSalas();
        Task<Salas?> GetSalaById(int Id);
    }
}
