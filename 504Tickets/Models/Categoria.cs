using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _504Tickets.Models
{
    public class Categoria
    {
        public int Id { get; set; } //PK
        public string NombreCategoria { get; set; }
        public double Precio { get; set; }
        public int CantidadBoletos { get; set; }
        public int IdEvento { get; set; } //FK
        public Evento Evento { get; set; }
        public List<Carrito> Carritos { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
