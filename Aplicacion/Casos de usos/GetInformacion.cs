using Aplicacion.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;
using Dominio;

namespace Aplicacion.Casos_de_usos
{
    public class GetInformacion : IGetInformacion
    {
        private readonly IConsultas _Consultas;

        public GetInformacion(IConsultas Consultas)
        {
            _Consultas = Consultas;
        }

        async Task<List<Peliculas>> IGetInformacion.ListarPeliculas()
        {
            return await _Consultas.GetPeliculas(); 
        }

        async Task<List<Salas>> IGetInformacion.ListarSalas()
        {
            return await _Consultas.GetSalas(); 
        }
    }
}
