using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaCondominio.Api.Data;
using SistemaCondominio.Api.Models;

namespace SistemaCondominio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreasComunsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AreasComunsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AreaComum>>> GetAll()
        {
            return await _context.AreasComuns.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<AreaComum>> Create(AreaComum area)
        {
            _context.AreasComuns.Add(area);
            await _context.SaveChangesAsync();
            return Ok(area);
        }
    }
}
