using FestivosAPI.Aplicacion;
using FestivosAPI.Core.Repositorio;
using FestivosAPI.Core.Servicios;
using FestivosAPI.Infraestructura.Repositorio;
using FestivosAPI.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace FestivosAPI.Presentacion.DI
{
    public static class InyeccionDependencias
    {

        public static IServiceCollection AgregarDependencias(this IServiceCollection servicios, IConfiguration configuracion)
        {
            //Agregar el DBContext
            servicios.AddDbContext<FestivosAPIContext>(opciones =>
            {
                opciones.UseSqlServer(configuracion.GetConnectionString("Festivos"));
            });

            //Agregar los repositorios
            servicios.AddTransient<ITipoRepositorio, TipoRepositorio>();
            servicios.AddTransient<IFestivoRepositorio, FestivoRepositorio>();

            //Agregar los servicios
            servicios.AddTransient<ITipoServicio, TipoServicio>();
            servicios.AddTransient<IFestivoServicio, FestivoServicio>();            

            return servicios;
        }
    }
}
