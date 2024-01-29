using AdminEquipoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminEquipoApi.Service
{
    public interface IAplicacion
    {
        Task<bool> AgregarAplicacion([FromBody] Aplicacion aplicacion);
        Task<List<Aplicacion>> ObtenerAplicacion();
        Task<bool> ActualizarAplicacion(int idapp, [FromBody] Aplicacion aplicacion);
        Task<bool> EliminarAplicación(int idapp);

    }
}
