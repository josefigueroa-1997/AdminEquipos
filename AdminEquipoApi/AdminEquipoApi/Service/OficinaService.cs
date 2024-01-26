using AdminEquipoApi.Models;
using AdminEquipoApi.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace AdminEquipoApi.Service
{
    public class OficinaService : IOficina
    {
        private readonly ADMINEQUIPOSDbContext dbContext;
        public OficinaService(ADMINEQUIPOSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AgregarOficina([FromBody] Oficina oficina)
        {
            try
            {
                if(dbContext.Oficinas.Where(o=>o.Nombre == oficina.Nombre).Any())
                {
                    return false;
                }
                if(oficina.Nombre.Trim() == "")
                {
                    return false;
                }
                var nuevaoficina = new Oficina
                {
                    ID_COMUNA = oficina.ID_COMUNA,
                    Nombre = oficina.Nombre,

                };
                dbContext.Add(nuevaoficina);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error al añadir la oficina:{e.Message}");
                return false;
            }
        }
        
        public async Task<List<Oficina>> ObtenerOficinas(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var oficinas = await dbContext.Oficinas.Where(o=>o.Id == id).Include(c=>c.Comuna).ThenInclude(r=>r.Region).Select(o => new Oficina
                    {
                        Id = o.Id,
                        ID_COMUNA = o.ID_COMUNA,
                        Nombre = o.Nombre,
                        Comuna = o.Comuna,
                        
                    }).ToListAsync();
                    return oficinas;
                }
                else
                {
                    var oficinas = await dbContext.Oficinas.Include(c => c.Comuna).ThenInclude(r => r.Region).Select(o => new Oficina
                    {
                        Id = o.Id,
                        ID_COMUNA = o.ID_COMUNA,
                        Nombre = o.Nombre,
                        Comuna = o.Comuna,

                    }).ToListAsync();
                    return oficinas;
                }
                
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error al obtener las oficinas: {e.Message}");
                return new List<Oficina>();
            }
        }

        public List<OficinaDTO> AgregarOficinaDTO(List<Oficina> oficinas)
        {
            try
            {
                var oficinasdto = oficinas.Select(o => new OficinaDTO
                {
                    Id = o.Id,
                    Nombre = o.Nombre,
                    ID_COMUNA = o.ID_COMUNA,
                    NombreComuna = o.Comuna != null ? o.Comuna.Nombre : "Sin Comuna",
                    ID_REGION = o.Comuna.Region.Id,
                }).ToList();

                return oficinasdto;
             
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new List<OficinaDTO>();
            }
        }

        public async Task<Boolean> ActualizarOficina(int idoficina, [FromBody] Oficina actualizaroficina)
        {
            try
            {
                var oficina = dbContext.Oficinas.Where(o => o.Id == idoficina).FirstOrDefault();
                if (oficina != null)
                {
                    oficina.Nombre = actualizaroficina.Nombre;
                    oficina.ID_COMUNA = actualizaroficina.ID_COMUNA;
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                else
                    return false;    
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
            
        }

        public async Task<bool> EliminarOficina(int id)
        {
            try
            {
                var oficina = dbContext.Oficinas.Where(o => o.Id == id).FirstOrDefault();
                if (oficina != null)
                {
                    dbContext.Oficinas.Remove(oficina);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                else
                    return false;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
            
        }

    }
}
