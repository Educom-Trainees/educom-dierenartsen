using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class AddedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "PetTypes",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salutation = table.Column<string>(type: "varchar(256)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(256)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(256)", nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(256)", nullable: true),
                    PasswordHash = table.Column<string>(type: "varchar(256)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "Role", "Salutation" },
                values: new object[,]
                {
                    { 1, "brandon@gmail.com", "Brandon", "Klant", "$2a$10$SvgoFJscAHARXBJRzqG4wO8.hW5b3Xjoea/5QQchHAAPPYoJZLmpS", "067890456", 0, "Meneer" },
                    { 9, "s123s12dass@s.com", "Stijn", "Engelmoer", "$2a$10$gPUJzQBPvMNpuHU2C337n.bmKeTgjjX9PVRFUTVi624lShT3A263u", "123321", 0, "Mevrouw" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "PetTypes",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30,
                oldNullable: true);
        }
    }
}
