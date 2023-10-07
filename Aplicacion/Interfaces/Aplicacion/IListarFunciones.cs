﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Aplicacion
{
    public interface IListarFunciones
    {
        Task<List<Peliculas>> ListarPeliculas();
        Task<List<Salas>> ListarSalas();
    }
}
