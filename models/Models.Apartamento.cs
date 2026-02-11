namespace SistemaCondominio.Api.Models
{
    public class Apartamento
    {
        public int Id { get; set; }

        public string Numero { get; set; } = null!;
        public int Andar { get; set; }
        public int Bloco { get; set; }

        // FK
        public int CondominioId { get; set; }

        // Navegação
        public Condominio Condominio { get; set; } = null!;

        public List<Morador> Moradores { get; set; } = new();
    }
}
