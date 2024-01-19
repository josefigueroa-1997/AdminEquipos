using AdminEquipoApi.Models;
using Microsoft.AspNetCore.Mvc;
using AdminEquipoApi.DTO;
namespace AdminEquipoApi.Service
{
    public interface IComuna
    {
        public bool AgregarComuna([FromBody] Comuna comuna);
        Task<List<Comuna>> ObtenerComuna(int? id);
        public List<ComunaDTO> AsignarCOMUNADTO(List<Comuna> comuna);
        Task<bool> EditarComuna(int id, [FromBody] Comuna comuna);
    }
}
