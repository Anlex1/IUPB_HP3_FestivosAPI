using FestivosAPI.Core.Repositorio;
using FestivosAPI.Core.Servicios;
using FestivosAPI.Dominio.Entidades;
using FestivosAPI.Dominio.Entidades.DTO;

namespace FestivosAPI.Aplicacion
{
    public class FestivoServicio : IFestivoServicio
    {
        private readonly IFestivoRepositorio repositorio;

        public FestivoServicio(IFestivoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<Festivo> Agregar(Festivo festivo)
        {
            return await repositorio.Agregar(festivo);
        }

        public async Task<IEnumerable<Festivo>> Buscar(string Dato)
        {
            return await repositorio.Buscar(Dato);
        }

        public async Task<bool> Eliminar(int id)
        {
           return await repositorio.Eliminar(id);
        }

        public async Task<Festivo> Modificar(Festivo festivo)
        {
            return await repositorio.Modificar(festivo);
        }

        public async Task<Festivo> ObtenerPorId(int id)
        {
            return await repositorio.ObtenerPorId(id);
        }

        public async Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }

        public async Task<bool> EsFestivo(DateTime Fecha)
        {            
            var festivos = await ObtenerAño(Fecha.Year);            
            return festivos.Any(f => f.Fecha.Date == Fecha.Date);
        }

        private DateTime ObtenerDomingoPascua(int año)
        {
            int a = año % 19;
            int b = año / 100;
            int c = año % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            int mes = (h + l - 7 * m + 114) / 31;
            int dia = ((h + l - 7 * m + 114) % 31) + 1;

            return new DateTime(año, mes, dia);
        }

        private DateTime AgregarDias(DateTime fecha, int dias)
        {
            return fecha.AddDays(dias);
        }

        private DateTime SiguienteLunes(DateTime fecha)
        {
            DayOfWeek diaSemana = fecha.DayOfWeek;
            int diasLunes = ((int)DayOfWeek.Monday - (int)diaSemana + 7) % 7;
            return AgregarDias(fecha, diasLunes);
        }

        private FechaFestivo ObtenerFestivo(int año, Festivo festivo)
        {
            FechaFestivo fechaFestivo = null;
            switch (festivo.TipoId)
            {
                case 1:
                    fechaFestivo = new FechaFestivo
                    {
                        Fecha = new DateTime(año, festivo.Mes, festivo.Dia),
                        Nombre = festivo.Nombre
                    };
                    break;
                case 2:
                    fechaFestivo = new FechaFestivo
                    {
                        Fecha = SiguienteLunes(new DateTime(año, festivo.Mes, festivo.Dia)),
                        Nombre = festivo.Nombre
                    };
                    break;
                case 3:
                    fechaFestivo = new FechaFestivo
                    {
                        Fecha = AgregarDias(ObtenerDomingoPascua(año), festivo.DiaPascua),
                        Nombre = festivo.Nombre
                    };
                    break;
                case 4:
                    fechaFestivo = new FechaFestivo
                    {
                        Fecha = SiguienteLunes(AgregarDias(ObtenerDomingoPascua(año), festivo.DiaPascua)),
                        Nombre = festivo.Nombre
                    };
                    break;
            }
            return fechaFestivo;
        }

        public async Task<IEnumerable<FechaFestivo>> ObtenerAño(int Año)
        {
            var festivos = await repositorio.ObtenerTodos();

            List<FechaFestivo> fechaFestivos = new List<FechaFestivo>();
            foreach (var festivo in festivos)
            {
                fechaFestivos.Add(ObtenerFestivo(Año, festivo));
            }
            return fechaFestivos;
        }
    }
}
