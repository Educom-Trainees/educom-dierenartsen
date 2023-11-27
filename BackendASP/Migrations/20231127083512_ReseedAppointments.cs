using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class ReseedAppointments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentNumber", "Date", "Duration", "CustomerName", "PhoneNumber", "Email", "Preference", "Doctor", "Status", "PetTypeId", "AppointmentTypeId" },
                values: new object[] { 1, 1, DateTime.Parse("2023-11-20"), 30, "Corbijn Bulsink", "0611330161", "corbijn.bullie@hoi.nl", 1, 1, 1, 4, 5 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
