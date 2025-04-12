using FestivosAPI.Core.Servicios;
using FestivosAPI.Dominio.Entidades.DTO;
using FestivosAPI.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace FestivosAPI.Presentacion.Controllers
{
    public class FestivoControlador
    {
        [ApiController]
        [Route("api/festivos")]

        public class FestivosControlador : ControllerBase
        {
            private readonly IFestivoServicio servicio;

            public FestivosControlador(IFestivoServicio servicio)
            {
                this.servicio = servicio;
            }

            [HttpGet("listar")]
            public async Task<IEnumerable<Festivo>> ObtenerTodos()
            {
                return await servicio.ObtenerTodos();
            }

            [HttpGet("obtener/{Id}")]
            public async Task<Festivo> ObtenerPorId(int Id)
            {
                return await servicio.ObtenerPorId(Id);
            }

            [HttpGet("buscar/{Dato}")]
            public async Task<IEnumerable<Festivo>> Buscar(string Dato)
            {
                return await servicio.Buscar(Dato);
            }

            [HttpPost("agregar")]
            public async Task<Festivo> Agregar([FromBody] Festivo Festivo)
            {
                return await servicio.Agregar(Festivo);
            }

            [HttpPut("modificar")]
            public async Task<Festivo> Modificar([FromBody] Festivo Festivo)
            {
                return await servicio.Modificar(Festivo);
            }

            [HttpDelete("eliminar/{Id}")]
            public async Task<bool> Eliminar(int Id)
            {
                return await servicio.Eliminar(Id);
            }

            //********** Consultas //**********

            [HttpGet("listar/{Year}")]
            public async Task<IEnumerable<FechaFestivo>> ObtenerAño(int Year)
            {
                return await servicio.ObtenerAño(Year);
            }

            [HttpGet("Verificar/{Year}/{Mes}/{Dia}")]
            public async Task<bool> EsFestivo(int Year, int Mes, int Dia)
            {
                // Validar que la fecha sea válida
                if (!DateTime.TryParse($"{Year}-{Mes}-{Dia}", out DateTime fecha))
                {
                    return false;
                }

                return await servicio.EsFestivo(fecha);
            }

        }
    }
}
