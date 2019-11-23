using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiBackendTeste.Model
{
    [Table("Estados")]
    public class Estado
    {
        [Key]
        [Column("IdEstado")]
        public int IdEstado { get; set; }

        [Column("Nome")]
        [Required]
        public string NomeEstado { get; set; }
        
        [Column("UF")]
        [MaxLength(2)]
        [Required]
        public string UF { get; set; }
    }
}