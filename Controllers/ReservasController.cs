using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaCondominio.Api.Data;
using SistemaCondominio.Api.DTOs;
using SistemaCondominio.Api.Models;

namespace SistemaCondominio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReservasController(AppDbContext context)
        {
            _context = context;
        }

        // 🔍 Teste rápido de conexão
        [HttpGet("teste")]
        public async Task<IActionResult> Teste()
        {
            try
            {
                var count = await _context.Reservas.CountAsync();
                return Ok(new { totalReservas = count });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no banco: {ex.Message}");
            }
        } // <--- AQUI estava o erro: precisava fechar o método antes de começar outro.

        // 📥 Criar reserva
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReservaCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validações básicas de negócio
            if (dto.HoraFim <= dto.HoraInicio)
                return BadRequest("Hora final deve ser maior que hora inicial.");

            if (dto.DataReserva.Date < DateTime.Today)
                return BadRequest("Não é possível reservar data passada.");

            // Lógica de conflito (Melhorada)
            // Duas reservas colidem se: (InicioA < FimB) E (FimA > InicioB)
            var conflito = await _context.Reservas.AnyAsync(r =>
                r.AreaComumId == dto.AreaComumId &&
                r.DataReserva.Date == dto.DataReserva.Date &&
                r.Status != "Cancelada" && // Ignora reservas canceladas
                dto.HoraInicio < r.HoraFim &&
                dto.HoraFim > r.HoraInicio
            );

            if (conflito)
                return Conflict("Já existe uma reserva ativa para este horário.");

            var reserva = new Reserva
            {
                AreaComumId = dto.AreaComumId,
                UsuarioId = dto.UsuarioId,
                DataReserva = dto.DataReserva,
                HoraInicio = dto.HoraInicio,
                HoraFim = dto.HoraFim,
                Status = "Ativa"
            };

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return Ok(reserva);
        }
    }
}