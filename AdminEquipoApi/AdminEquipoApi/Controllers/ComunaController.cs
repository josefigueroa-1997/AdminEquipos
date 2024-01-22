using Microsoft.AspNetCore.Mvc;
using AdminEquipoApi.Service;
using AdminEquipoApi.Models;
using AdminEquipoApi.DTO;
namespace AdminEquipoApi.Controllers
{
    [ApiController]
    [Route("Comuna")]
    public class ComunaController : ControllerBase
    {
        private readonly ComunaService comunaService;
        public ComunaController(ComunaService comunaService)
        {
            this.comunaService = comunaService;
        }

        [HttpPost]
        [Route("AddComuna")]
        public IActionResult AddComuna([FromBody] Comuna comuna)
        {
            bool resultado = comunaService.AgregarComuna(comuna);
            if (resultado)
            {
                return Ok("¡Exito en el registro!");
            }
            else
            {
                return BadRequest("Error interno del servidor al crear la comuna.");
            }
        }

        [HttpGet]
        [Route("GetComunas/{id?}")]
        public async Task <IActionResult> GetComunas(int? id)
        {
            try
            {
                var comunas = await comunaService.ObtenerComuna(id);
                var comunasoto = comunaService.AsignarCOMUNADTO(comunas);
                return Ok(comunasoto);
            }
            catch (Exception e){

                return BadRequest($"Error interno del servidor al obtener las comunas.{e.Message}");

            }

            
        }
        [HttpPut]
        [Route("UpdateComuna/{id}")]
        public async Task <IActionResult> UpdateComuna(int id, [FromBody] Comuna comuna)
        {
            bool resultado = await comunaService.EditarComuna(id,comuna);
            
            if (resultado)
            {
                return Ok("¡Éxito en la acutalización!");
            }
            else
            {
                return BadRequest("Hubo un error en la actualización");
            }
        }

        [HttpDelete]
        [Route("DeleteComuna/{id}")]
        public async Task <IActionResult> DeleteComuna(int id)
        {
            bool resultado = await comunaService.EliminarComuna(id);
            if (resultado)
            {
                return Ok("La comuna fue eliminada con éxito");
            }
            else
            {
                return BadRequest("Hubo un error en la eliminación");
            }
        }
    }
}
