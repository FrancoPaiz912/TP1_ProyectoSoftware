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
    public class InsertarFuncion : IAgregar
    {
        private readonly Contexto_Cine _Contexto;

        public InsertarFuncion(Contexto_Cine contexto)
        {
            _Contexto = contexto;
        }

        void IAgregar.AgregarFuncion(Funciones funcion)
        {
            _Contexto.Add(funcion);
            _Contexto.SaveChanges();
        }
    }
}
