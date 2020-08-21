using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _504Tickets.Models
{
    public class VerificadorEvento
    {
        public int Id { get; set; } //PK
        public int IdVerificador { get; set; } //FK
        public int IdEvento { get; set; } //FK
        public Verificador Verificadores { get; set; }
        public Evento Eventos { get; set; }
    }
}
