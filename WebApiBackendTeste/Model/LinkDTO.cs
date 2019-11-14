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

        public int Id { get; private set; }
        [DataMember]
        public string Href { get; private set; }
        [DataMember]
        public string Rel { get; private set; }
        [DataMember]
        public string Metodo { get; private set; }
        public LinkDTO(string href, string rel, string metodo)
        {
            Href = href;
            Rel = rel;
            Metodo = metodo;
        }
    }
}