namespace SistemaCondominio.Api.DTOs
{
    public class MoradorCreateDTO
    {
        public string Nome { get; set; } = null!;
        public string CPF { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public int ApartamentoId { get; set; }
    }
}
