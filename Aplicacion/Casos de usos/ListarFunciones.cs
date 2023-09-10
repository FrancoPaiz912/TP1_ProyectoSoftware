using Aplicación.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;
using Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicación.Caso_de_usos
{
    public class ListarFunciones : IListarFunciones
    {
        private readonly IConsultas _consultas;

        public ListarFunciones(IConsultas consultas)
        {
            _consultas = consultas;
        }

        List<Funciones> IListarFunciones.ObtenerFunciones()
        {
            var funciones =_consultas.ListarFunciones();
            return funciones;
        }
    }
}
