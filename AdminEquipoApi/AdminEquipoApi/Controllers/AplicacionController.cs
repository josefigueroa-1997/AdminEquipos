using AdminEquipoApi.Models;
using AdminEquipoApi.Service;

using Microsoft.AspNetCore.Mvc;

namespace AdminEquipoApi.Controllers
{
    [ApiController]
    [Route("Aplicacion")]
    public class AplicacionController : ControllerBase
    {
        private readonly AplicacionService aplicacionService;
        public AplicacionController(AplicacionService aplicacionService)
        {
            this.aplicacionService = aplicacionService;
        }

        [Route("AddAplicacion")]
        [HttpPost]
        public async Task<IActionResult> AddAplicación([FromBody] Aplicacion aplicacion)
        {
            bool resultado = await aplicacionService.AgregarAplicacion(aplicacion);
            if (resultado)
                return Ok("¡Éxito en agregar la aplicación!");
            else
                return BadRequest("Hubo un error al añadir una aplicación");
        }

        [Route("GetAplicacion")]
        [HttpGet]
        public async Task<IActionResult> GetAplicacion()
        {
            try
            {
                var app = await aplicacionService.ObtenerAplicacion();
                return Ok(app);
            }
            catch(Exception e)
            {
                return BadRequest($"Hubo un error al obtener los datos: {e.Message}");
            }
        }
        [Route("UpdateAplicacion/{id}")]
        [HttpPut]
        public async Task <IActionResult> UpdateAplicacion(int id, [FromBody] Aplicacion aplicacion)
        {
            bool resultado = await aplicacionService.ActualizarAplicacion(id, aplicacion);
            if (resultado)
                return Ok("¡Éxito en la actualización de los de la aplicacion!");
            else
                return BadRequest("Hubo un error al intentar actualizar los datos");
        }
        [Route("DeleteAplicacion/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAplicacion(int id)
        {
            bool res = await aplicacionService.EliminarAplicación(id);
            if (res)
                return Ok("¡Éxito en la eliminación de la aplicación!");
            else
                return BadRequest("Hubo un error en la eliminación de la aplicación");
        }
    }
}
