using Aplicacion.Excepciones;
using Aplicacion.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;
using Dominio;

namespace Aplicacion.Casos_de_usos
{
    public  class AgregarFunciones : IAgregarFunciones
    {
        private readonly IAgregar _Agregar;
        public AgregarFunciones(IAgregar Agregar)
        {
            _Agregar = Agregar;
        }

        void IAgregarFunciones.RegistrarFuncion(int ID_Pelicula,int ID_Sala,DateTime Fecha,TimeSpan Horario)
        {
            _Agregar.AlmacenarFuncion(new Funciones //Se crea la nueva función con los datos ya validados, y se envía a infraestructura.
            {
                PeliculaId = ID_Pelicula,
                SalaId = ID_Sala,
                Fecha = Fecha,
                Horario = Horario,
            });
        }
    }
}
