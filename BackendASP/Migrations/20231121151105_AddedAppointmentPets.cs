using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class AddedAppointmentPets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppointmentPets",
                columns: new[] { "Id", "AppointmentId", "ExtraInfo", "Name" },
                values: new object[] { 1, 1, null, "Fifi" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppointmentPets",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
