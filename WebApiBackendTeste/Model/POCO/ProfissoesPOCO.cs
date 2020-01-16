using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiBackendTeste.Model.POCO
{
    /// <summary>
    /// 
    /// </summary>
    public class ProfissoesPOCO
    {
        /// <summary>
        /// 
        /// </summary>
        public int idprofissao { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string descricao { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<LinkDTO> links { get; set; }
    }
}