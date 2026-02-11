using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaCondominio.Api.DTOs
{
    public class ReservaCreateDTO
    {
        [Required(ErrorMessage = "Área comum é obrigatória")]
        public int AreaComumId { get; set; }

        [Required(ErrorMessage = "Usuário é obrigatório")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Data da reserva é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataReserva { get; set; }

        [Required(ErrorMessage = "Hora inicial é obrigatória")]
        public TimeSpan HoraInicio { get; set; }

        [Required(ErrorMessage = "Hora final é obrigatória")]
        public TimeSpan HoraFim { get; set; }
    }
}