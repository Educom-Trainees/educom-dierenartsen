using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class AddedTreatmentTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TreatmentTimeId",
                table: "AppointmentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TreatmentTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentTimes", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AppointmentTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "TreatmentTimeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AppointmentTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "TreatmentTimeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "AppointmentTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "TreatmentTimeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AppointmentTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "TreatmentTimeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "AppointmentTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "TreatmentTimeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AppointmentTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "TreatmentTimeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AppointmentTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "TreatmentTimeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AppointmentTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "TreatmentTimeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AppointmentTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "TreatmentTimeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AppointmentTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "TreatmentTimeId",
                value: 1);

            migrationBuilder.InsertData(
                table: "TreatmentTimes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "kort" },
                    { 2, "kort - gemiddeld" },
                    { 3, "gemiddeld" },
                    { 4, "gemiddeld - lang" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentTypes_TreatmentTimeId",
                table: "AppointmentTypes",
                column: "TreatmentTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentTypes_TreatmentTimes_TreatmentTimeId",
                table: "AppointmentTypes",
                column: "TreatmentTimeId",
                principalTable: "TreatmentTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentTypes_TreatmentTimes_TreatmentTimeId",
                table: "AppointmentTypes");

            migrationBuilder.DropTable(
                name: "TreatmentTimes");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentTypes_TreatmentTimeId",
                table: "AppointmentTypes");

            migrationBuilder.DropColumn(
                name: "TreatmentTimeId",
                table: "AppointmentTypes");
        }
    }
}
