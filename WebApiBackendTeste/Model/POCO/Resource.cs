using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiBackendTeste.Model.POCO
{
    public class Resource
    {
        public long id { get; set; }
        public List<LinkDTO> Links { get; set; }

        public Resource()
        {
            Links = new List<LinkDTO>();
        }
    }
}