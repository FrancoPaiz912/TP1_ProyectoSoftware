using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Aplicacion
{
    public interface IAgregarFunciones
    {
        //void RegistrarFuncion(IVerficacionID verificador1, IVerificacionTemporal verificador2);
        void RegistrarFuncion(int ID_Pelicula, int ID_Sala, DateTime Fecha, TimeSpan Horario);
    }
}
