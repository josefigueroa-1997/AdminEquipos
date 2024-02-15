using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdminEquipoApi.Models
{
    public class Dispositivo_Aplicacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ID_Aplicacion { get; set; }
        public int ID_Dispositivo { get; set; }
        public DateTime Fecha_instalacion { get; set; }
        [ForeignKey("ID_Aplicacion")]
        public virtual Aplicacion? Aplicacion { get; set; }
        [ForeignKey("ID_Dispositivo")]
        public virtual Dispositivo? Dispositivo { get; set; }

    }
}
