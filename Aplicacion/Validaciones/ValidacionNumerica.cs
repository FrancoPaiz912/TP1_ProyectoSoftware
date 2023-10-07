using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Validaciones
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
                return 400;  //En relacion al mensaje de Bad Request HTTP
            }
            catch (OverflowException)
            {
                return 409; //En relacion al mensaje de conflicto HTTP
            }
            return int.Parse(Valor); //En caso de poder parsear se envia el valor parceado.
        }
    }
}
