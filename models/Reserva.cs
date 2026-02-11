namespace SistemaCondominio.Api.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        public int AreaComumId { get; set; }
        public int UsuarioId { get; set; }

        public DateTime DataReserva { get; set; }   // TEM QUE SER ESSE NOME
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public string Status { get; set; }
    }
}
