using AdminEquipoApi.Models;
using AdminEquipoApi.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AdminEquipoApi.Service
{
    public interface IMonitoreo
    {
        public Task<bool> RegistrarMonitoreo([FromBody] MONITOREO_DISP_APP mONITOREO_DISP_APP);
        public Task<List<MONITOREO_DISP_APP>> ObtenerMonitoreo(int? id);
        public List<MonitoreoDTO> AgregarMonitoreoDTO(List<MONITOREO_DISP_APP> mONITOREO_DISP_APPs);
        public Task<Boolean> ActualizarMonitoreo(int id, [FromBody] MONITOREO_DISP_APP mONITOREO_DISP_);
        public Task<bool> EliminarMonitoreo(int id);

    }
}
