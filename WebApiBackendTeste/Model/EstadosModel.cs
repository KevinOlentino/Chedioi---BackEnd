using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiBackendTeste.Model
{
    [Table("Estados")]
    public class Estados
    {
        [Key]
        [Column("Id")]
        public int Idestado { get; set; }
        [Column("Descricao")]
        public string Descricao { get; set; }
        [Column("UF")]
        public string UF { get; set; }
    }
}