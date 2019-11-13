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
    public class Estados : Link
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
    public abstract class Link
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Metodo { get; set; }
    }

}