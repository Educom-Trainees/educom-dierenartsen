using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class AddedTimeSlot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<string>(type: "varchar(256)", nullable: false),
                    Doctor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AvailableDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeSlotId = table.Column<int>(type: "int", nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableDays_TimeSlots_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "Doctor", "Time" },
                values: new object[,]
                {
                    { 1, 1, "09:00" },
                    { 2, 2, "09:00" },
                    { 3, 1, "09:15" },
                    { 4, 2, "09:15" },
                    { 5, 1, "09:30" },
                    { 6, 2, "09:30" },
                    { 7, 1, "09:45" },
                    { 8, 2, "09:45" },
                    { 9, 1, "10:00" },
                    { 10, 2, "10:00" },
                    { 11, 1, "10:15" },
                    { 12, 2, "10:15" },
                    { 13, 1, "10:30" },
                    { 14, 2, "10:30" },
                    { 15, 1, "10:45" },
                    { 16, 2, "10:45" },
                    { 17, 1, "11:00" },
                    { 18, 2, "11:00" },
                    { 19, 1, "11:15" },
                    { 20, 2, "11:15" },
                    { 21, 1, "11:30" },
                    { 22, 2, "11:30" },
                    { 23, 1, "11:45" },
                    { 24, 2, "11:45" },
                    { 25, 1, "12:00" },
                    { 26, 2, "12:00" },
                    { 27, 1, "14:15" },
                    { 28, 2, "14:15" },
                    { 29, 1, "14:30" },
                    { 30, 2, "14:30" },
                    { 31, 1, "14:45" },
                    { 32, 2, "14:45" },
                    { 33, 1, "15:00" },
                    { 34, 2, "15:00" },
                    { 35, 1, "15:15" },
                    { 36, 2, "15:15" },
                    { 37, 1, "15:30" },
                    { 38, 2, "15:30" },
                    { 39, 1, "15:45" },
                    { 40, 2, "15:45" },
                    { 41, 1, "16:00" },
                    { 42, 2, "16:00" },
                    { 43, 1, "16:15" },
                    { 44, 2, "16:15" },
                    { 45, 1, "16:30" },
                    { 46, 2, "16:30" },
                    { 47, 1, "16:45" },
                    { 48, 2, "16:45" },
                    { 49, 1, "17:00" },
                    { 50, 1, "17:15" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableDays_TimeSlotId",
                table: "AvailableDays",
                column: "TimeSlotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableDays");

            migrationBuilder.DropTable(
                name: "TimeSlots");
        }
    }
}
