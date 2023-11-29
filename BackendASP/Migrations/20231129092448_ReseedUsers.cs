using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class ReseedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Salutation", "FirstName", "LastName", "Email", "PhoneNumber", "PasswordHash", "Doctor", "Role" },
                values: new object[,]
                {
                    { 1, "Meneer", "Brandon", "Klant", "brandon@gmail.com", "067890456", "$2a$10$SvgoFJscAHARXBJRzqG4wO8.hW5b3Xjoea/5QQchHAAPPYoJZLmpS", 0, 0 },
                    { 2, "Mevrouw", "Stijn", "Engelmoer", "s123s12dass@s.com", "123321", "$2a$10$gPUJzQBPvMNpuHU2C337n.bmKeTgjjX9PVRFUTVi624lShT3A263u", 0, 0 },
                    { 3, "Meneer", "Karel", "Lant", "karel@happypaw.nl", null, "$2a$10$fuY21uRpsloZwQCL4SJzUuCv0lvf6H3CfC0QzLP1DAjsV2ntwvbPG", 1, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3 });
        }
    }
}