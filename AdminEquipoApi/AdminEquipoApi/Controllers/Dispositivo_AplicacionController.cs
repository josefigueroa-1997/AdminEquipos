using Microsoft.AspNetCore.Mvc;
using AdminEquipoApi.Service;
using AdminEquipoApi.Models;
namespace AdminEquipoApi.Controllers
{
    [ApiController]
    [Route("DispositivoApp")]
    public class Dispositivo_AplicacionController : ControllerBase
    {
        private readonly Dispositivo_AplicacionService _dispositivo_AplicacionService;
        public Dispositivo_AplicacionController(Dispositivo_AplicacionService dispositivo_AplicacionService)
        {
            this._dispositivo_AplicacionService = dispositivo_AplicacionService;
        }

        [Route("AddDispositivoApp")]
        [HttpPost]
        public async Task<IActionResult> AddDispositivoApp([FromBody] Dispositivo_Aplicacion dispositivo_Aplicacion)
        {
            bool resultado = await _dispositivo_AplicacionService.AgregarAplicacionDispositivo(dispositivo_Aplicacion);
            if (resultado)
                return Ok("Se agregó el registro de aplicación en dispositivo con éxito");
            else
                return BadRequest("Hubo un error al registrar la aplicación en el dispositivo");
        }



        [Route("GetDispositivoApp")]
        [HttpGet]
        public async Task<IActionResult> GetDispositivoApp()
        {
            var resultado = await _dispositivo_AplicacionService.ObtenerAplicacionDispositivo();
            return Ok(resultado);
        }



        [Route("UpdateDispositivoApp/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateDispositivoApp(int id, [FromBody] Dispositivo_Aplicacion dispositivo_Aplicacion)
        {
            Boolean resultado = await _dispositivo_AplicacionService.ActualizarAplicacionDispositivo(id, dispositivo_Aplicacion);
            if (resultado)
                return Ok("Se actualizaron los datos con éxito");
            else
                return BadRequest("Hubo un error al actualizar los datos de aplicación en el dispositivo");
        }



        [Route("DeleteDispositivoApp/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteDispositivoApp(int id)
        {
            bool resultado = await _dispositivo_AplicacionService.EliminaraplicacionDispositivo(id);
            if (resultado)
                return Ok("Se eliminó la aplicación del dispositivo con éxito");
            else
                return BadRequest("Hubo un error al eliminar la aplicación del dispositivo");
        }


    }
}
