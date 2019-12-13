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
    public class MunicipiosModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]      
        [Column("IdMunicipio")]
        [DataMember]
        public int IdMunicipio { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("NomeMunicipio")]
        [DataMember]
        public string NomeMunicipio { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int IdEstado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("IdEstado")]        
        public Estado Estado { get; private set; }

    }
}