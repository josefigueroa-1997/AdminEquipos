using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminEquipoApi.Models
{
    public partial class Aplicacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public virtual ICollection<Dispositivo_Aplicacion> Dispositivo_Aplicacions { get; set; } = new List<Dispositivo_Aplicacion>();
    }
}
