using AplicaçãoSupport.Context;
using AplicaçãoSupport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AplicaçãoSupport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendenteController : ControllerBase
    {
        private readonly AplicaçãoSupportDbContext _context;

        public AtendenteController(AplicaçãoSupportDbContext context)
        {
            _context = context;
        }
            
        // GET: api/<AtendenteController>
        [HttpGet]
        public ActionResult<IEnumerable<AtendenteModel>> GetAtendente()
        {
            var Atendentes = _context.Atendente.ToList();
            if(Atendentes is null)
            {
                return NotFound("Nenhum atendente cadastrado");
            }
            return _context.Atendente;
        }

        // GET api/<AtendenteController>/5
        [HttpGet("{id:int}", Name ="ObterAtendente")]
        public ActionResult<AtendenteModel> Get(int id)
        {
            var Atendente = _context.Atendente.FirstOrDefault(p=> p.Atendente_Id == id);
            if (Atendente == null)
            {
                return NotFound("Não foi encontrado nenhum atendente com este ID");
            }
            return Atendente;
        }

        // POST api/<AtendenteController>
        [HttpPost]
        public ActionResult Post(AtendenteModel atendente)
        {
            if (atendente is null) {
                return BadRequest();
            }

            _context.Atendente.Add(atendente);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterAtendente",
                new {id = atendente.Atendente_Id}, atendente);
            
        }

        // PUT api/<AtendenteController>/5
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, AtendenteModel atendente)
        {
            if (id != atendente.Atendente_Id)
            {
                return BadRequest();
            }

            _context.Entry(atendente).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(atendente);

        }

        // DELETE api/<AtendenteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var atendente = _context.Atendente.FirstOrDefault(p => p.Atendente_Id == id);

            if(id != atendente.Atendente_Id)
            {
                return BadRequest();
            }
            if (atendente is null)
            {
                return NotFound();
            }

            _context.Atendente.Remove(atendente);
            _context.SaveChanges();

            return Ok("Atendente deletado.");
        }
    }
}
