using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePreviousTimeSlots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PreviousTimeSlotId",
                table: "TimeSlots",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 1,
                column: "PreviousTimeSlotId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 2,
                column: "PreviousTimeSlotId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 3,
                column: "PreviousTimeSlotId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 4,
                column: "PreviousTimeSlotId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 5,
                column: "PreviousTimeSlotId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 6,
                column: "PreviousTimeSlotId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 7,
                column: "PreviousTimeSlotId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 8,
                column: "PreviousTimeSlotId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 9,
                column: "PreviousTimeSlotId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 10,
                column: "PreviousTimeSlotId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 11,
                column: "PreviousTimeSlotId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 12,
                column: "PreviousTimeSlotId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 13,
                column: "PreviousTimeSlotId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 14,
                column: "PreviousTimeSlotId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 15,
                column: "PreviousTimeSlotId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 16,
                column: "PreviousTimeSlotId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 17,
                column: "PreviousTimeSlotId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 18,
                column: "PreviousTimeSlotId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 19,
                column: "PreviousTimeSlotId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 20,
                column: "PreviousTimeSlotId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 21,
                column: "PreviousTimeSlotId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 22,
                column: "PreviousTimeSlotId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 23,
                column: "PreviousTimeSlotId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 24,
                column: "PreviousTimeSlotId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 25,
                column: "PreviousTimeSlotId",
                value: 23);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 26,
                column: "PreviousTimeSlotId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 27,
                column: "PreviousTimeSlotId",
                value: 25);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 28,
                column: "PreviousTimeSlotId",
                value: 26);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 29,
                column: "PreviousTimeSlotId",
                value: 27);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 30,
                column: "PreviousTimeSlotId",
                value: 28);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 31,
                column: "PreviousTimeSlotId",
                value: 29);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 32,
                column: "PreviousTimeSlotId",
                value: 30);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 33,
                column: "PreviousTimeSlotId",
                value: 31);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 34,
                column: "PreviousTimeSlotId",
                value: 32);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 35,
                column: "PreviousTimeSlotId",
                value: 33);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 36,
                column: "PreviousTimeSlotId",
                value: 34);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 37,
                column: "PreviousTimeSlotId",
                value: 35);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 38,
                column: "PreviousTimeSlotId",
                value: 36);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 39,
                column: "PreviousTimeSlotId",
                value: 37);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 40,
                column: "PreviousTimeSlotId",
                value: 38);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 41,
                column: "PreviousTimeSlotId",
                value: 39);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 42,
                column: "PreviousTimeSlotId",
                value: 40);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 43,
                column: "PreviousTimeSlotId",
                value: 41);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 44,
                column: "PreviousTimeSlotId",
                value: 42);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 45,
                column: "PreviousTimeSlotId",
                value: 43);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 46,
                column: "PreviousTimeSlotId",
                value: 44);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 47,
                column: "PreviousTimeSlotId",
                value: 45);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 48,
                column: "PreviousTimeSlotId",
                value: 46);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 49,
                column: "PreviousTimeSlotId",
                value: 47);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 50,
                column: "PreviousTimeSlotId",
                value: 48);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 51,
                column: "PreviousTimeSlotId",
                value: 49);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 52,
                column: "PreviousTimeSlotId",
                value: 50);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_PreviousTimeSlotId",
                table: "TimeSlots",
                column: "PreviousTimeSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_TimeSlots_PreviousTimeSlotId",
                table: "TimeSlots",
                column: "PreviousTimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_TimeSlots_PreviousTimeSlotId",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_PreviousTimeSlotId",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "PreviousTimeSlotId",
                table: "TimeSlots");
        }
    }
}
