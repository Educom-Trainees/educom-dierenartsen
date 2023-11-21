using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class AppointmentsAppointmentPets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentNumber", "CustomerName", "Date", "Email", "PetTypeId", "PhoneNumber", "Preference", "Status" },
                values: new object[] { 1, 1, "Corbijn Bulsink", new DateTime(2023, 11, 20, 14, 30, 0, 0, DateTimeKind.Unspecified), "corbijn.bullie@hoi.nl", 1, "0611330161", 1, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
