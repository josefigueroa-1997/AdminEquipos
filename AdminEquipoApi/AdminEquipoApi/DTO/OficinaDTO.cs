namespace AdminEquipoApi.DTO
{
    public class OficinaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int ID_COMUNA { get; set; }
        public string NombreComuna { get; set; } = null!;
        public int ID_REGION { get; set; }
        
    }
}
