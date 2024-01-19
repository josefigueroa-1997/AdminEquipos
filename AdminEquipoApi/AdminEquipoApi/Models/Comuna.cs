using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AdminEquipoApi.Models
{
    public partial class Comuna
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ID_REGION { get; set; }
        public string Nombre { get; set; } = null!;
        [ForeignKey("ID_REGION")]
        
        public virtual Region? Region { get; set; }
    }
}
