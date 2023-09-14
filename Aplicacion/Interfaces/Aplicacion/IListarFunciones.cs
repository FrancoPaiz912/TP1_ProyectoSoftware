using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Aplicacion
{
    public interface IListarFunciones
    {
        void ConsultarFunciones(IFiltrarFunciones Funciones, IFiltrarPeliculas peliculas, IVerificacionTemporal verificador);
    }
}
