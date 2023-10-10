using Dominio;

namespace Aplicacion.Interfaces.Infraestructura.Consultas
{
    public interface IConsultasFuncion
    {
        Task<List<Funciones>> Filtrar(string? Titulo, string? Fecha);
    }
}
