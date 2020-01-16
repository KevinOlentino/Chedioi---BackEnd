using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiBackendTeste.Model.POCO
{
    /// <summary>
    /// 
    /// </summary>
    public class MunicipiosPOCO
    {
        /// <summary>
        /// 
        /// </summary>
        public int IdMunicipio { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NomeMunicipio { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Estado Estado { get; set; }
        public List<LinkDTO> Links { get; set; }
    }
}