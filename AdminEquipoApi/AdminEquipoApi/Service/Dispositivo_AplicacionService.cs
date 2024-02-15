using AdminEquipoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AdminEquipoApi.Service
{
    public class Dispositivo_AplicacionService : IDispositivo_Aplicacion
    {
        private readonly ADMINEQUIPOSDbContext dbContext;

        public Dispositivo_AplicacionService(ADMINEQUIPOSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AgregarAplicacionDispositivo([FromBody] Dispositivo_Aplicacion dispapp)
        {
            try
            {
                var nuevoappdisp = new Dispositivo_Aplicacion
                {
                    ID_Aplicacion = dispapp.ID_Aplicacion,
                    ID_Dispositivo = dispapp.ID_Dispositivo,
                    Fecha_instalacion = dispapp.Fecha_instalacion,
                };
                dbContext.Add(nuevoappdisp);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Hubo un error al agregar una aplicación:{e.Message}");
                Debug.WriteLine($"StackTrace: {e.StackTrace}");
                return false;
            }
        }

        public async Task<List<Dispositivo_Aplicacion>> ObtenerAplicacionDispositivo()
        {
            try
            {
                var dispapp = await dbContext.Dispositivo_Aplicacions.Select(da => new Dispositivo_Aplicacion
                {
                    Id = da.Id,
                    ID_Aplicacion = da.ID_Aplicacion,
                    ID_Dispositivo = da.ID_Dispositivo,
                    Fecha_instalacion = da.Fecha_instalacion,

                }).ToListAsync();
                return dispapp;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Hubo un error al obtener los datos de la aplicación y el dispositivo:{e.Message}");
                Debug.WriteLine($"StackTrace: {e.StackTrace}");
                return new List<Dispositivo_Aplicacion>();
            }
        }

        public async Task<bool> ActualizarAplicacionDispositivo(int id, [FromBody] Dispositivo_Aplicacion dispositivo_Aplicacion)
        {
            try
            {
                var dispapp = dbContext.Dispositivo_Aplicacions.Where(da => da.Id == id).FirstOrDefault();
                if (dispapp == null)
                {
                    return false;
                }
                dispapp.ID_Dispositivo = dispositivo_Aplicacion.ID_Dispositivo;
                dispapp.ID_Aplicacion = dispositivo_Aplicacion.ID_Aplicacion;
                dispapp.Fecha_instalacion = dispositivo_Aplicacion.Fecha_instalacion;
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Hubo un error al actualizar los datos de aplicación en dispositivo:{e.Message}");
                return false;
            }


        }

        public async Task<bool> EliminaraplicacionDispositivo(int id)
        {
            try
            {
                var dispapp = dbContext.Dispositivo_Aplicacions.Where(da => da.Id == id).FirstOrDefault();
                if (dispapp == null)
                {
                    return false;
                }
                dbContext.Dispositivo_Aplicacions.Remove(dispapp);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Hubo un error al eliminar la aplicación del dispositivo:{e.Message}");
                return false;

            }
            

        }

       

    }
}
