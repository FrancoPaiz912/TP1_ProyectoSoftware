﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Salas
    {
        public int SalasId { get; set; } 
        public string Nombre { get; set; } 
        public int Capacidad { get; set; } 
        public ICollection<Funciones> Funciones { get; set; }
    }
}
