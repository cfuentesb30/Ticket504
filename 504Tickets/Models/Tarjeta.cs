using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _504Tickets.Models
{
    public class Tarjeta
    {
        public int Id { get; set; } //PK IdTarjetas
        public int NumTarjeta { get; set; }
        public string CardHolder { get; set; }
        public int YearExp { get; set; }
        public int MonthExp { get; set; }
        public int CodigoCVV { get; set; }
        public int IdUsuario { get; set; } //FK para los usuarios
        public Usuario Usuarios { get; set; }
    }
}
