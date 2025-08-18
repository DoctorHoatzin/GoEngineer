using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoEngineer_Star_Wars_API_Demonstration.Migrations
{
    /// <inheritdoc />
    public partial class publicId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PublicId",
                table: "Starships",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Starships");
        }
    }
}
