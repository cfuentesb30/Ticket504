using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _504Tickets.Models
{
    public class Ticket
    {
        public int Id { get; set; } //Pk
        public bool Status { get; set; }
        public DateTime HoraFechaGenerado { get; set; }
        public DateTime HoraFechaEscaneado { get; set; }
        public int IdCategoria { get; set; } //FK
        public int UsuarioId { get; set; } //FK
        public Usuario Usuarios { get; set; }
        public Categoria Categorias { get; set; }
    }
}
