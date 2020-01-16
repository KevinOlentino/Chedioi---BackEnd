using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiBackendTeste.Model.POCO;

namespace WebApiBackendTeste.Model.POCO
{
    /// <summary>
    /// 
    /// </summary>
    public class AreasDeConhecimentoPOCO
    {
        /// <summary>
        /// 
        /// </summary>
        public long IdAreaDeConhecimento { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Descricao { get; set; }

        public List<LinkDTO> Links { get; set; }
    }
}