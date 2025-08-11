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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostInCredits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Length = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxAtmospheringSpeed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinimumCrew = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaximumCrew = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassengerCapacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoCapacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsumablesInYears = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HyperdriveRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MegaLightPerHour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StarshipClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilots = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Films = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    APIUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
