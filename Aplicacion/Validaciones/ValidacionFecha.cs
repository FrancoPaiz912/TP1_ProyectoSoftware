using Aplicacion.Excepciones;

namespace Aplicacion.Validaciones
{
    public static class ValidacionFecha
    {
        public static bool VerificacionFecha(string Fecha) 
        {
            try
            {
                DateTime Tiempo = DateTime.Parse(Fecha); 
                if (Tiempo.TimeOfDay != DateTime.Parse("00:00:00").TimeOfDay) 
                {
                    throw new FechaException(""); 
                }                                 
            }
            catch (FormatException) 
            {
                return true; 
            }
            catch (FechaException) 
            {
                return true; 
            }
            return false; 
        }
    }
}
