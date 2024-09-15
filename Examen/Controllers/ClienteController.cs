using Microsoft.AspNetCore.Mvc;
using ExamenData.DataBase;
using ExamenData.DataBase.Tables;
using System.Reflection;

namespace Examen.Controllers
{
    [ApiController]
    [Route("api/Clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly MiDbContext _db;
        public ClienteController(MiDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("")]
        public IActionResult ListarClientes()
        {
            var Clientes = _db.Clientes.ToList();

            return Ok(Clientes);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult ObtenerCliente([FromRoute] int id)
        {
            var Cliente = _db.Clientes.Find(id);
            if (Cliente == null)
            {
                return NotFound();
            }

            return Ok(Cliente);
        }
        [HttpPost]
        [Route("")]
        public IActionResult CrearCliente([FromBody] Cliente body)
        {
            _db.Clientes.Add(body);
            int r = _db.SaveChanges();
            if (r != 1)
            {
                return StatusCode(500);
            }
            return Ok(body);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult ActualizarAdmi([FromRoute] int id, [FromBody] Cliente body)
        {
           
            var Cliente = _db.Clientes.Find(id);
            if (Cliente == null)
            {
                return NotFound(); 
            }
          
            Cliente.Nombre = body.Nombre;
            Cliente.ApellidoPaterno = body.ApellidoPaterno;
            Cliente.ApellidoMaterno = body.ApellidoMaterno;
            Cliente.EMail = body.EMail;
            

            int r = _db.SaveChanges();
            if (r != 1)
            {
                return StatusCode(500); 
            }
            return NoContent(); 
        }

      

        [HttpDelete]
        [Route("{id}")]
        public IActionResult EliminarCliente([FromRoute] int id)
        {
            var Cliente = _db.Clientes.Find(id);
            if (Cliente == null)
            {
                return NotFound();
            }
            _db.Clientes.Remove(Cliente);
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
            var Clientes = _db.Clientes.Where(
                Cliente => Cliente.Nombre.Contains(nombre)
                ).ToList();
            return Ok(Clientes);
        }
    }
}
