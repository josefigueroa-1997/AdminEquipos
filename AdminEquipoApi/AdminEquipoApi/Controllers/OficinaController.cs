using Microsoft.AspNetCore.Mvc;
using AdminEquipoApi.Service;
using AdminEquipoApi.Models;

namespace AdminEquipoApi.Controllers
{
    [ApiController]
    [Route("Oficina")]
    public class OficinaController : ControllerBase
    {

        private readonly OficinaService oficinaService;

        public OficinaController(OficinaService oficinaService)
        {
            this.oficinaService = oficinaService;
        }


        [HttpPost]
        [Route("AddOficina")]
        public async Task <IActionResult> AddOficina([FromBody] Oficina oficina)
        {
            Boolean resultado = await oficinaService.AgregarOficina(oficina);

            if (resultado)
            {
                return Ok("¡Éxito en el registro!");
            }
            else
            {
                return BadRequest("Hubo un error en el registro");
            }
        }

        [HttpGet]
        [Route("GetOficinas/{id?}")]
        public async Task <IActionResult> GetOficinas(int? id)
        {
            try
            {
                var oficinas = await oficinaService.ObtenerOficinas(id);
                var oficinasdto = oficinaService.AgregarOficinaDTO(oficinas);
                return Ok(oficinasdto);
            }
            catch(Exception e)
            {
                return BadRequest($"Hubo un error en la consulta:{e.Message}");
            }
        }

        
    }
}
