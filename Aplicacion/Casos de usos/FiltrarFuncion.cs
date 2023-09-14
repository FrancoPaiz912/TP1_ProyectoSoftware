using Aplicacion.Interfaces.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Casos_de_usos
{
    public class FiltrarFuncion : IFiltrarFunciones
    {
        private readonly IFiltrarPeliculas _Filtrar;
        private readonly IVerificacionTemporal _verificador;
        public FiltrarFuncion(IFiltrarPeliculas filtro, IVerificacionTemporal verificador)
        {
            _Filtrar = filtro;
            _verificador = verificador;
        }
        public FiltrarFuncion()
        {

        }

        List<Cartelera> IFiltrarFunciones.FiltrarFunciones(List<Cartelera> carteleras, bool controlador)
        {
            Console.Clear();
            Console.WriteLine("Por favor, ingrese la fecha en la cual desea conocer las funciones \nEn formato dd/mm ó ingresando los dias en formato numerico y los meses en texto(EJ: 12 de Septiembre)\n");
            var respuesta = "no";
            var func = _verificador.Verificacion(true);
            var Funciones = carteleras.Where(p => p.Fecha == func).ToList();
            if (!controlador)
            {
                Console.WriteLine("¿Desea conocer todas las funciones de una determinada pelicula para el día " + func.Date.ToShortDateString() + "?\n");
                respuesta = Console.ReadLine().ToLower();
                controlador = true;
            }
            if (controlador && respuesta == "si")
            {
                return _Filtrar.FiltrarPeliculas(Funciones, controlador);
            }
            else
            {
                return Funciones;
            }
        }
    }
}
