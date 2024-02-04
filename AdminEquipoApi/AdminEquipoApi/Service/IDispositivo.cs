using AdminEquipoApi.DTO;
using AdminEquipoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminEquipoApi.Service
{
    public interface IDispositivo
    {
        Task<bool> AgregarDispositivo([FromBody] Dispositivo dispositivo);
        Task<List<Dispositivo>> GetDispositivo(int? id);
        public List<DispositivoDTO> AgregarDispositivoDTO(List<Dispositivo> dispositivos);
        Task<bool> ActualizarDispositivo(int id, [FromBody] Dispositivo dispositivo);
        Task<bool> EliminarDispositivo(int id);

    }
}
