
namespace AdminEquipoApi.DTO
{
    public class ComunaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int ID_REGION { get; set; }
        
        public string NombreRegion { get; set; } = null!;
    }
}
