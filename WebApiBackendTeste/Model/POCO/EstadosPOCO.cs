using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiBackendTeste.Model.POCO;

namespace WebApiBackendTeste.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class EstadosPOCO
    {
        /// <summary>
        /// 
        /// </summary>
        public long IdEstado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NomeEstado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UF { get; set; }

        public List<LinkDTO> Links { get; set; }
    }
}