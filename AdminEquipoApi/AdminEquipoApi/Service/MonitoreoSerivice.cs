using AdminEquipoApi.DTO;
using AdminEquipoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AdminEquipoApi.Service
{
    public class MonitoreoSerivice: IMonitoreo
    {
        private readonly ADMINEQUIPOSDbContext dbContext;
        public MonitoreoSerivice(ADMINEQUIPOSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> RegistrarMonitoreo([FromBody] MONITOREO_DISP_APP monitoreo)
        {
            try
            {
                if (monitoreo.Estado_CPU.Trim() == "" || monitoreo.Estado_RAM.Trim() == "" || monitoreo.Estado_DISCODURO.Trim() == "" || monitoreo.Estado_APLICACION.Trim() == "")
                    return false;
                var nuevomonitoreo = new MONITOREO_DISP_APP
                {
                    ID_DISPOSITIVO_APP = monitoreo.ID_DISPOSITIVO_APP,
                    Estado_CPU = monitoreo.Estado_CPU,
                    Estado_RAM = monitoreo.Estado_RAM,
                    Estado_DISCODURO = monitoreo.Estado_DISCODURO,
                    Estado_APLICACION = monitoreo.Estado_APLICACION,
                };
                dbContext.Add(monitoreo);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Hubo un error al registrar el monitoreo:{e.Message}");
                return false;
            }

            
        }
        public async Task<List<MONITOREO_DISP_APP>> ObtenerMonitoreo(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var monitoreos = await dbContext.MONITOREO_DISP_APPs.Where(m => m.Id == id).Include(d=>d.Dispositivo_Aplicacion).ThenInclude(d => d.Dispositivo).Select(m => new MONITOREO_DISP_APP
                    {
                        Id = m.Id,
                        ID_DISPOSITIVO_APP = m.ID_DISPOSITIVO_APP,
                        Estado_CPU = m.Estado_CPU,
                        Estado_RAM = m.Estado_RAM,
                        Estado_DISCODURO = m.Estado_DISCODURO,
                        Estado_APLICACION = m.Estado_APLICACION,
                        Dispositivo_Aplicacion = m.Dispositivo_Aplicacion,
                    }).ToListAsync();
                    return monitoreos;
                }
                else
                {
                    var monitoreos = await dbContext.MONITOREO_DISP_APPs.Include(d=>d.Dispositivo_Aplicacion).ThenInclude(d=>d.Dispositivo).Select(m => new MONITOREO_DISP_APP
                    {
                        Id = m.Id,
                        ID_DISPOSITIVO_APP = m.ID_DISPOSITIVO_APP,
                        Estado_CPU = m.Estado_CPU,
                        Estado_RAM = m.Estado_RAM,
                        Estado_DISCODURO = m.Estado_DISCODURO,
                        Estado_APLICACION = m.Estado_APLICACION,
                        Dispositivo_Aplicacion = m.Dispositivo_Aplicacion,
                    }).ToListAsync();
                    return monitoreos;
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Hubo un error al obtener los registros del monitoreo del dispositivo:{e.Message}");
                return new List<MONITOREO_DISP_APP>();
            }
            
        }
        public List<MonitoreoDTO> AgregarMonitoreoDTO(List<MONITOREO_DISP_APP> mONITOREO_DISP_APPs)
        {
            try
            {
                var monitoreosdto = mONITOREO_DISP_APPs.Select(mdto => new MonitoreoDTO
                {
                    Id = mdto.Id,
                    ID_DISPOSITIVO_APP = mdto.ID_DISPOSITIVO_APP,
                    Estado_CPU = mdto.Estado_CPU,
                    Estado_RAM = mdto.Estado_RAM,
                    Estado_DISCODURO = mdto.Estado_DISCODURO,
                    Estado_APLICACION = mdto.Estado_APLICACION,

                    tipodispositivo = mdto.Dispositivo_Aplicacion != null && mdto.Dispositivo_Aplicacion.Dispositivo != null
                    ? mdto.Dispositivo_Aplicacion.Dispositivo.Tipodispositivo
                    : "NO TIENE TIPO DISPOSITIVO",

                   
            }).ToList();
                return monitoreosdto;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Hubo un error al obtener los registros del monitoreo:{e.Message}");
                return new List<MonitoreoDTO>();
            }
        }
        public async Task<Boolean> ActualizarMonitoreo(int id, [FromBody] MONITOREO_DISP_APP mon)
        {
            try
            {
                var monitoreo = dbContext.MONITOREO_DISP_APPs.Where(m=>m.Id==id).FirstOrDefault();
                if(monitoreo == null)
                {
                    return false;
                }
                else
                {
                    if (monitoreo.Estado_CPU.Trim() == "" || monitoreo.Estado_RAM.Trim() == "" || monitoreo.Estado_DISCODURO.Trim() == "" || monitoreo.Estado_APLICACION.Trim() == "")
                        return false;
                    monitoreo.ID_DISPOSITIVO_APP = mon.ID_DISPOSITIVO_APP;
                    monitoreo.Estado_CPU = mon.Estado_CPU;
                    monitoreo.Estado_RAM = mon.Estado_RAM;
                    monitoreo.Estado_DISCODURO = mon.Estado_DISCODURO;
                    monitoreo.Estado_APLICACION = mon.Estado_APLICACION;
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Hubo un error al actualizar los registros del monitoreo:{e.Message}");
                return false;
            }
        }
        public async Task<bool> EliminarMonitoreo(int id)
        {
            try
            {
                var monitoreo = dbContext.MONITOREO_DISP_APPs.Where(m => m.Id == id).FirstOrDefault();
                if (monitoreo == null)
                {
                    Debug.WriteLine("No existe el registro del monitoreo");
                    return false;
                }
                dbContext.MONITOREO_DISP_APPs.Remove(monitoreo);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Hubo un error al eliminar el registro del monitoreo:{e.Message}");
                return false;
            }
            

        }


    }
}
