using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class AddedDoctors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Doctor", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "Role", "Salutation" },
                values: new object[,]
                {
                    { 4, 2, "danique@happypaw.nl", "Danique", "de Beer", "$2a$10$d42bHqP0V.N/99GPmWm6QeSgN92euYdvTHH2SHzHQzI2T2I/6HeIq", "0687654321", 1, "Mevrouw" },
                    { 5, 0, "admin@happypaw.nl", "Admin", "Secretaresse", "$2a$10$ueqBUHOfk8IuBG6XhCZG2.XVuJUfwVQDjhCg4fktmtSVZLaGaXdqG", "0623445443", 2, "Mevrouw" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
