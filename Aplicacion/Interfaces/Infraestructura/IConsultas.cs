using Aplicacion.Casos_de_usos;
using Dominio;

namespace Aplicación.Interfaces.Infraestructura
{
    public interface IConsultas
    {
        Task<List<Funciones>> Filtrar(string? Titulo, string? Fecha);
        Task<List<Peliculas>> GetPeliculas();
        Task<List<Salas>> GetSalas();
        Task<Peliculas?> GetPeliculaById(int Id);
        Task<Salas?> GetSalaById(int Id);
    }
}
