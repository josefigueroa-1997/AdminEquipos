namespace AdminEquipoApi.DTO
{
    public class MonitoreoDTO
    {
        public int Id { get; set; }
        public int ID_DISPOSITIVO_APP { get; set; }
        public string Estado_CPU { get; set; } = null!;
        public string Estado_RAM { get; set; } = null!;
        public string Estado_DISCODURO { get; set; } = null!;
        public string Estado_APLICACION { get; set; } = null!;
        public string tipodispositivo { get; set; } = null!;
        public string nombreapp { get; set; } = null!;



    }
}
