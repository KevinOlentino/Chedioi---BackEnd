using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiBackendTeste.Model
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    [Table("Municipios")]
    public class MunicipiosModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]      
        [Column("IdMunicipio")]        
        public int IdMunicipio { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("NomeMunicipio")]
        [Required(ErrorMessage = "O nome do Municipío é Obrigatorio", AllowEmptyStrings = false)]
        public string NomeMunicipio { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("IdEstado")]
        [Required(ErrorMessage = "O nome do Estado é Obrigatório", AllowEmptyStrings = false)]
        public int IdEstado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("IdEstado")]        
        public Estado Estado { get; private set; }

    }
}