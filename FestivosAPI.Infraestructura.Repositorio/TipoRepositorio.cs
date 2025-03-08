using FestivosAPI.Core.Repositorio;
using FestivosAPI.Persistencia.Contexto;
using FestivosAPI.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;


namespace FestivosAPI.Infraestructura.Repositorio
{
    public class TipoRepositorio : ITipoRepositorio
    {
        private readonly FestivosAPIContext context;

        public TipoRepositorio(FestivosAPIContext context)
        {
            this.context = context;
        }

        public Task<Tipo> Agregar(Tipo Tipo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Tipo> Modificar(Tipo seleccion)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tipo>> ObtenerTodos()
        {
            return await context.Tipos.ToArrayAsync();
        }

        public async Task<Tipo> ObtenerPorId(int Id)
        {
            return await context.Tipos.FindAsync(Id);
        }
    }
}
