using AdminEquipoApi.Models;
using AdminEquipoApi.Service;

using Microsoft.AspNetCore.Mvc;


namespace AdminEquipoApi.Controllers
{
    [ApiController]
    [Route("Monitoreo")]
    public class MonitoreoController : ControllerBase
    {

        private readonly MonitoreoSerivice monitoreoSerivice;
        public MonitoreoController(MonitoreoSerivice monitoreoSerivice)
        {
            this.monitoreoSerivice = monitoreoSerivice;
        }

        [HttpPost]
        [Route("AddMonitoreo")]
        public async Task<IActionResult> AddMonitoreo([FromBody] MONITOREO_DISP_APP monitoreo)
        {
            bool resultado = await monitoreoSerivice.RegistrarMonitoreo(monitoreo);
            if (resultado)
                return Ok("Exito en el registro del monitoreo");
            else
                return BadRequest("Hubo un error en el registro del monitoreo del dispositivo");
        }

        [HttpGet]
        [Route("GetMonitoreo/{id?}")]
        public async Task<IActionResult> GetMonitoreo(int? id)
        {
            var resultado = await monitoreoSerivice.ObtenerMonitoreo(id);
            var monitoreodto = monitoreoSerivice.AgregarMonitoreoDTO(resultado);
            return Ok(monitoreodto);
        }
        [HttpPut]
        [Route("UpdateMonitoreo/{id}")]
        public async Task<IActionResult> UpdateMonitoreo(int id, [FromBody] MONITOREO_DISP_APP monitoreo)
        {
            bool resultado = await monitoreoSerivice.ActualizarMonitoreo(id, monitoreo);
            if (resultado)
                return Ok("Exito en la actualización del registro del monitoreo");
            else
                return BadRequest("Hubo un error en la actualización en el registro del monitoreo del dispositivo");
        }
        [HttpDelete]
        [Route("DeleteMonitoreo/{id}")]
        public async Task<IActionResult> DeleteMonitoreo(int id)
        {
            bool resultado = await monitoreoSerivice.EliminarMonitoreo(id);
            if (resultado)
                return Ok("Se eliminó el registro del monitoreo con éxito");
            else
                return BadRequest("Hubo un error al eliminar el registro del monitoreo");
        }

    }
}
