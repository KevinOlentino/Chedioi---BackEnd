using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiBackendTeste.Model
{ 
    [DataContract]
    public class LinkDTO
    {

        public int Id { get; set; }
        [DataMember]
        public string Href { get; set; }
        [DataMember]
        public string Rel { get; set; }
        [DataMember]
        public string Metodo { get; set; }
    }
}