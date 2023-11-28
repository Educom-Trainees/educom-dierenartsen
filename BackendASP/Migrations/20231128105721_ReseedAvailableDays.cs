using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class ReseedAvailableDays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Days", "TimeSlotId" },
                values: new object[] { 124, 1 });

            migrationBuilder.InsertData(
                table: "AvailableDays",
                columns: new[] { "Id", "Days", "EndDate", "StartDate", "TimeSlotId" },
                values: new object[,]
                {
                    { 2, 124, null, new DateOnly(2023, 11, 1), 2 },
                    { 3, 124, null, new DateOnly(2023, 11, 1), 3 },
                    { 4, 124, null, new DateOnly(2023, 11, 1), 4 },
                    { 5, 124, null, new DateOnly(2023, 11, 1), 5 },
                    { 6, 124, null, new DateOnly(2023, 11, 1), 6 },
                    { 7, 124, null, new DateOnly(2023, 11, 1), 7 },
                    { 8, 124, null, new DateOnly(2023, 11, 1), 8 },
                    { 9, 124, null, new DateOnly(2023, 11, 1), 9 },
                    { 10, 124, null, new DateOnly(2023, 11, 1), 10 },
                    { 11, 124, null, new DateOnly(2023, 11, 1), 11 },
                    { 12, 124, null, new DateOnly(2023, 11, 1), 12 },
                    { 13, 124, null, new DateOnly(2023, 11, 1), 13 },
                    { 14, 124, null, new DateOnly(2023, 11, 1), 14 },
                    { 15, 124, null, new DateOnly(2023, 11, 1), 15 },
                    { 16, 124, null, new DateOnly(2023, 11, 1), 16 },
                    { 17, 124, null, new DateOnly(2023, 11, 1), 17 },
                    { 18, 124, null, new DateOnly(2023, 11, 1), 18 },
                    { 19, 124, null, new DateOnly(2023, 11, 1), 19 },
                    { 20, 124, null, new DateOnly(2023, 11, 1), 20 },
                    { 21, 124, null, new DateOnly(2023, 11, 1), 21 },
                    { 22, 124, null, new DateOnly(2023, 11, 1), 22 },
                    { 23, 124, null, new DateOnly(2023, 11, 1), 23 },
                    { 24, 124, null, new DateOnly(2023, 11, 1), 24 },
                    { 25, 124, null, new DateOnly(2023, 11, 1), 25 },
                    { 26, 124, null, new DateOnly(2023, 11, 1), 26 },
                    { 27, 124, null, new DateOnly(2023, 11, 1), 27 },
                    { 28, 124, null, new DateOnly(2023, 11, 1), 28 },
                    { 29, 124, null, new DateOnly(2023, 11, 1), 29 },
                    { 30, 124, null, new DateOnly(2023, 11, 1), 30 },
                    { 31, 124, null, new DateOnly(2023, 11, 1), 31 },
                    { 32, 124, null, new DateOnly(2023, 11, 1), 32 },
                    { 33, 124, null, new DateOnly(2023, 11, 1), 33 },
                    { 34, 124, null, new DateOnly(2023, 11, 1), 34 },
                    { 35, 124, null, new DateOnly(2023, 11, 1), 35 },
                    { 36, 124, null, new DateOnly(2023, 11, 1), 36 },
                    { 37, 124, null, new DateOnly(2023, 11, 1), 37 },
                    { 38, 124, null, new DateOnly(2023, 11, 1), 38 },
                    { 39, 124, null, new DateOnly(2023, 11, 1), 39 },
                    { 40, 124, null, new DateOnly(2023, 11, 1), 40 },
                    { 41, 124, null, new DateOnly(2023, 11, 1), 41 },
                    { 42, 124, null, new DateOnly(2023, 11, 1), 42 },
                    { 43, 124, null, new DateOnly(2023, 11, 1), 43 },
                    { 44, 124, null, new DateOnly(2023, 11, 1), 44 },
                    { 45, 124, null, new DateOnly(2023, 11, 1), 45 },
                    { 46, 124, null, new DateOnly(2023, 11, 1), 46 },
                    { 47, 124, null, new DateOnly(2023, 11, 1), 47 },
                    { 48, 124, null, new DateOnly(2023, 11, 1), 48 },
                    { 49, 124, null, new DateOnly(2023, 11, 1), 49 },
                    { 50, 0, null, new DateOnly(2023, 11, 1), 50 }
                });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Doctor", "Time" },
                values: new object[] { 2, "17:00" });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "Doctor", "Time" },
                values: new object[,]
                {
                    { 51, 1, "17:15" },
                    { 52, 2, "17:15" }
                });

            migrationBuilder.InsertData(
                table: "AvailableDays",
                columns: new[] { "Id", "Days", "EndDate", "StartDate", "TimeSlotId" },
                values: new object[,]
                {
                    { 51, 124, null, new DateOnly(2023, 11, 1), 51 },
                    { 52, 0, null, new DateOnly(2023, 11, 1), 52 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.UpdateData(
                table: "AvailableDays",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Days", "TimeSlotId" },
                values: new object[] { 31, 6 });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Doctor", "Time" },
                values: new object[] { 1, "17:15" });
        }
    }
}
