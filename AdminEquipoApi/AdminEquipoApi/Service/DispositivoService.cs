using AdminEquipoApi.DTO;
using AdminEquipoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AdminEquipoApi.Service
{
    public class DispositivoService : IDispositivo
    {
        private readonly ADMINEQUIPOSDbContext dbContext;

        public DispositivoService(ADMINEQUIPOSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AgregarDispositivo([FromBody] Dispositivo dispositivo)
        {
            try
            {
                if (dispositivo.Tipodispositivo.Trim() == "" || dispositivo.cpu.Trim() == "" || dispositivo.ram.Trim() == "" || dispositivo.disco_duro.Trim() == "")
                    return false;
                var nuevodispositivo = new Dispositivo
                {
                    Tipodispositivo = dispositivo.Tipodispositivo,
                    cpu = dispositivo.cpu,
                    ram = dispositivo.ram,
                    disco_duro = dispositivo.disco_duro,
                    ID_OFICINA = dispositivo.ID_OFICINA,
                };
                dbContext.Add(nuevodispositivo);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Hubo un error en agregar un dispositivo:{e.Message}");
                return false;
            }
        }

        public async Task<List<Dispositivo>> GetDispositivo(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var dispositivos = await dbContext.Dispositivos.Where(d=>d.Id == id).Include(o=>o.Oficina).Select(d => new Dispositivo
                    {
                        Id = d.Id,
                        Tipodispositivo = d.Tipodispositivo,
                        cpu = d.cpu,
                        ram = d.ram,
                        disco_duro = d.disco_duro,
                        Oficina = d.Oficina,
                    }).ToListAsync();
                    return dispositivos;
                }
                else
                {
                    var dispositivos = await dbContext.Dispositivos.Include(o => o.Oficina).Select(d => new Dispositivo
                    {
                        Id = d.Id,
                        Tipodispositivo = d.Tipodispositivo,
                        cpu = d.cpu,
                        ram = d.ram,
                        disco_duro = d.disco_duro,
                        Oficina = d.Oficina,
                    }).ToListAsync();
                    return dispositivos;
                }
                
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Hubo un error al traer los dispositivos:{e.Message}");
                return new List<Dispositivo>();
            }
        }
        public List<DispositivoDTO> AgregarDispositivoDTO(List<Dispositivo> dispositivos)
        {
            try
            {
                var dispositivodto = dispositivos.Select(d => new DispositivoDTO
                {
                    Id = d.Id,
                    tipodispositivo = d.Tipodispositivo,
                    cpu = d.cpu,
                    disco_duro = d.disco_duro,
                    ram = d.ram,
                    id_oficina = d.Oficina != null ? d.Oficina.Id : 0,
                    nombreoficina = d.Oficina != null ? d.Oficina.Nombre : "Sin Oficina",
                }).ToList();
                return dispositivodto;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Hubo un error al obtener los datos:{e.Message}");
                return new List<DispositivoDTO>();
            }
            
        }
        public async Task<bool> ActualizarDispositivo(int id, [FromBody] Dispositivo dispositivo)
        {
            try
            {
                var disp = dbContext.Dispositivos.Where(d => d.Id == id).FirstOrDefault();
                if (disp == null)
                    return false;
                else
                {
                    if (dispositivo.Tipodispositivo.Trim() == "" || dispositivo.cpu.Trim() == "" || dispositivo.ram.Trim() == "" || dispositivo.disco_duro.Trim() == "")
                        return false;
                    disp.Tipodispositivo = dispositivo.Tipodispositivo;
                    disp.disco_duro = dispositivo.disco_duro;
                    disp.ram = dispositivo.ram;
                    disp.cpu = dispositivo.cpu;
                    disp.ID_OFICINA = dispositivo.ID_OFICINA;
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                     
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Hubo un error al actualizar los datos del dispositivo:{e.Message}");
                return false;
            }
        }

        public async Task<bool> EliminarDispositivo(int id)
        {
            try
            {
                var dispositivo = dbContext.Dispositivos.Where(d=>d.Id==id).FirstOrDefault();
                if (dispositivo == null)
                    return false;
                dbContext.Dispositivos.Remove(dispositivo);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Hubo un error al eliminar el dispositivo:{e.Message}");
                return false;
            }
        }
    }
}
