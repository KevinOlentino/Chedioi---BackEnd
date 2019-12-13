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
        public int IdEstado {get; set;}

        /// <summary>
        /// 
        /// </summary>
        public List <LinkDTO> Links { get; set; }
    }
}