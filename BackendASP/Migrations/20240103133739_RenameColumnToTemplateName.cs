using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnToTemplateName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "EmailTemplates",
                newName: "TemplateName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TemplateName",
                table: "EmailTemplates",
                newName: "Name");
        }
    }
}
