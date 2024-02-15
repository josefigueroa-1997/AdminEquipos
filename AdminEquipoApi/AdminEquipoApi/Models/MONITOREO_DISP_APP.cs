using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace AdminEquipoApi.Models
{
    public class MONITOREO_DISP_APP
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ID_DISPOSITIVO_APP { get; set; }
        public string Estado_CPU { get; set; } = null!;
        public string Estado_RAM { get; set; } = null!;
        public string Estado_DISCODURO { get; set; } = null!;
        public string Estado_APLICACION { get; set; } = null!;

        [ForeignKey("ID_DISPOSITIVO_APP")]
        public virtual Dispositivo_Aplicacion? Dispositivo_Aplicacion { get; set; }

    }
}
