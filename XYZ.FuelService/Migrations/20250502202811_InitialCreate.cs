using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XYZ.FuelService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuelRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehiculoId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RutaId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LitrosConsumidos = table.Column<float>(type: "real", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelRecords", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuelRecords");
        }
    }
}
