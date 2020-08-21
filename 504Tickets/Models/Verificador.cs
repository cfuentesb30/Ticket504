using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _504Tickets.Models
{
    public class Verificador
    {
        public int Id { get; set; } //PK
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public List<VerificadorEvento> VerificadoresEventos { get; set; }

    }
}
