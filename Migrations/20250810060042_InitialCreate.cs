using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoEngineer_Star_Wars_API_Demonstration.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Starships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostInCredits = table.Column<float>(type: "real", nullable: true),
                    Length = table.Column<float>(type: "real", nullable: true),
                    MaxAtmospheringSpeed = table.Column<float>(type: "real", nullable: true),
                    MinimumCrew = table.Column<int>(type: "int", nullable: true),
                    MaximumCrew = table.Column<int>(type: "int", nullable: true),
                    PassengerCapacity = table.Column<int>(type: "int", nullable: true),
                    CargoCapacity = table.Column<int>(type: "int", nullable: true),
                    ConsumablesInYears = table.Column<int>(type: "int", nullable: true),
                    HyperdriveRating = table.Column<float>(type: "real", nullable: true),
                    MegaLightPerHour = table.Column<int>(type: "int", nullable: true),
                    StarshipClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pilots = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Films = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    APIUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starships", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Starships");
        }
    }
}
