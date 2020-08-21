using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _504Tickets.Models
{
    public class Usuario
    {
        public int Id { get; set; } //PK
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Telefono { get; set; }
        public string Foto { get; set; }
        public bool Status { get; set; }

        public List<Tarjeta> Tarjetas { get; set; }
        public List<Carrito> Carritos { get; set; }
        public List<Ticket> Tickets { get; set; }

    }
}
