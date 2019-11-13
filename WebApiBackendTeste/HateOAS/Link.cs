using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WebApiBackendTeste.Context;

namespace WebApiBackendTeste.HateOAS
{
    public class Link
    {        
     
        [Key]
        public int Id { get;  set; }
        public string Href { get; set; }
        public string Rel { get;  set; }
        public string Metodo { get;  set; }
      /*  public Link(string href, string rel, string metodo)
        {
            Href = href;
            Rel = rel;
            Metodo = metodo;
        }*/
    }
    public class Resource
    {
        public List<Link> Link { get; set; } = new List<Link>();
    }
}