using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Tickets
    {
        public int TicketsId { get; set; }
        public int FuncionId { get; set; } 
        public string Usuario { get; set; }
        public Funciones Funciones { get; set; }
    }
}
