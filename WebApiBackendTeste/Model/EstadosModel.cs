using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiBackendTeste.HateOAS;

namespace WebApiBackendTeste.Model
{
    [Table("Estados")]
    public class Estado : Link
    {
        [Key]
        [Column("IdEstado")]
        public int IdEstado { get; set; }

        [Column("Nome")]
        public string NomeEstado { get; set; }
        [Column("UF")]
        [MaxLength(2)]
        public string UF { get; set; }
    }
}