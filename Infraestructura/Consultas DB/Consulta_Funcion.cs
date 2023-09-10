using Aplicación.Interfaces.Infraestructura;
using Dominio;
using Infraestructura.EstructuraDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Querys
{
    public class Consulta_Funcion : IConsultas
    {
        private readonly Contexto_Cine _Context;

        public Consulta_Funcion(Contexto_Cine context)
        {
            _Context = context;
        }

        List<Funciones> IConsultas.ListarFunciones()
        {
            List<Funciones> Funciones=_Context.Funciones.Where(s => s.FuncionesId>0).ToList();
            return Funciones;
        }

        List<Peliculas> IConsultas.ListarPeliculas()
        {
            throw new NotImplementedException();
        }
    }
}
