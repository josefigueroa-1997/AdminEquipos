using AdminEquipoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
namespace AdminEquipoApi.Service
{
    public  class AplicacionService : IAplicacion
    {
        private readonly ADMINEQUIPOSDbContext dbContext;

        public AplicacionService(ADMINEQUIPOSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AgregarAplicacion([FromBody] Aplicacion aplicacion)
        {
            try
            {
                if (dbContext.Aplicaciones.Where(a => a.Nombre == aplicacion.Nombre).Any())
                    return false;
                var nuevaaplicacion = new Aplicacion
                {
                    Nombre = aplicacion.Nombre,
                };
                dbContext.Add(nuevaaplicacion);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error al ingresar una aplicación:{e.Message}");
                return false;
            }
        }

        public async Task<List<Aplicacion>> ObtenerAplicacion()
        {
            try
            {
                var aplicacion = await dbContext.Aplicaciones.Select(a => new Aplicacion
                {
                    Id = a.Id,
                    Nombre = a.Nombre,

                }).ToListAsync();
                return aplicacion;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error al obtener los datos de aplicación: {e.Message}");
                return new List<Aplicacion>();
            }
            
            
        }
        public async Task<bool> ActualizarAplicacion(int idapp, [FromBody] Aplicacion aplicacion)
        {
            try
            {
                var app = dbContext.Aplicaciones.Where(a => a.Id == idapp).FirstOrDefault();
                if(app == null)
                {
                    return false;
                }
                if (dbContext.Aplicaciones.Where(a => a.Nombre == aplicacion.Nombre).Any())
                    return false;
                app.Nombre = aplicacion.Nombre;
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                Debug.Write($"Error al actualizar los datos de aplicación: {e.Message}");
                return false;
            }
            
        }
        public async Task<bool> EliminarAplicación(int idapp)
        {
            try
            {
                var app = dbContext.Aplicaciones.Where(a => a.Id == idapp).FirstOrDefault();
                if (app == null)
                    return false;
                else
                    dbContext.Aplicaciones.Remove(app);
                    await dbContext.SaveChangesAsync();
                    return true;
            }

            catch(Exception e)
            {
                Debug.WriteLine($"Error al eliminar una aplicación:{e.Message}");
                return false;
            }
            
        }
    }
}
