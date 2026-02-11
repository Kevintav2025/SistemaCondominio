namespace SistemaCondominio.Api.Models
{
    public class Ocorrencia
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
