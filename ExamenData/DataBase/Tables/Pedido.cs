using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenData.DataBase.Tables
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime fechaPedido { get; set; }
        [Required]
        public float total {  get; set; }
        [Required]
        public int id_cliente {  get; set; } 
    }
}
