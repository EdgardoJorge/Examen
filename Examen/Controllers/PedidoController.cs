using Microsoft.AspNetCore.Mvc;
using ExamenData.DataBase;
using ExamenData.DataBase.Tables;
using System.Reflection;

namespace Examen.Controllers
{
    [ApiController]
    [Route("api/Pedidos")]
    public class PedidoController : ControllerBase
    {
        private readonly MiDbContext _db;
        public PedidoController(MiDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("")]
        public IActionResult ListarPedidos()
        {
            var Pedidos = _db.Pedidos.ToList();

            return Ok(Pedidos);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult ObtenerPedido([FromRoute] int id)
        {
            var Pedido = _db.Pedidos.Find(id);
            if (Pedido == null)
            {
                return NotFound();
            }

            return Ok(Pedido);
        }
        [HttpPost]
        [Route("")]
        public IActionResult CrearPedido([FromBody] Pedido body)
        {
            _db.Pedidos.Add(body);
            int r = _db.SaveChanges();
            if (r != 1)
            {
                return StatusCode(500);
            }
            return Ok(body);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult ActualizarAdmi([FromRoute] int id, [FromBody] Pedido body)
        {

            var Pedido = _db.Pedidos.Find(id);
            if (Pedido == null)
            {
                return NotFound();
            }

            Pedido. total = body.total;
            Pedido.total = body.total;


            int r = _db.SaveChanges();
            if (r != 1)
            {
                return StatusCode(500);
            }
            return NoContent();
        }



        [HttpDelete]
        [Route("{id}")]
        public IActionResult EliminarPedido([FromRoute] int id)
        {
            var Pedido = _db.Pedidos.Find(id);
            if (Pedido == null)
            {
                return NotFound();
            }
            _db.Pedidos.Remove(Pedido);
            int r = _db.SaveChanges();


            if (r != 1)
            {
                return StatusCode(500);
            }
            return NoContent();
        }
        
    }
}
