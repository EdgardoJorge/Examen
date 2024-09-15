using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenData.DataBase.Tables
{
    [Table ("Productos")]
    public class Producto
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        public double precio { get; set; }
        [Required]
        public int stock { get; set; }

    }
}
