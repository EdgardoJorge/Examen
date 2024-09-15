using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenData.DataBase.Tables
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(100)]
        public string ApellidoPaterno { get; set; }
        [Required]
        [StringLength(100)]
        public string ApellidoMaterno { get; set; }
        [Required]
        [StringLength(50)]
        public string EMail { get; set; }
        [Required]
        [StringLength(8)]
        public string DNI { get; set; }
    }
}
