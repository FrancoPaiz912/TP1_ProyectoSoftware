using Dominio;

namespace Aplicacion.Interfaces.Aplicacion
{
    public interface ISalasService
    {
        Task<List<Salas>> ListarSalas();
        Task<bool> ComprobarSalaId(int Id);
    }
}
