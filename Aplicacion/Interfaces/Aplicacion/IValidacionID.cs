using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Aplicacion
{
    public interface IValidacionID
    {
        Task<bool> ComprobarSalaId(int Id);

        Task<bool> ComprobarPeliculaId(int Id);
    }
}
