﻿using Aplicacion.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Validaciones
{
    public static class ValidacionFecha
    {
        public static int Verificacion_Fecha(string Fecha) //Comprobacion de que tanto la fecha como la hora se ingresen correctamente.
        {
            try
            {
                //Fecha = Console.ReadLine();//Ya le debemos de haber pasado la hora
                DateTime Tiempo = DateTime.Parse(Fecha); //Se convierte a datetime ya que en caso de introducir un dato erroneo, se producirá la excepcion de formatException
                if (Tiempo.TimeOfDay != DateTime.Parse("00:00:00").TimeOfDay) //Se compara la hora para verificar que se haya ingresado un dia y no una hora
                {
                    throw new FechaException(""); //Si la hora es distinta a la 00:00:00, que se setea de esa manera en los datetime cuando solo se introduce fecha,
                }                                 // significa que en vez de una fecha se ingreso un dia. Por lo que se lanza una excepcion
            }
            catch (FormatException) //Control de excepcion de formato
            {
                return 1; //Si retorno 1 es que se produjo un error de formato, imprimo el mensaje en capa de presentacion
            }
            catch (FechaException) //Se controla la excepcion de ingresar la hora cuando no corresponde.
            {
                return 2; //Si retorno 1 es que se produjo un error, debido a que se ingreso una hora en lugar de una fecha. Imprimo el mensaje en capa de presentacion
            }
            return 0; //En caso de retornar 0, se ha ingresado correctamente una fecha
        }
    }
}
