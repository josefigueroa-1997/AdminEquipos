using AdminEquipoApi.DTO;
using AdminEquipoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AdminEquipoApi.Service
{
    
    public class ComunaService : IComuna
    {
        private readonly ADMINEQUIPOSDbContext dbContext;

        public ComunaService(ADMINEQUIPOSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool AgregarComuna([FromBody] Comuna comuna)
        {
            bool resultado = false;
            try
            {

                if(dbContext.Comunas.Any(c=>c.Nombre == comuna.Nombre))
                {
                    resultado = false;
                }
                if(comuna.Nombre.Trim() == "")
                {
                    resultado = false;
                }
                else
                {
                    var nuevacomuna = new Comuna
                    {
                        ID_REGION = comuna.ID_REGION,
                        Nombre = comuna.Nombre,
                    };
                    dbContext.Add(nuevacomuna);
                    dbContext.SaveChanges();
                    resultado = true;
                }
                
                return resultado;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine($"Inner Exception: {e.InnerException?.Message}");
                Debug.WriteLine($"StackTrace: {e.StackTrace}");
                return resultado;
            }
        }

        public async Task<List<Comuna>> ObtenerComuna(int? id, int? idregion)
        {
            try
            {
                // Caso 1: Ambos id e idregion son nulos
                if (!id.HasValue && !idregion.HasValue)
                {
                    var comunas = await dbContext.Comunas
                        .Include(r => r.Region)
                        .Select(c => new Comuna
                        {
                            Id = c.Id,
                            ID_REGION = c.ID_REGION,
                            Nombre = c.Nombre,
                            Region = c.Region,
                        })
                        .ToListAsync();

                    return comunas;
                }

                // Caso 2: Solo id está presente
                if (id.HasValue && !idregion.HasValue)
                {
                    var comuna = await dbContext.Comunas
                        .Where(c => c.Id == id)
                        .Include(r => r.Region)
                        .Select(c => new Comuna
                        {
                            Id = c.Id,
                            ID_REGION = c.ID_REGION,
                            Nombre = c.Nombre,
                            Region = c.Region,
                        })
                        .FirstOrDefaultAsync();

                    if (comuna != null)
                    {
                        return new List<Comuna> { comuna };
                    }
                    else
                    {
                        return new List<Comuna>();
                    }
                }

                // Caso 3: Solo idregion está presente
                if (!id.HasValue && idregion.HasValue)
                {
                    
                    var comunas = await dbContext.Comunas
                        .Where(c => c.ID_REGION == idregion)
                        .Include(r => r.Region)
                        .Select(c => new Comuna
                        {
                            Id = c.Id,
                            ID_REGION = c.ID_REGION,
                            Nombre = c.Nombre,
                            Region = c.Region,
                        })
                        .ToListAsync();

                    return comunas;
                }

                // Otros casos (puedes agregar más casos según sea necesario)
                return new List<Comuna>();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new List<Comuna>();
            }
        }


        public List<ComunaDTO> AsignarCOMUNADTO(List<Comuna> comuna)
        {
            try
            {

                var comunaDTOs = comuna.Select(c => new ComunaDTO
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    ID_REGION = c.ID_REGION,
                    NombreRegion = c.Region != null ? c.Region.Nombre : "Sin región",
                }).ToList();
                return comunaDTOs;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new List<ComunaDTO>();
            }

        }
        public async Task<bool> EditarComuna(int id, [FromBody] Comuna actcomuna)
        {
            bool resultado = false;
            try
            {
                var comunaid =  dbContext.Comunas.Where(c => c.Id == id).FirstOrDefault();
                if (comunaid ==null)
                {
                    resultado = false;

                }
                else
                {
                    if (dbContext.Comunas.Any(r => r.Nombre == actcomuna.Nombre))
                    {
                        resultado = false;
                    }
                    else
                    {
                        comunaid.Nombre = actcomuna.Nombre;
                        comunaid.ID_REGION = actcomuna.ID_REGION;
                        await dbContext.SaveChangesAsync();
                        resultado = true;
                    }
                    
                }
                return resultado;

            }

            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return resultado;
            }
        }

        public async Task<bool> EliminarComuna(int id)
        {
            
            try
            {
                var comuna = dbContext.Comunas.Where(c => c.Id == id).FirstOrDefault();
                if (comuna == null)
                {
                   return false;
                }
                dbContext.Comunas.Remove(comuna);
                await dbContext.SaveChangesAsync();
                return true;

            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }

        }
    }
}
