using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaCondominio.Api.Data;
using SistemaCondominio.Api.Models;

namespace SistemaCondominio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CondominioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CondominioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Condominio model)
        {
            _context.Condominios.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var lista = await _context.Condominios.ToListAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var item = await _context.Condominios.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, Condominio model)
        {
            var item = await _context.Condominios.FindAsync(id);
            if (item == null) return NotFound();

            item.Nome = model.Nome;
            item.Endereco = model.Endereco;
            item.Cidade = model.Cidade;
            item.Estado = model.Estado;

            await _context.SaveChangesAsync();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var item = await _context.Condominios.FindAsync(id);
            if (item == null) return NotFound();

            _context.Condominios.Remove(item);
            await _context.SaveChangesAsync();
            return Ok("Removido com sucesso");
        }
    }
}
