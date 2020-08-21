using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _504Tickets.Models
{
    public class Proveedor
    {
        public int Id { get; set; } //PK
        public string Nombre { get; set; }
        public string NombreEmpresa { get; set; }
        public int RTN { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public int Telefono { get; set; }
        public string Logo { get; set; }
        public List<Evento> Eventos { get; set; }
        }
    }
