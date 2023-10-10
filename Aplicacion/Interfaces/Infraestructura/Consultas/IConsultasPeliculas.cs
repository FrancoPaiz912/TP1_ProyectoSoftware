using Dominio;

namespace Aplicacion.Interfaces.Infraestructura.Consultas
{
    public interface IConsultasPeliculas
    {
        Task<List<Peliculas>> GetPeliculas();
        Task<Peliculas?> GetPeliculaById(int Id);
    }
}
