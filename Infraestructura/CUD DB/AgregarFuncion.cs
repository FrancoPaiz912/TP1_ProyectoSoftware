using Aplicación.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;
using Dominio;
using Infraestructura.EstructuraDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Inserts
{
    public class AgregarFuncion : IAgregar
    {
        private readonly Contexto_Cine _Context;

        public AgregarFuncion(Contexto_Cine context)
        {
            _Context = context;
        }

        void IAgregar.AgregarFuncion(Funciones funcion)
        {
            _Context.Add(funcion);
            _Context.SaveChanges();
        }
    }
}
