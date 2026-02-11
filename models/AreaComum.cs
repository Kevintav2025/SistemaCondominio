using SistemaCondominio.Api.Models;

namespace SistemaCondominio.Api
{
    public class AreaComum
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public bool Ativo { get; set; } = true;

        public List<Reserva> Reservas { get; set; } = new();
    }
}

