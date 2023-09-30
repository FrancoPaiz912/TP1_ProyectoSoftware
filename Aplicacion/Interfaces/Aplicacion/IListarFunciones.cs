using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Aplicacion
{
    public interface IListarFunciones
    {
        //void ConsultarFunciones(IFiltrar Funciones, IFiltrarPeliculas peliculas, IVerificacionTemporal verificador);
        Task<List<Peliculas>> GetPeliculas();
        Task<List<Salas>> GetSalas();
    }
}
