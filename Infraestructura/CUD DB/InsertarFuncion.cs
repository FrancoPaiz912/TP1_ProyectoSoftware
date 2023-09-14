using Aplicación.Interfaces.Infraestructura;
using Dominio;
using Infraestructura.EstructuraDB;

namespace Infraestructura.Inserts
{
    public class InsertarFuncion : IAgregar
    {
        private readonly Contexto_Cine _Contexto;

        public InsertarFuncion(Contexto_Cine contexto)
        {
            _Contexto = contexto;
        }

        void IAgregar.AlmacenarFuncion(Funciones funcion)
        {
            _Contexto.Add(funcion);
            _Contexto.SaveChanges();
        }
    }
}
