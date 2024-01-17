using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminEquipoApi.Models
{
    public partial class Oficina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ID_COMUNA { get; set; }
        public string Nombre { get; set; } = null!;
        [ForeignKey("ID_COMUNA")]
        public virtual Comuna? Comuna { get; set; }
        
    }
}
