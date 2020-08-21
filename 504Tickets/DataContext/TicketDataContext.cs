using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _504Tickets.Models;
using Microsoft.EntityFrameworkCore;

namespace _504Tickets.DataContext
{
    public class TicketDataContext : DbContext
    {
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Red> Redes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Verificador> Verificadores { get; set; }
        public DbSet<VerificadorEvento> VerificadoresEventos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;DataBase=Tickets504;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarjetaMap());
            modelBuilder.ApplyConfiguration(new RedMap());
            modelBuilder.ApplyConfiguration(new CarritoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TicketMap());
            modelBuilder.ApplyConfiguration(new EventoMap());
            modelBuilder.ApplyConfiguration(new VerificadorMap());
            modelBuilder.ApplyConfiguration(new VerificadorEventoMap());
            modelBuilder.ApplyConfiguration(new ProveedorMap());

            base.OnModelCreating(modelBuilder);
        }
    }


}
