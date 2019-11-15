using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiBackendTeste.Model
{
    public interface class ColecaoRecursos<T> : Recurso where T : Recurso
    {
        public List<T> Estados { get; set; }
        public ColecaoRecursos(List<T> estado)
        {
            Estados = estado;
        }
    }
}
