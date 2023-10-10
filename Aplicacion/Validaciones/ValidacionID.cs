using Aplicacion.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;
using Dominio;

namespace Aplicacion.Validaciones
{
    public class ValidacionID : IValidacionID
    { //Compruebo si el id ingresado existe en la base de datos
        private readonly IConsultas _Consulta;

        public ValidacionID(IConsultas Consulta)
        {
            _Consulta = Consulta;
        }

        async Task<bool> IValidacionID.ComprobarSalaId(int Id)
        {
            Salas? Result = await _Consulta.GetSalaById(Id);
            if (Result != null)
            {
                return true; 
            }

            return false; 
        }

        async Task<bool> IValidacionID.ComprobarPeliculaId(int Id)
        {
            Peliculas? Result = await _Consulta.GetPeliculaById(Id); 
            if (Result != null)
            {
                return true; 
            }

            return false; 
        }

    }
}
