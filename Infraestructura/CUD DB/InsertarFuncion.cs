using Aplicacion.Interfaces.Infraestructura.CUD;
using Dominio;
using Infraestructura.EstructuraDB;

namespace Infraestructura.Inserts
{
    public class InsertarFuncion : IAgregarFuncion
    {
        private readonly Contexto_Cine _Contexto;

        public InsertarFuncion(Contexto_Cine Contexto)
        {
            _Contexto = Contexto;
        }

        void IAgregarFuncion.AlmacenarFuncion(Funciones Funcion)
        {
            _Contexto.Add(Funcion);
            _Contexto.SaveChanges();
        }
    }
}
