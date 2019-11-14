using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiBackendTeste.Model
{

    public class Recurso
    {      
        public List<LinkDTO> Links { get; set; } = new List<LinkDTO>();
    }
}