using AplicaçãoSupport.Context;
using AplicaçãoSupport.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AplicaçãoSupport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentosController : ControllerBase
    {
        private readonly AplicaçãoSupportDbContext _context;    

        public AtendimentosController(AplicaçãoSupportDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AtendimentosModel>> Get()
        {
            var atendimentos = _context.Atendimentos.ToList();
            if (atendimentos is null)
            {
                return NotFound();
            }
            return _context.Atendimentos;
        }


        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            
        }

        // POST api/<AtendimentosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AtendimentosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AtendimentosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
