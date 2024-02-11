using Microsoft.AspNetCore.Mvc;
using AdminEquipoApi.Service;
using AdminEquipoApi.Models;

namespace AdminEquipoApi.Controllers
{
    [ApiController]
    [Route("Dispositivo")]
    public class DispositivoController : ControllerBase
    {
        private readonly DispositivoService _dispositivoService;
        public DispositivoController(DispositivoService dispositivoService)
        {
            _dispositivoService = dispositivoService;
        }

        [HttpPost]
        [Route("AddDispositivo")]
        public async Task<IActionResult> AddDispositivo([FromBody] Dispositivo dispositivo)
        {
            Boolean resultado = await _dispositivoService.AgregarDispositivo(dispositivo);
            if (resultado)
                return Ok("Dispositivo añadido con éxito");
            else
                return BadRequest("Error al agregar el dispositivo");
        }

        [HttpGet]
        [Route("GetDispositivo/{id?}")]
        public async Task<IActionResult> GetDispositivo(int? id)
        {
            try
            {
                var dispositivo = await _dispositivoService.GetDispositivo(id);
                var resultado = _dispositivoService.AgregarDispositivoDTO(dispositivo);
                return Ok(resultado);
            }
            catch(Exception e)
            {
                return BadRequest($"Hubo un error al traer los datos del o los dispositivos:{e.Message}");
            }
        }

        [HttpPut]
        [Route("UpdateDispositivo/{id}")]
        public async Task<IActionResult> UpdateDispositivo(int id, [FromBody] Dispositivo dispositivo)
        {
            Boolean resultado = await _dispositivoService.ActualizarDispositivo(id,dispositivo);
            if (resultado)
                return Ok("¡Éxito en la actualización de los datos del dispositivo!");
            else
                return BadRequest("Hubo un error en la actualización de los datos del dispositivo");
        }

        [HttpDelete]
        [Route("DeleteDispositivo/{id}")]
        public async Task<IActionResult> DeleteDispositivo(int id)
        {
            bool resultado = await _dispositivoService.EliminarDispositivo(id);
            if (resultado)
                return Ok("Se eliminó el dispositivo con éxito");
            else
                return BadRequest("Error al eliminar el dispositivo");
        }

    }
}
