﻿using Aplicacion.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Validaciones
{
    public static class ValidacionHorario 
    {
        public static int Verificacion_Horario(string Horario) //Comprobacion de que tanto la fecha como la hora se ingresen correctamente.
        {
            try
            {
                //Fecha = Console.ReadLine();//Ya le debemos de haber pasado la hora
                DateTime Hora = DateTime.Parse(Horario); //Se convierte a datetime ya que en caso de introducir un dato erroneo, se producirá la excepcion de formatException
                if (Hora.Day != DateTime.Now.Day) //Si se ingreso una fecha (cosa que no corresponde), se lanza una excepcion.
                {
                    throw new HorarioException("");//Si la fecha ingresada es distinta la del dia del ingreso de los datos, que se setea de esa manera cuando se introcude unicamente un horario,
                }                                  //significa que en vez de una fecha se ingreso un dia. Por lo que se lanza una excepcion
            }
            catch (FormatException) //Control de excepcion de formato
            {
                return 1; //Si retorno 1 es que se produjo un error de formato, imprimo el mensaje en capa de presentacion
            }
            catch (HorarioException) //Se controla la excepcion de ingresar la hora cuando no corresponde.
            {
                return 2; //Si retorno 1 es que se produjo un error, debido a que se ingreso una fecha en lugar de un horario. Imprimo el mensaje en capa de presentacion
            }
            return 0; //En caso de retornar 0, se ha ingresado correctamente un horario
        }
    }
}
