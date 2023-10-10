using Aplicación.Interfaces.Infraestructura;
using Dominio;
using Infraestructura.EstructuraDB;

namespace Infraestructura.Inserts
{
    public class InsertarFuncion : IAgregar
    {
        private readonly Contexto_Cine _Contexto;

        public InsertarFuncion(Contexto_Cine Contexto)
        {
            _Contexto = Contexto;
        }

        void IAgregar.AlmacenarFuncion(Funciones Funcion) 
        {
            _Contexto.Add(Funcion);
            _Contexto.SaveChanges();
        }
    }
}
