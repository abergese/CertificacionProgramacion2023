using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dni = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TarjetaCredito",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroTarjeta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    limiteCredito = table.Column<double>(type: "float", nullable: false),
                    saldoDisponible = table.Column<double>(type: "float", nullable: false),
                    montoDeuda = table.Column<double>(type: "float", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarjetaCredito", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CuentaBancaria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroCuenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    saldo = table.Column<double>(type: "float", nullable: false),
                    tipoCuenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clienteid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentaBancaria", x => x.id);
                    table.ForeignKey(
                        name: "FK_CuentaBancaria_Cliente_clienteid",
                        column: x => x.clienteid,
                        principalTable: "Cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuentaBancaria_clienteid",
                table: "CuentaBancaria",
                column: "clienteid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuentaBancaria");

            migrationBuilder.DropTable(
                name: "TarjetaCredito");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
