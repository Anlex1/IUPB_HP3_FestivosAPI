using FestivosAPI.Dominio.Entidades;


namespace FestivosAPI.Core.Repositorio
{
    public interface ITipoRepositorio
    {
        Task<IEnumerable<Tipo>> ObtenerTodos();
        Task<Tipo> ObtenerPorId(int id);
        Task<Tipo> Agregar(Tipo tipo);
        Task<Tipo> Modificar(Tipo tipo);
        Task<bool> Eliminar(int id);
    }
}
