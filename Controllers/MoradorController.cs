using Microsoft.AspNetCore.Mvc;
using SistemaCondominio.Api.Models;

namespace SistemaCondominio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoradorController : ControllerBase
    {
        private static List<Morador> moradores = new();
        private static int idAtual = 1;

        // GET: api/morador
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(moradores);
        }

        // GET: api/morador/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var morador = moradores.FirstOrDefault(m => m.Id == id);
            if (morador == null)
                return NotFound("Morador não encontrado");

            return Ok(morador);
        }

        // POST: api/morador
        [HttpPost]
        public IActionResult Post([FromBody] Morador morador)
        {
            morador.Id = idAtual++;
            moradores.Add(morador);
            return Ok(morador);
        }

        // DELETE: api/morador/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var morador = moradores.FirstOrDefault(m => m.Id == id);
            if (morador == null)
                return NotFound("Morador não encontrado");

            moradores.Remove(morador);
            return Ok("Morador removido com sucesso");
        }
    }
}