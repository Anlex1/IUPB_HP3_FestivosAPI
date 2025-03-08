using FestivosAPI.Dominio.Entidades;

namespace FestivosAPI.Core.Repositorio
{
    public interface IFestivoRepositorio
    {
        Task<IEnumerable<Festivo>> ObtenerTodos();
        Task<Festivo> ObtenerPorId(int id);
        Task<Festivo> Agregar(Festivo tipo);
        Task<Festivo> Modificar(Festivo tipo);
        Task<bool> Eliminar(int id);
    }
}
