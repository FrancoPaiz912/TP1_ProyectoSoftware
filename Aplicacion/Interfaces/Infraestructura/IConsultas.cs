using Aplicacion.Casos_de_usos;
using Dominio;

namespace Aplicación.Interfaces.Infraestructura
{
    public interface IConsultas
    {
        Task<List<Funciones>> Filtrar(string? Titulo, string? dia);
        Task<List<Peliculas>> ListarPeliculas();
        Task<List<Salas>> ListarSalas();
    }
}
