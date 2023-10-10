using Aplicacion.Interfaces.Aplicacion;
using Aplicacion.Interfaces.Infraestructura.Consultas;
using Dominio;

namespace Aplicacion.Casos_de_usos
{
    public class PeliculasService : IPeliculasService
    {
        private readonly IConsultasPeliculas _Consultas;
        public PeliculasService(IConsultasPeliculas Consultas)
        {
            _Consultas = Consultas;
        }

        async Task<List<Peliculas>> IPeliculasService.ListarPeliculas()
        {
            return await _Consultas.GetPeliculas();
        }

        async Task<bool> IPeliculasService.ComprobarPeliculaId(int Id)
        {
            Peliculas? Result = await _Consultas.GetPeliculaById(Id);
            if (Result != null)
            {
                return true;
            }

            return false;
        }
    }
}
