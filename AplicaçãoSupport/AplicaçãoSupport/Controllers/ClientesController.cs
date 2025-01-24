using AplicaçãoSupport.Context;
using AplicaçãoSupport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AplicaçãoSupport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AplicaçãoSupportDbContext _context;

        public ClientesController(AplicaçãoSupportDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClienteModel>> Get()
        {
            var cliente = _context.Cliente.ToList();
            if (cliente is null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpGet("{id:int}", Name = "ObterCliente")]
        public ActionResult Get(int id)
        {
            var cliente = _context.Cliente.FirstOrDefault(c => c.ClienteId == id);
            if (id != cliente.ClienteId)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public ActionResult Post(ClienteModel cliente)
        {
            if (cliente == null)
            {
                return BadRequest("Um erro ocorreu ao incluir o cliente");
            }

            _context.Cliente.Add(cliente);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterCliente",
                new {id = cliente.ClienteId}, cliente);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, ClienteModel cliente)
        {
            if (id != cliente.ClienteId)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var cliente = _context.Cliente.FirstOrDefault(c => c.ClienteId == id);
            if (cliente == null)
            {
                return NotFound("Nenhum cliente encontrado");
            }
            if (id != cliente.ClienteId) {
                return BadRequest("Ocorreu um eero ao excluir o cliente");
                    }

            _context.Cliente.Remove(cliente);
            _context.SaveChanges();

            return Ok();
        }
    }
}
