using Microsoft.AspNetCore.Mvc;
using SistemaCondominio.Api.Models;

namespace SistemaCondominio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApartamentoController : ControllerBase
    {
        private static List<Apartamento> apartamentos = new();
        private static int idAtual = 1;

        // GET: api/apartamento
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(apartamentos);
        }

        // GET: api/apartamento/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ap = apartamentos.FirstOrDefault(a => a.Id == id);
            if (ap == null)
                return NotFound("Apartamento não encontrado");

            return Ok(ap);
        }

        // POST: api/apartamento
        [HttpPost]
        public IActionResult Post([FromBody] Apartamento apartamento)
        {
            apartamento.Id = idAtual++;
            apartamentos.Add(apartamento);
            return Ok(apartamento);
        }

        // DELETE: api/apartamento/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ap = apartamentos.FirstOrDefault(a => a.Id == id);
            if (ap == null)
                return NotFound("Apartamento não encontrado");

            apartamentos.Remove(ap);
            return Ok("Apartamento removido com sucesso");
        }
    }
}
