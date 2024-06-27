using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RS.FleetAdmin.VesselAPI.Migrations
{
    /// <inheritdoc />
    public partial class renamedVesselIdtoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VesselId",
                table: "Vessels",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vessels",
                newName: "VesselId");
        }
    }
}
