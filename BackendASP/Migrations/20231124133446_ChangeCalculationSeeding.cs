using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCalculationSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Count", "Duration" },
                values: new object[] { 4, 30 });

            migrationBuilder.UpdateData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Count", "Duration" },
                values: new object[] { null, 15 });

            migrationBuilder.UpdateData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Count", "Duration" },
                values: new object[] { 4, 30 });

            migrationBuilder.UpdateData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Count", "Duration" },
                values: new object[] { null, 15 });

            migrationBuilder.InsertData(
                table: "Calculations",
                columns: new[] { "Id", "Count", "Duration", "PetTypeId", "TreatmentTimeId" },
                values: new object[,]
                {
                    { 7, 4, 45, null, 4 },
                    { 8, 3, 45, 9, 4 },
                    { 9, null, 30, null, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Count", "Duration" },
                values: new object[] { null, 15 });

            migrationBuilder.UpdateData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Count", "Duration" },
                values: new object[] { 4, 30 });

            migrationBuilder.UpdateData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Count", "Duration" },
                values: new object[] { null, 15 });

            migrationBuilder.UpdateData(
                table: "Calculations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Count", "Duration" },
                values: new object[] { 4, 30 });
        }
    }
}
