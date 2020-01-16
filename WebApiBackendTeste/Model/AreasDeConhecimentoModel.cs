using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiBackendTeste.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Table("AreaDeConhecimento")]
    public class AreaDeConhecimento
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Column("IdArea")]
        public int IdAreaDeConhecimento { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("Descricao")]
        [Required(ErrorMessage = "O nome da área de conhecimento é Obrigatório", AllowEmptyStrings = false)]
        public string Descricao { get; set; }
    }
}