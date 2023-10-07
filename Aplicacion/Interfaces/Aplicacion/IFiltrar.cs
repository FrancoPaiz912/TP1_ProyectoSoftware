﻿using Aplicacion.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Aplicacion
{
    public interface IFiltrar
    {
        Task<List<Cartelera>> SolicitarFiltrado(string? Titulo, string? Fecha);

    }
}
