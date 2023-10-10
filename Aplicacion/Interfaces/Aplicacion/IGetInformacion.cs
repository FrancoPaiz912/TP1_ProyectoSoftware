using Dominio;

namespace Aplicacion.Interfaces.Aplicacion
{
    public interface IGetInformacion
    {
        Task<List<Peliculas>> ListarPeliculas();
        Task<List<Salas>> ListarSalas();
    }
}
