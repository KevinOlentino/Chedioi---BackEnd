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
        [Required(ErrorMessage ="O nome do Estado é Obrigatorio", AllowEmptyStrings = false)]
        public string NomeEstado { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Column("UF")]
        [MaxLength(2)]
        [Required(ErrorMessage = "A unidade federativa é Obrigatoria", AllowEmptyStrings = false)]
        public string UF { get; set; }
    }
}