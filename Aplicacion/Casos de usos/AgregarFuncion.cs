using Aplicación.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aplicación.Casos_de_usos
{
    public class AgregarFuncion : IAgregarFuncion
    {
        private readonly IAgregar _Agregar;

        public AgregarFuncion(IAgregar agregar)
        {
            _Agregar = agregar;
        }
        void IAgregarFuncion.IntroducirFuncion()
        {
            Console.WriteLine("Por favor escoga la funcion a añadir de acuerdo a los siguientes parametros: \n Pelicula");

        }
    }
}
