using Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicación.Interfaces.Aplicacion
{
    public interface IListarFunciones
    {
        List<Funciones> ObtenerFunciones();

    }
}
