using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiBackendTeste.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Estados")]
    public class Estado
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Column("IdEstado")]
        public int IdEstado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("Nome")]
        [Required]
        public string NomeEstado { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Column("UF")]
        [MaxLength(2)]
        [Required]
        public string UF { get; set; }
    }
}