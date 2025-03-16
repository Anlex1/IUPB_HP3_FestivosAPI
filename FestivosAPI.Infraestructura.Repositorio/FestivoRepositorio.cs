using FestivosAPI.Dominio.Entidades;
using FestivosAPI.Persistencia.Contexto;
using FestivosAPI.Core.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace FestivosAPI.Infraestructura.Repositorio
{
    public class FestivoRepositorio: IFestivoRepositorio
    {
        private readonly FestivosAPIContext context;

        public FestivoRepositorio(FestivosAPIContext context)
        {
            this.context = context;
        }

        public Task<Festivo> Agregar(Festivo festivo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Festivo> Modificar(Festivo festivo)
        {
            var festivoExistente = await context.Festivos.FindAsync(festivo.Id);
            if (festivoExistente == null)
            {
                return null;
            }

            context.Entry(festivoExistente).CurrentValues.SetValues(festivo);
            return await context.Festivos.FindAsync(festivo.Id);
        }

        public async Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            return await context.Festivos.ToArrayAsync();
        }

        public async Task<Festivo> ObtenerPorId(int Id)
        {
            return await context.Festivos.FindAsync(Id);
        }
    }
}
