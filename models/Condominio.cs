namespace SistemaCondominio.Api.Models
{
    public class Condominio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }



        // Relacionamento
        public List<Apartamento> Apartamentos { get; set; } = new();
    }
}
