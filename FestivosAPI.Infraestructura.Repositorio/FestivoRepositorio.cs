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

        public async Task<Festivo> Agregar(Festivo festivo)
        {
            context.Festivos.Add(festivo);
            await context.SaveChangesAsync();
            return festivo;
        }

        public async Task<bool> Eliminar(int Id)
        {
            var festivoExiste = await context.Festivos.FindAsync(Id);
            if (festivoExiste == null)
            {
                return false;
            }
            try
            {
                context.Festivos.Remove(festivoExiste);
                await context.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                return false;
            }
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
            // Hola gay, como estas.
            return await context.Festivos.FindAsync(Id);
        }
    }
}
