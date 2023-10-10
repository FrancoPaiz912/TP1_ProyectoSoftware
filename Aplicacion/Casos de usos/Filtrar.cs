using Aplicacion.DTO;
using Aplicacion.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;

namespace Aplicacion.Casos_de_usos
{
    public class Filtrar : IFiltrar
    {
        private readonly IConsultas _Consulta;
        public Filtrar(IConsultas Consulta)
        {
            _Consulta = Consulta;
        }

        async Task<List<Cartelera>> IFiltrar.SolicitarFiltrado(string? Titulo = null, string? Fecha = null)
        {
            List<Cartelera> Funciones = new List<Cartelera>(); 
            foreach (var item in await _Consulta.Filtrar(Titulo, Fecha)) 
            {                                                            
                Funciones.Add(new Cartelera                             
                {
                    Titulo = item.Peliculas.Titulo,
                    Sinopsis = item.Peliculas.Sinopsis,
                    Sala = item.Salas.Nombre,
                    Capacidad = item.Salas.Capacidad,
                    Fecha = item.Fecha,
                    Horario = item.Horario,
                    Genero = item.Peliculas.Generos.Nombre
                });
            };
            return Funciones;
        }
    }
}
