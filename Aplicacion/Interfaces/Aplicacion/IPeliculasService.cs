using Dominio;

namespace Aplicacion.Interfaces.Aplicacion
{
    public interface IPeliculasService
    {
        Task<List<Peliculas>> ListarPeliculas();
        Task<bool> ComprobarPeliculaId(int Id);
    }
}
