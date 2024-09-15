using Microsoft.AspNetCore.Mvc;
using ExamenData.DataBase;
using ExamenData.DataBase.Tables;
using System.Reflection;

namespace Examen.Controllers
{
    [ApiController]
    [Route("api/Productos")]
    public class ProductoController : ControllerBase
    {
        private readonly MiDbContext _db;
        public ProductoController(MiDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("")]
        public IActionResult ListarProductos()
        {
            var Productos = _db.Productos.ToList();

            return Ok(Productos);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult ObtenerProducto([FromRoute] int id)
        {
            var Producto = _db.Productos.Find(id);
            if (Producto == null)
            {
                return NotFound();
            }

            return Ok(Producto);
        }
        [HttpPost]
        [Route("")]
        public IActionResult CrearProducto([FromBody] Producto body)
        {
            _db.Productos.Add(body);
            int r = _db.SaveChanges();
            if (r != 1)
            {
                return StatusCode(500);
            }
            return Ok(body);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult ActualizarAdmi([FromRoute] int id, [FromBody] Producto body)
        {

            var Producto = _db.Productos.Find(id);
            if (Producto == null)
            {
                return NotFound();
            }

            Producto.Nombre = body.Nombre;
            Producto.precio = body.precio;
            Producto.stock = body.stock;


            int r = _db.SaveChanges();
            if (r != 1)
            {
                return StatusCode(500);
            }
            return NoContent();
        }



        [HttpDelete]
        [Route("{id}")]
        public IActionResult EliminarProducto([FromRoute] int id)
        {
            var Producto = _db.Productos.Find(id);
            if (Producto == null)
            {
                return NotFound();
            }
            _db.Productos.Remove(Producto);
            int r = _db.SaveChanges();


            if (r != 1)
            {
                return StatusCode(500);
            }
            return NoContent();
        }
        [HttpGet]
        [Route("Buscar")]
        public IActionResult BuscarPedido([FromQuery] string nombre)
        {
            var Productos = _db.Productos.Where(
                Producto => Producto.Nombre.Contains(nombre)
                ).ToList();
            return Ok(Productos);
        }
    }
}
