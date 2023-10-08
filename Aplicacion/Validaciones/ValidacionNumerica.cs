﻿namespace Aplicacion.Validaciones
{
    public static class ValidacionNumerica
    {
        public static int ComprobarParseo(string Valor)
        {
            try
            {
                int Numero = int.Parse(Valor);//Verificamos si realmente se puede parsear, en caso de que no se pueda arrojará una de las siguientes dos excepciones.
            }
            catch (FormatException)
            {
                return -1;  //En relacion al mensaje de Bad Request HTTP
            }
            catch (OverflowException)
            {
                return -1; 
            }
            return int.Parse(Valor); //En caso de poder parsear se envia el valor parceado.
        }
    }
}