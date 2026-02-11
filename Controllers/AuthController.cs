using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaCondominio.Api.Data;
using SistemaCondominio.Api.DTOs;
using SistemaCondominio.Api.Models;
using SistemaCondominio.Api.Services;

namespace SistemaCondominio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            if (await _context.Usuarios.AnyAsync(x => x.Email == dto.Email))
                return BadRequest("Email já cadastrado");

            var user = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                SenhaHash = PasswordService.Hash(dto.Senha),
                Tipo = dto.Tipo
            };

            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();

            return Ok("Usuário criado com sucesso");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == dto.Email);
            if (user == null)
                return Unauthorized("Usuário não encontrado");

            if (!PasswordService.Verify(dto.Senha, user.SenhaHash))
                return Unauthorized("Senha inválida");

            return Ok(new
            {
                user.Id,
                user.Nome,
                user.Email,
                user.Tipo
            });
        }
    }
}
