using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Validaciones
{
    public static class ValidacionNumerica
    {
        public static int Comprobar_Parseo(string Num)
        {
            try
            {
                int Numero = int.Parse(Num);
            }
            catch (FormatException)
            {
                return 400;  //En relacion al mensaje de Bad Request HTTP
            }
            catch (OverflowException)
            {
                return 409; //En relacion al mensaje de conflicto HTTP
            }
            return int.Parse(Num);
        }
    }
}
