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

        public async Task<Tipo> Agregar(Tipo TipoFestivo)
        {
            context.Tipos.Add(TipoFestivo);
            await context.SaveChangesAsync();
            return TipoFestivo;
        }

        public async Task<bool> Eliminar(int Id)
        {
            var tipoExiste = await context.Tipos.FindAsync(Id);
            if (tipoExiste == null)
            {
                return false;
            }
            try
            {
                context.Tipos.Remove(tipoExiste);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Tipo> Modificar(Tipo tipoFestivo)
        {
            var tipoFestivoExistente = await context.Tipos.FindAsync(tipoFestivo.Id);
            if (tipoFestivoExistente == null)
            {
                return null;
            }

            context.Entry(tipoFestivoExistente).CurrentValues.SetValues(tipoFestivo);
            await context.SaveChangesAsync();
            return await context.Tipos.FindAsync(tipoFestivo.Id);
        }

        public async Task<IEnumerable<Tipo>> ObtenerTodos()
        {
            return await context.Tipos.ToArrayAsync();
        }
        
        public async Task<Tipo> ObtenerPorId(int Id)
        {
            return await context.Tipos.FindAsync(Id);
        }

        public async Task<IEnumerable<Tipo>> Buscar(string Dato)
        {
            return await context.Tipos
                .Where(item => item.Descripcion.Contains(Dato)) 
                .ToListAsync(); 
        }
    }
}
