using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenData.DataBase.Tables
{
    [Table("DetallePedidos")]
    public class DetallePedido
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int cantidad { get; set; }
        [Required]
        public int id_pedido { get; set; }
        [Required]
        public int id_producto {  get; set; }
    }
}
