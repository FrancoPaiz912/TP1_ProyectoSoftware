﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Aplicacion
{
    public interface IAgregarFunciones
    {
        void RegistrarFuncion(int IdPelicula, int IdSala, DateTime Fecha, TimeSpan Horario);
    }
}
