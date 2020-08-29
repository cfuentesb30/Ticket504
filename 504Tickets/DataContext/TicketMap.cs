using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using _504Tickets.Models;

namespace _504Tickets.DataContext
{
    public class TarjetaMap : IEntityTypeConfiguration<Tarjeta>
    {
        public void Configure(EntityTypeBuilder<Tarjeta>builder)
        {
            builder.ToTable("Tarjetas", "dbo");
            builder.HasKey(q => q.Id);
            builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
            builder.Property(e => e.CardHolder).HasColumnType("varchar(120)")
                .HasMaxLength(60).IsRequired();
            builder.Property(e => e.NumTarjeta).HasColumnType("int")
                .IsRequired();
            builder.Property(e => e.CodigoCVV).HasColumnType("int")
                .IsRequired();
            builder.Property(e => e.YearExp).HasColumnType("int").IsRequired();
            builder.Property(e => e.MonthExp).HasColumnType("int").IsRequired();
            
            builder.HasOne(e => e.Usuarios)
                  .WithMany(e => e.Tarjetas)
                  .HasForeignKey(e => e.IdUsuario);
        }
    }
   public class RedMap : IEntityTypeConfiguration<Red>
    {
        public void Configure(EntityTypeBuilder<Red> builder)
        {
            builder.ToTable("Redes", "dbo");
            builder.HasKey(q => q.Id);
            builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
            builder.Property(e => e.Link).HasColumnType("varchar(max)")
                .IsRequired();
            builder.Property(e => e.Nombre).HasColumnType("varchar(max)")
              .IsRequired();

        }
    }
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorias", "dbo");
            builder.HasKey(q => q.Id);
            builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
            builder.Property(e => e.NombreCategoria).HasColumnType("varchar(max)")
                .IsRequired();
            builder.Property(e => e.Precio).HasColumnType("float")
              .IsRequired();
            builder.Property(e => e.CantidadBoletos).HasColumnType("int").IsRequired();            
        }
    }
    public class CarritoMap : IEntityTypeConfiguration<Carrito>
    {
        public void Configure(EntityTypeBuilder<Carrito> builder)
        {
            builder.ToTable("Carritos", "dbo");
            builder.HasKey(q => q.Id);
            builder.Property(e => e.Id).IsRequired().UseIdentityColumn();

            builder.HasOne(e => e.Categorias)
                  .WithMany(e => e.Carritos)
                  .HasForeignKey(e => e.IdCategoria);

            builder.HasOne(e => e.Usuarios)
                  .WithMany(e => e.Carritos)
                  .HasForeignKey(e => e.IdUsuario);
        }
    }
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios", "dbo");
            builder.HasKey(q => q.Id);
            builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
            builder.Property(e => e.Nombre).IsRequired().HasColumnType("varchar(max)");
            builder.Property(e => e.Apellido).IsRequired().HasColumnType("varchar(max)");
            builder.Property(e => e.Correo).IsRequired().HasColumnType("varchar(max)");
            builder.Property(e => e.Password).IsRequired().HasColumnType("varchar(max)");
            builder.Property(e => e.FechaNacimiento).IsRequired().HasColumnType("date");
            builder.Property(e => e.Telefono).HasColumnType("int");
            builder.Property(e => e.Foto).HasColumnType("varchar(max)");
            builder.Property(e => e.Status).IsRequired().HasColumnType("bit");

            
        }

    }
    public class TicketMap : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Tickets", "dbo");
            builder.HasKey(q => q.Id);
            builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
            builder.Property(e => e.Status).IsRequired().HasColumnType("bit");
            builder.Property(e => e.HoraFechaEscaneado).IsRequired().HasColumnType("date"); 
            builder.Property(e => e.HoraFechaGenerado).IsRequired().HasColumnType("date");

            builder.HasOne(e => e.Usuarios)
                .WithMany(e => e.Tickets)
                .HasForeignKey(e => e.UsuarioId);

            builder.HasOne(e => e.Categorias)
                .WithMany(e => e.Tickets)
                .HasForeignKey(e => e.IdCategoria);

        }

    }
    public class EventoMap : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("Eventos", "dbo");
            builder.HasKey(q => q.Id);
            builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
            builder.Property(e => e.Nombre).IsRequired().HasColumnType("varchar(max)");
            builder.Property(e => e.Ilustracion).IsRequired().HasColumnType("varchar(max)");
            builder.Property(e => e.FechaCreacion).IsRequired().HasColumnType("date");
            builder.Property(e => e.Fecha).IsRequired().HasColumnType("date");
            builder.Property(e => e.CiudadEvento).IsRequired().HasColumnType("varchar(max)");
            builder.Property(e => e.DireccionEvento).IsRequired().HasColumnType("varchar(max)");
            builder.Property(e => e.Descripcion).IsRequired().HasColumnType("varchar(max)");
            builder.Property(e => e.Status).IsRequired().HasColumnType("bit");

            builder.HasOne(e => e.Proveedor)
            .WithMany(e => e.Eventos)
            .HasForeignKey(e => e.IdProveedor);

            builder.HasOne(e => e.Categoria)
            .WithMany(e => e.Eventos)
            .HasForeignKey(e => e.IdCategoria);

        }

    }
    public class VerificadorMap : IEntityTypeConfiguration<Verificador>
    {
        public void Configure(EntityTypeBuilder<Verificador> builder)
        {
            builder.ToTable("Verificadores", "dbo");
            builder.HasKey(q => q.Id);
            builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
            builder.Property(e => e.Nombre).IsRequired().HasColumnType("varchar(max)");
            builder.Property(e => e.Apellido).IsRequired().HasColumnType("varchar(max)");
            builder.Property(e => e.Correo).IsRequired().HasColumnType("varchar(max)");
            builder.Property(e => e.Password).IsRequired().HasColumnType("varchar(max)");
            builder.Property(e => e.Status).IsRequired().HasColumnType("bit");

        }
    }
    public class VerificadorEventoMap : IEntityTypeConfiguration<VerificadorEvento>
    {
        public void Configure(EntityTypeBuilder<VerificadorEvento> builder)
        {
            builder.ToTable("VerificadoresEventos", "dbo");
            builder.HasKey(q => q.Id);
            builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
            
            //Verificadoreventos es la tablet master
            builder.HasOne(e => e.Verificadores)
                .WithMany(e => e.VerificadoresEventos)
                .HasForeignKey(e => e.IdVerificador); //Eventos 
           
            builder.HasOne(e => e.Eventos)
                .WithMany(e => e.VerificadoresEventos)
                .HasForeignKey(e => e.IdEvento); //Verificadores

        }
    }
    public class ProveedorMap : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("Proveedores", "dbo");
            builder.HasKey(q => q.Id);
            builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
            builder.Property(e => e.Nombre).IsRequired().HasColumnType("varchar(max)");
            builder.Property(e => e.NombreEmpresa).IsRequired().HasColumnType("varchar(max)");
            builder.Property(e => e.RTN).HasColumnType("int");
            builder.Property(e => e.Correo).IsRequired().HasColumnType("varchar(max)");
            builder.Property(e => e.Password).IsRequired().HasColumnType("varchar(max)");
            builder.Property(e => e.Telefono).HasColumnType("int");
            builder.Property(e => e.Logo).IsRequired().HasColumnType("varchar(max)");

        }
    }
}


