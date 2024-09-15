using Microsoft.AspNetCore.Mvc;
using ExamenData.DataBase;
using ExamenData.DataBase.Tables;
using System.Reflection;

namespace Examen.Controllers
{
    [ApiController]
    [Route("api/DetallePedidos")]
    public class DetallePedidoController : ControllerBase
    {
        private readonly MiDbContext _db;
        public DetallePedidoController(MiDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("")]
        public IActionResult ListarDetallePedidos()
        {
            var DetallePedidos = _db.DetallePedidos.ToList();

            return Ok(DetallePedidos);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult ObtenerDetallePedido([FromRoute] int id)
        {
            var DetallePedido = _db.DetallePedidos.Find(id);
            if (DetallePedido == null)
            {
                return NotFound();
            }

            return Ok(DetallePedido);
        }
        [HttpPost]
        [Route("")]
        public IActionResult CrearDetallePedido([FromBody] DetallePedido body)
        {
            _db.DetallePedidos.Add(body);
            int r = _db.SaveChanges();
            if (r != 1)
            {
                return StatusCode(500);
            }
            return Ok(body);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult ActualizarAdmi([FromRoute] int id, [FromBody] DetallePedido body)
        {

            var DetallePedido = _db.DetallePedidos.Find(id);
            if (DetallePedido == null)
            {
                return NotFound();
            }

            DetallePedido.cantidad = body.cantidad;


            int r = _db.SaveChanges();
            if (r != 1)
            {
                return StatusCode(500);
            }
            return NoContent();
        }



        [HttpDelete]
        [Route("{id}")]
        public IActionResult EliminarDetallePedido([FromRoute] int id)
        {
            var DetallePedido = _db.DetallePedidos.Find(id);
            if (DetallePedido == null)
            {
                return NotFound();
            }
            _db.DetallePedidos.Remove(DetallePedido);
            int r = _db.SaveChanges();


            if (r != 1)
            {
                return StatusCode(500);
            }
            return NoContent();
        }

    }
}
