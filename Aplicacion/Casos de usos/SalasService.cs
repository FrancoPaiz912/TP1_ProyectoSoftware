using Aplicacion.Interfaces.Aplicacion;
using Aplicacion.Interfaces.Infraestructura.Consultas;
using Dominio;

namespace Aplicacion.Casos_de_usos
{
    public class SalasService : ISalasService
    {
        private readonly IConsultasSalas _Consultas;

        public SalasService(IConsultasSalas Consultas)
        {
            _Consultas = Consultas;
        }

        async Task<List<Salas>> ISalasService.ListarSalas()
        {
            return await _Consultas.GetSalas();
        }

        async Task<bool> ISalasService.ComprobarSalaId(int Id)
        {
            Salas? Result = await _Consultas.GetSalaById(Id);
            if (Result != null)
            {
                return true;
            }

            return false;
        }
    }
}
