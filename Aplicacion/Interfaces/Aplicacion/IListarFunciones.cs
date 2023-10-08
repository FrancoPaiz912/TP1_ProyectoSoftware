using Dominio;

namespace Aplicacion.Interfaces.Aplicacion
{
    public interface IListarFunciones
    {
        Task<List<Peliculas>> ListarPeliculas();
        Task<List<Salas>> ListarSalas();
    }
}
