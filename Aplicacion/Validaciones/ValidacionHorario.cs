using Aplicacion.Excepciones;

namespace Aplicacion.Validaciones
{
    public static class ValidacionHorario
    {
        public static bool VerificacionHoraria(string Horario)
        {
            try
            {
                DateTime Hora = DateTime.Parse(Horario); 
                if (Hora.Day != DateTime.Now.Day) 
                {
                    throw new HorarioException("");
                }                                  
            }
            catch (FormatException) 
            {
                return true; 
            }
            catch (HorarioException) 
            {
                return true; 
            }
            return false; 
        }
    }
}
