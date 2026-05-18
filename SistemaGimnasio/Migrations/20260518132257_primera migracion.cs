using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaGimnasio.Migrations
{
    /// <inheritdoc />
    public partial class primeramigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientesRMB",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false),
                    Ci = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: false),
                    Correo = table.Column<string>(type: "text", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesRMB", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "EntrenadoresRMB",
                columns: table => new
                {
                    IdEntrenador = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false),
                    Especialidad = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: false),
                    Correo = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntrenadoresRMB", x => x.IdEntrenador);
                });

            migrationBuilder.CreateTable(
                name: "MembresiasRMB",
                columns: table => new
                {
                    IdMembresia = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCliente = table.Column<int>(type: "integer", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Precio = table.Column<decimal>(type: "numeric", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembresiasRMB", x => x.IdMembresia);
                    table.ForeignKey(
                        name: "FK_MembresiasRMB_ClientesRMB_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "ClientesRMB",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClasesRMB",
                columns: table => new
                {
                    IdClase = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdEntrenador = table.Column<int>(type: "integer", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Capacidad = table.Column<int>(type: "integer", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasesRMB", x => x.IdClase);
                    table.ForeignKey(
                        name: "FK_ClasesRMB_EntrenadoresRMB_IdEntrenador",
                        column: x => x.IdEntrenador,
                        principalTable: "EntrenadoresRMB",
                        principalColumn: "IdEntrenador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanesEntrenamientoRMB",
                columns: table => new
                {
                    IdPlan = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCliente = table.Column<int>(type: "integer", nullable: false),
                    IdEntrenador = table.Column<int>(type: "integer", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanesEntrenamientoRMB", x => x.IdPlan);
                    table.ForeignKey(
                        name: "FK_PlanesEntrenamientoRMB_ClientesRMB_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "ClientesRMB",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanesEntrenamientoRMB_EntrenadoresRMB_IdEntrenador",
                        column: x => x.IdEntrenador,
                        principalTable: "EntrenadoresRMB",
                        principalColumn: "IdEntrenador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PagosRMB",
                columns: table => new
                {
                    IdPago = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdMembresia = table.Column<int>(type: "integer", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Monto = table.Column<decimal>(type: "numeric", nullable: false),
                    MetodoPago = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagosRMB", x => x.IdPago);
                    table.ForeignKey(
                        name: "FK_PagosRMB_MembresiasRMB_IdMembresia",
                        column: x => x.IdMembresia,
                        principalTable: "MembresiasRMB",
                        principalColumn: "IdMembresia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservaClasesRMB",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCliente = table.Column<int>(type: "integer", nullable: false),
                    IdClase = table.Column<int>(type: "integer", nullable: false),
                    FechaReserva = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaClasesRMB", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_ReservaClasesRMB_ClasesRMB_IdClase",
                        column: x => x.IdClase,
                        principalTable: "ClasesRMB",
                        principalColumn: "IdClase",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaClasesRMB_ClientesRMB_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "ClientesRMB",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClasesRMB_IdEntrenador",
                table: "ClasesRMB",
                column: "IdEntrenador");

            migrationBuilder.CreateIndex(
                name: "IX_MembresiasRMB_IdCliente",
                table: "MembresiasRMB",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_PagosRMB_IdMembresia",
                table: "PagosRMB",
                column: "IdMembresia");

            migrationBuilder.CreateIndex(
                name: "IX_PlanesEntrenamientoRMB_IdCliente",
                table: "PlanesEntrenamientoRMB",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_PlanesEntrenamientoRMB_IdEntrenador",
                table: "PlanesEntrenamientoRMB",
                column: "IdEntrenador");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaClasesRMB_IdClase",
                table: "ReservaClasesRMB",
                column: "IdClase");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaClasesRMB_IdCliente",
                table: "ReservaClasesRMB",
                column: "IdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PagosRMB");

            migrationBuilder.DropTable(
                name: "PlanesEntrenamientoRMB");

            migrationBuilder.DropTable(
                name: "ReservaClasesRMB");

            migrationBuilder.DropTable(
                name: "MembresiasRMB");

            migrationBuilder.DropTable(
                name: "ClasesRMB");

            migrationBuilder.DropTable(
                name: "ClientesRMB");

            migrationBuilder.DropTable(
                name: "EntrenadoresRMB");
        }
    }
}
