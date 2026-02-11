namespace SistemaCondominio.Api.Models
{
    public class Morador
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        // Login
        public string Senha { get; set; }

        // Relacionamento
        public int ApartamentoId { get; set; }

        public Apartamento Apartamento { get; set; } = null!;
    }
}
