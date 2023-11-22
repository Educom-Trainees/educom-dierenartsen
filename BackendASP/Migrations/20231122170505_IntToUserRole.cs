using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class IntToUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "Role", "Salutation" },
                values: new object[,]
                {
                    { 2, "s123s12dass@s.com", "Stijn", "Engelmoer", "$2a$10$gPUJzQBPvMNpuHU2C337n.bmKeTgjjX9PVRFUTVi624lShT3A263u", "123321", 0, "Mevrouw" },
                    { 3, "karel@happypaw.nl", "Karel", "Lant", "$2a$10$fuY21uRpsloZwQCL4SJzUuCv0lvf6H3CfC0QzLP1DAjsV2ntwvbPG", null, 1, "Meneer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "Role", "Salutation" },
                values: new object[] { 9, "s123s12dass@s.com", "Stijn", "Engelmoer", "$2a$10$gPUJzQBPvMNpuHU2C337n.bmKeTgjjX9PVRFUTVi624lShT3A263u", "123321", 0, "Mevrouw" });
        }
    }
}
