using Aplicacion.Excepciones;
using Aplicacion.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;
using Dominio;

namespace Aplicacion.Casos_de_usos
{
    public class ListarFunciones : IListarFunciones
    {
        private readonly IConsultas _consultas;
        
        public ListarFunciones(IConsultas consultas)
        {
            _consultas = consultas;
        }

        async Task<List<Peliculas>> IListarFunciones.GetPeliculas() 
        {
            return await _consultas.ListarPeliculas(); //Se solicitan los datos de las peliculas registradas
        }

        async Task<List<Salas>> IListarFunciones.GetSalas()
        {
            return await _consultas.ListarSalas(); //Se solicitan los datos de las salas registradas
        }
    }
}
