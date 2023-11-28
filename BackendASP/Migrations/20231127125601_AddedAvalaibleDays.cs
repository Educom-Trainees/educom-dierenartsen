using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class AddedAvalaibleDays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AvailableDays",
                columns: new[] { "Id", "Days", "EndDate", "StartDate", "TimeSlotId" },
                values: new object[] { 1, 31, null, new DateOnly(2023, 11, 1), 6 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
