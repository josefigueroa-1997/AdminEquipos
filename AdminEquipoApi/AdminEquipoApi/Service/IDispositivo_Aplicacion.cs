using AdminEquipoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminEquipoApi.Service
{
    public interface IDispositivo_Aplicacion
    {
        public Task<bool> AgregarAplicacionDispositivo([FromBody] Dispositivo_Aplicacion dispositivo_Aplicacion);
        public Task<List<Dispositivo_Aplicacion>> ObtenerAplicacionDispositivo();
        public Task<bool> ActualizarAplicacionDispositivo(int id, [FromBody] Dispositivo_Aplicacion dispositivo_Aplicacion);
        public Task<bool> EliminaraplicacionDispositivo(int id);
        
    }
}
