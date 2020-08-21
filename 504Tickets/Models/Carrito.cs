using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;

namespace _504Tickets.Models
{
    public class Carrito
    {
       // [Key] para Ids que no se llamen Ids
        public int Id { get; set; } // PK
        public int IdCategoria { get; set; } //FK
        public int IdUsuario { get; set; } //FK

        public Categoria Categorias { get; set; }
        public Usuario Usuarios { get; set; }
    }
}
