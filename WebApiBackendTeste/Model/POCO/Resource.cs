using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiBackendTeste.Model.POCO
{
    /// <summary>
    /// 
    /// </summary>
    public class Resource
    {
        
      //  public long id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<LinkDTO> Links { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Resource()
        {
            Links = new List<LinkDTO>();
        }
    }
}