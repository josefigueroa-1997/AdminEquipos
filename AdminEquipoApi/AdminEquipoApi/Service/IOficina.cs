using AdminEquipoApi.DTO;
using AdminEquipoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminEquipoApi.Service
{
    public interface IOficina
    {
        Task<bool> AgregarOficina([FromBody] Oficina oficina);
        Task<List<Oficina>> ObtenerOficinas(int? id);
        public List<OficinaDTO> AgregarOficinaDTO(List<Oficina> oficinas);
        Task<Boolean> ActualizarOficina(int idoficina, [FromBody] Oficina oficina);
        Task<bool> EliminarOficina(int id);
    }
}
