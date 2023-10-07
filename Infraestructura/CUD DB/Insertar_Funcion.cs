using Aplicación.Interfaces.Infraestructura;
using Dominio;
using Infraestructura.EstructuraDB;

namespace Infraestructura.Inserts
{
    public class Insertar_Funcion : IAgregar
    {
        private readonly Contexto_Cine _Contexto;

        public Insertar_Funcion(Contexto_Cine contexto)
        {
            _Contexto = contexto;
        }

        void IAgregar.AlmacenarFuncion(Funciones funcion) //Recibe una funcion y la registra en la base de datos
        {
            _Contexto.Add(funcion);
            _Contexto.SaveChanges();
        }
    }
}
