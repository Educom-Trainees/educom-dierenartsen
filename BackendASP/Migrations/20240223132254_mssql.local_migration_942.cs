using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_942 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "Subject",
                value: "Afspraak bevestiging voor {Datum}");

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 3,
                column: "Subject",
                value: "Geannuleerde Afspraak op {Datum}");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEO1FHzFFat2d9ksTlZh4InXc2Hv4Ch3sDbEJPEqHoW2p8ayQdqJh9Gs5uvEEyei4mQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJg+ryqO9m+H6YMc9dGdVyJj4fJQGz2Gp590ESd9SGX+Qan9wRYfNTv6udQTPM69SQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELK3R65wI4GY9m6On1TnMmTibf0TIgjKUSKIcl4RvTv/b2QIpBgHwX5BYe3K5SEeNQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJnqO5970miPMFbyicxM9AjjLc8Q0OU68W1VVOZldriEF+hHwyEivCnyoV8lkpZ5Iw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "Subject",
                value: "Afspraak bevestiging voor {appointmentDTO.Date}");

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 3,
                column: "Subject",
                value: "Geannuleerde Afspraak op {appointmentDTO.Date}");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJE3/kzxZhl41T3xIBUCIh9qT0kapAo7eGsM5mfailcaVtCdabNrdQRGV9nsoxUmQQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEA0gZ3SHRvqRjYpoLwD4yv3SL58dXlErFRu+JZqVjBkPeHaUf3qWnNWX3aFaeSZxqg==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELhnkrmqI76SR4Le6vLbaSEBMMFlGe8qW0cT/ET3PzVqeha38txEbL8MQsk/6Olofg==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOpb/U4gu26yIKC9fsLNgZZ5L6IYN9qxOCtsre70v9NQo92644/kMw8iuLIMxW+hFw==");
        }
    }
}
