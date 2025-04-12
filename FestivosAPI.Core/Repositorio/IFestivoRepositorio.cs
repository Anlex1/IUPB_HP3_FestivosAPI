using FestivosAPI.Dominio.Entidades;

namespace FestivosAPI.Core.Repositorio
{
    public interface IFestivoRepositorio
    {
        Task<IEnumerable<Festivo>> ObtenerTodos();
        Task<Festivo> ObtenerPorId(int id);
        Task<IEnumerable<Festivo>> Buscar(string Dato);
        Task<Festivo> Agregar(Festivo festivo);
        Task<Festivo> Modificar(Festivo festivo);
        Task<bool> Eliminar(int id);
    }
}
