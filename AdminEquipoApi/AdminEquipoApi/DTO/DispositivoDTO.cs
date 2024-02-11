namespace AdminEquipoApi.DTO
{
    public class DispositivoDTO
    {

        public int Id { get; set; }
        public string? tipodispositivo { get; set; }
        public string cpu { get; set; } = null!;
        public string ram { get; set; } = null!;
        public string disco_duro { get; set; } = null!;
        public int id_oficina { get; set; }
        public string nombreoficina { get; set; } = null!;

    }
}
