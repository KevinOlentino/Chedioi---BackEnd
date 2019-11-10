using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiBackendTeste.Model;

namespace WebApiBackendTeste.Controller
{
    public class EstadosController : ApiController
    {
      
        private static List<Estados> Estados = new List<Estados>();
        
        public List<Estados> Get()
        {
            
            return Estados;
        }
        [HttpPost]
        public void Post(Estados estados)
        {
           
            if (!string.IsNullOrEmpty(estados.Descricao))
            {
                Estados.Add(new Estados());
            }
        }
        public void Delete(string Nome)
        {
            Estados.RemoveAt(Estados.IndexOf(Estados.FirstOrDefault(x => x.Descricao.Equals(Nome))));
        }
    }
}
