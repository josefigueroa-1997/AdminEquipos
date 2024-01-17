using AdminEquipoApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdminEquipoApi.Controllers
{
    [ApiController]
    [Route("Region")]
    public class RegionController : ControllerBase
    {
        private readonly ADMINEQUIPOSDbContext dbContext;

        public RegionController(ADMINEQUIPOSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetRegiones")]
        public IActionResult GetRegiones()
        {
            var regiones = ObtenerRegiones();
            return Ok(regiones);
        }


        [HttpPost]
        [Route("AddRegion")]
        public IActionResult AddRegion([FromBody] Region nuevaregion)
        {
            try
            {
                var nuevo = new Region{

                    Nombre = nuevaregion.Nombre,

                };
                dbContext.Add(nuevo);
                dbContext.SaveChanges();
                return Ok("Se agregó con éxito la región");
            }
            catch (Exception ex) {

                Debug.WriteLine($"Error al crear la región: {ex.Message}");
                Debug.WriteLine($"StackTrace: {ex.StackTrace}");
                return StatusCode(500, "Error interno del servidor al crear la región.");

            }
        }

        [HttpPut]
        [Route("UpdateRegion/{idregion}")]
        public IActionResult UpdateRegion(int idregion, [FromBody] Region nuevonombre)
        {
            try
            {
                var region = dbContext.Regiones.FirstOrDefault(r => r.Id == idregion);
                if (region == null)
                {
                    return NotFound($"No se encontró la región con ID {idregion}");
                }

                region.Nombre = nuevonombre.Nombre;
                dbContext.SaveChanges();

                return Ok("Se cambió el nombre con exito de la región");
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error al eliminar la región: {e.Message}");
                Debug.WriteLine($"StackTrace: {e.StackTrace}");
                return StatusCode(500, "Error interno del servidor al eliminar la región.");
            }
        }

        [HttpDelete]
        [Route("DeleteRegion/{idregion}")]
        public IActionResult DeleteRegion(int idregion)
        {
            try
            {
                var region = dbContext.Regiones.FirstOrDefault(r => r.Id == idregion);

                if(region== null)
                {
                    return NotFound($"No se encontró la región con ID {idregion}");
                }
                dbContext.Regiones.Remove(region);
                dbContext.SaveChanges();
                return Ok($"Se eliminó la región con exito: Nombre:{region.Nombre}");
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error al eliminar la región: {e.Message}");
                Debug.WriteLine($"StackTrace: {e.StackTrace}");
                return StatusCode(500, "Error interno del servidor al eliminar la región.");
            }
        }


        private List<Region> ObtenerRegiones()
        {
            try
            {
                var regiones = dbContext.Regiones.Select(r => new Region
                {
                    Id = r.Id,
                    Nombre = r.Nombre,

                }).ToList();
                Debug.WriteLine($"cantidad de regiones:{regiones.Count} ");
                return regiones;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error en obtener las regiones:{e.Message}");
                Debug.WriteLine($"StackTrace: {e.StackTrace}");
                return new List<Region>();
            }
            
        }
    }
}
