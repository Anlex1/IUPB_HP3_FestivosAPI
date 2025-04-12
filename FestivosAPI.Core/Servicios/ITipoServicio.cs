using FestivosAPI.Dominio.Entidades;
namespace FestivosAPI.Core.Servicios
{
    public interface ITipoServicio
    {
        Task<IEnumerable<Tipo>> ObtenerTodos();
        Task<Tipo> ObtenerPorId(int id);
        Task<IEnumerable<Tipo>> Buscar(string Dato);
        Task<Tipo> Agregar(Tipo tipo);
        Task<Tipo> Modificar(Tipo tipo);
        Task<bool> Eliminar(int id);
    }
}
