using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminEquipoApi.Models
{
    public partial class Dispositivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ID_OFICINA { get; set; }
        public string Tipodispositivo { get; set; } = null!;
        public string cpu { get; set; } = null!;
        public string disco_duro { get; set; } = null!;
        public string ram { get; set; } = null!;
        [ForeignKey("ID_OFICINA")]
        public virtual Oficina? Oficina{ get; set; }
    }
}
