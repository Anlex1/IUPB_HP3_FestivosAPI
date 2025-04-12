using FestivosAPI.Dominio.Entidades;
using FestivosAPI.Dominio.Entidades.DTO;

namespace FestivosAPI.Core.Servicios
{
    public interface IFestivoServicio
    {
        Task<IEnumerable<Festivo>> ObtenerTodos();
        Task<Festivo> ObtenerPorId(int id);
        Task<IEnumerable<Festivo>> Buscar(string Dato);
        Task<Festivo> Agregar(Festivo festivo);
        Task<Festivo> Modificar(Festivo festivo);
        Task<bool> Eliminar(int id);

        // Consulta

        Task<IEnumerable<FechaFestivo>> ObtenerAño(int año);
        Task<bool> EsFestivo(DateTime fecha);
    }
}
