using Aplicacion.Casos_de_usos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicación.Interfaces.Infraestructura
{
    public interface IConsultas
    {
        List<Cartelera> ListarFunciones();
        List<Peliculas> ListarPeliculas();
        List<Salas> ListarSalas();
    }
}
