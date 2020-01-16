using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiBackendTeste.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Profissão")]
    public class ProfissoesModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Column("idprofissao")]
        public int IdProfissao { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("descricao")]
        [Required(ErrorMessage = "Descrição obrigatória",AllowEmptyStrings =false)]
        public string Descricao { get; set; }
    }
}