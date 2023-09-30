using Aplicacion.Casos_de_usos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Aplicacion
{
    public interface IFiltrar
    {
        Task<List<Cartelera>> Filtrar(string? Titulo, string? Fecha);

    }
}
