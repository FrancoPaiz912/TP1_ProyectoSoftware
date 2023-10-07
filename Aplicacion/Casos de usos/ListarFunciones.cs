using Aplicacion.Excepciones;
using Aplicacion.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;
using Dominio;

namespace Aplicacion.Casos_de_usos
{
    public class ListarFunciones : IListarFunciones
    {
        private readonly IConsultas _Consultas;
        
        public ListarFunciones(IConsultas Consultas)
        {
            _Consultas = Consultas;
        }

        async Task<List<Peliculas>> IListarFunciones.ListarPeliculas() 
        {
            return await _Consultas.GetPeliculas(); //Se solicitan los datos de las peliculas registradas
        }

        async Task<List<Salas>> IListarFunciones.ListarSalas()
        {
            return await _Consultas.GetSalas(); //Se solicitan los datos de las salas registradas
        }
    }
}
