using Aplicacion.DTO;
using Aplicacion.Interfaces.Aplicacion;
using Aplicacion.Interfaces.Infraestructura.Consultas;
using Aplicacion.Interfaces.Infraestructura.CUD;
using Dominio;

namespace Aplicacion.Casos_de_usos
{
    public class FuncionService : IFuncionService
    {
        private readonly IAgregarFuncion AgregarFuncion;
        private readonly IConsultasFuncion ConsultarFuncion;
        public FuncionService(IAgregarFuncion Agregar, IConsultasFuncion Consulta)
        {
            AgregarFuncion = Agregar;
            ConsultarFuncion = Consulta;
        }

        void IFuncionService.RegistrarFuncion(int IdPelicula, int IdSala, DateTime Fecha, TimeSpan Horario)
        {
            AgregarFuncion.AlmacenarFuncion(new Funciones
            {
                PeliculaId = IdPelicula,
                SalaId = IdSala,
                Fecha = Fecha,
                Horario = Horario,
            });
        }

        async Task<List<Cartelera>> IFuncionService.SolicitarFiltrado(string? Titulo = null, string? Fecha = null)
        {
            List<Cartelera> Funciones = new List<Cartelera>();
            foreach (var Item in await ConsultarFuncion.Filtrar(Titulo, Fecha))
            {
                Funciones.Add(new Cartelera
                {
                    Titulo = Item.Peliculas.Titulo,
                    Sinopsis = Item.Peliculas.Sinopsis,
                    Sala = Item.Salas.Nombre,
                    Capacidad = Item.Salas.Capacidad,
                    Fecha = Item.Fecha,
                    Horario = Item.Horario,
                    Genero = Item.Peliculas.Generos.Nombre
                });
            };
            return Funciones;
        }
    }
}
