using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _504Tickets.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Proveedores",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(max)", nullable: false),
                    NombreEmpresa = table.Column<string>(type: "varchar(max)", nullable: false),
                    RTN = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "varchar(max)", nullable: false),
                    Password = table.Column<string>(type: "varchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Logo = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Redes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "varchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "varchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "varchar(max)", nullable: false),
                    Password = table.Column<string>(type: "varchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<string>(type: "varchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Verificadores",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "varchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "varchar(max)", nullable: false),
                    Password = table.Column<string>(type: "varchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verificadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(max)", nullable: false),
                    Ilustracion = table.Column<string>(type: "varchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "date", nullable: false),
                    CiudadEvento = table.Column<string>(type: "varchar(max)", nullable: false),
                    DireccionEvento = table.Column<string>(type: "varchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IdProveedor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_Proveedores_IdProveedor",
                        column: x => x.IdProveedor,
                        principalSchema: "dbo",
                        principalTable: "Proveedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarjetas",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumTarjeta = table.Column<int>(type: "int", nullable: false),
                    CardHolder = table.Column<string>(type: "varchar(120)", maxLength: 60, nullable: false),
                    YearExp = table.Column<int>(type: "int", nullable: false),
                    MonthExp = table.Column<int>(type: "int", nullable: false),
                    CodigoCVV = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarjetas_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "dbo",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCategoria = table.Column<string>(type: "varchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    CantidadBoletos = table.Column<int>(type: "int", nullable: false),
                    IdEvento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorias_Eventos_IdEvento",
                        column: x => x.IdEvento,
                        principalSchema: "dbo",
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VerificadoresEventos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVerificador = table.Column<int>(nullable: false),
                    IdEvento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificadoresEventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerificadoresEventos_Eventos_IdEvento",
                        column: x => x.IdEvento,
                        principalSchema: "dbo",
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VerificadoresEventos_Verificadores_IdVerificador",
                        column: x => x.IdVerificador,
                        principalSchema: "dbo",
                        principalTable: "Verificadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carritos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategoria = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carritos", x => x.Id);
                   
                    table.ForeignKey(
                        name: "FK_Carritos_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalSchema: "dbo",
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carritos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "dbo",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    HoraFechaGenerado = table.Column<DateTime>(type: "date", nullable: false),
                    HoraFechaEscaneado = table.Column<DateTime>(type: "date", nullable: false),
                    IdCategoria = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalSchema: "dbo",
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "dbo",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });



            migrationBuilder.CreateIndex(
                name: "IX_Carritos_IdCategoria",
                schema: "dbo",
                table: "Carritos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_IdUsuario",
                schema: "dbo",
                table: "Carritos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_IdEvento",
                schema: "dbo",
                table: "Categorias",
                column: "IdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_IdProveedor",
                schema: "dbo",
                table: "Eventos",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetas_IdUsuario",
                schema: "dbo",
                table: "Tarjetas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IdCategoria",
                schema: "dbo",
                table: "Tickets",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UsuarioId",
                schema: "dbo",
                table: "Tickets",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_VerificadoresEventos_IdEvento",
                schema: "dbo",
                table: "VerificadoresEventos",
                column: "IdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_VerificadoresEventos_IdVerificador",
                schema: "dbo",
                table: "VerificadoresEventos",
                column: "IdVerificador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carritos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Redes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tarjetas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tickets",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VerificadoresEventos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Categorias",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Verificadores",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Eventos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Proveedores",
                schema: "dbo");
        }
    }
}
