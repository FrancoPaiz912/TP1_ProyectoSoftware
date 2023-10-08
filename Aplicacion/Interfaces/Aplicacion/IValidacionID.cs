namespace Aplicacion.Interfaces.Aplicacion
{
    public interface IValidacionID
    {
        Task<bool> ComprobarSalaId(int Id);

        Task<bool> ComprobarPeliculaId(int Id);
    }
}
