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
            Salas? Result = await _Consulta.GetSalaById(Id); //Comprobamos que exista una sala asociada al id recibido
            if (Result != null)
            {
                return true; //Si existe una sala asociada con ese id en la base de datos, entonces se retorna true para romper el bucle
            }

            return false; //En caso contrario devolvemos false para que se vuelva a ingresar el id.
        }

        async Task<bool> IValidacionID.ComprobarPeliculaId(int Id)
        {
            Peliculas? Result = await _Consulta.GetPeliculaById(Id); //Comprobamos que exista una pelicula asociada al id recibido
            if (Result != null)
            {
                return true; //Si existe una pelicula asociada con ese id en la base de datos, entonces se retorna true para romper el bucle.
            }

            return false; //En caso contrario devolvemos false para que se vuelva a ingresar el id.
        }

    }
}
