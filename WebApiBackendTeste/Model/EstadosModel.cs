using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiBackendTeste.Model
{
    [Table("Estados")]
    public class Estado : Recurso
    {
        [Key]
        [Column("IdEstado")]
        public int IdEstado { get; set; }

        [Column("Nome")]
        public string NomeEstado { get; set; }
        [Column("UF")]
        [MaxLength(2)]
        public string UF { get; set; }
    }
}