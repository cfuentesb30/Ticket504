using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _504Tickets.Models
{
    public class Evento
    {
        public int Id { get; set; } //PK
        public string Nombre { get; set; }
        public string Ilustracion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CiudadEvento { get; set; }
        public string DireccionEvento { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public bool Status { get; set; }
        public int IdProveedor { get; set; } //FK
        public Proveedor Proveedor { get; set; }
        public List<Categoria> Categorias { get; set; }
        public List<VerificadorEvento> VerificadoresEventos { get; set; }

    }
}
