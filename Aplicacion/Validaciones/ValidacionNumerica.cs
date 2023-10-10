namespace Aplicacion.Validaciones
{
    public static class ValidacionNumerica
    {
        public static int ComprobarParseo(string Valor)
        {
            try
            {
                int Numero = int.Parse(Valor);
            }
            catch (FormatException)
            {
                return -1;  
            }
            catch (OverflowException)
            {
                return -1;
            }
            return int.Parse(Valor); 
        }
    }
}
