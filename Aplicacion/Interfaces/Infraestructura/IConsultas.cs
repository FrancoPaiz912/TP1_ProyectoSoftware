using Aplicacion.Casos_de_usos;
using Dominio;

namespace Aplicación.Interfaces.Infraestructura
{
    public interface IConsultas
    {
        List<Cartelera> ListarFunciones();
        List<Peliculas> ListarPeliculas();
        List<Salas> ListarSalas();
    }
}
