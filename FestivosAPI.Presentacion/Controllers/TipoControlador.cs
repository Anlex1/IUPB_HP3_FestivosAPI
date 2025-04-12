using FestivosAPI.Core.Servicios;
using FestivosAPI.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace apiFestivos.Presentacion.Controllers
{
    [ApiController]
    [Route("api/tipos")]
    public class TiposControlador : ControllerBase
    {
        private readonly ITipoServicio servicio;

        public TiposControlador(ITipoServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet("listar")]
        public async Task<IEnumerable<Tipo>> ObtenerTodos()
        {
            return await servicio.ObtenerTodos();
        }

        [HttpGet("obtener/{Id}")]
        public async Task<Tipo> Obtener(int Id)
        {
            return await servicio.ObtenerPorId(Id);
        }

        [HttpGet("buscar/{Dato}")]
        public async Task<IEnumerable<Tipo>> Buscar(string Dato)
        {
            return await servicio.Buscar(Dato);
        }

        [HttpPost("agregar")]
        public async Task<Tipo> Agregar([FromBody] Tipo Tipo)
        {
            return await servicio.Agregar(Tipo);
        }

        [HttpPut("modificar")]
        public async Task<Tipo> Modificar([FromBody] Tipo Tipo)
        {
            return await servicio.Modificar(Tipo);
        }

        [HttpDelete("eliminar/{Id}")]
        public async Task<bool> Eliminar(int Id)
        {
            return await servicio.Eliminar(Id);
        }
    }

}