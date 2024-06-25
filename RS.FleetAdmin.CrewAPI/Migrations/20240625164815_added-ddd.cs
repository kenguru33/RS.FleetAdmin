using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RS.FleetAdmin.CrewAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Stations",
                newName: "CrewName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Stations",
                newName: "CrewId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CrewName",
                table: "Stations",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CrewId",
                table: "Stations",
                newName: "Id");
        }
    }
}
