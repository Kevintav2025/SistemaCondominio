namespace SistemaCondominio.Api.DTOs
{
    public class RegisterDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; } // Morador, Sindico, Admin
    }
}
