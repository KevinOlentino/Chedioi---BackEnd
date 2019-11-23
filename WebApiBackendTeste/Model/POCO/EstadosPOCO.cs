using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiBackendTeste.Model.POCO;

namespace WebApiBackendTeste.Model
{
    public class EstadosPOCO : Resource
    {
        public long IdEstado { get; set; }
        public string NomeEstado { get; set; }
        public string UF { get; set; }
    }
}