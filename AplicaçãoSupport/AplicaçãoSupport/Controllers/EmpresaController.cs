using AplicaçãoSupport.Context;
using AplicaçãoSupport.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AplicaçãoSupport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly AplicaçãoSupportDbContext _context;

        public EmpresaController(AplicaçãoSupportDbContext context)
        {
            _context = context;
        }    

        [HttpGet]
        public ActionResult<IEnumerable<EmpresaModel>> Get()
        {
            var empresa = _context.Empresa.ToList();
            if (empresa is null) { 
                return NotFound();
            }
            return empresa;
        }

        [HttpGet("{id:int}", Name = "ObterEmpresa")]
        public ActionResult<EmpresaModel> GetById(int id)
        {
            var empresa = _context.Empresa.FirstOrDefault(p => p.Empresa_Id == id);
            if (empresa is null)
            {
                return NotFound("Não foi encontrado nenhuma empresa com este ID");
            }
            return empresa;
        }

        [HttpPost]
        public ActionResult Post(EmpresaModel empresa)
        {
            if (empresa is null)
            {
                return BadRequest();
            }

            _context.Empresa.Add(empresa);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterEmpresa",
                new { id = empresa.Empresa_Id }, empresa);
        }

        // PUT api/<EmpresaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmpresaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
