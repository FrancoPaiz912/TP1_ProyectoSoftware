using Aplicacion.Excepciones;
using Aplicacion.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;
using Dominio;

namespace Aplicacion.Casos_de_usos
{
    public  class RegistrarFuncion : IAgregarFunciones
    {
        private readonly IAgregar _Agregar;
        public RegistrarFuncion(IAgregar Agregar)
        {
            _Agregar = Agregar;
        }

        void IAgregarFunciones.RegistrarFuncion(int IdPelicula,int IdSala,DateTime Fecha,TimeSpan Horario)
        {
            _Agregar.AlmacenarFuncion(new Funciones //Se crea la nueva funcion con los datos ya validados, y se envía a infraestructura.
            {
                PeliculaId = IdPelicula,
                SalaId = IdSala,
                Fecha = Fecha,
                Horario = Horario,
            });
        }
    }
}
