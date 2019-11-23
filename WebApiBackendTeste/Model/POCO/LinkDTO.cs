using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiBackendTeste.Model
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class LinkDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Href { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]        
        public string Rel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Metodo { get; set; }
    }
}