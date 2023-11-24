using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class ReseedAppointmentTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Delete existing data
            migrationBuilder.Sql("DELETE FROM AppointmentTypes");

            // Insert new data
            migrationBuilder.InsertData(
                table: "AppointmentTypes",
                columns: new[] { "Id", "Name", "TreatmentTimeId" },
                values: new object[,]
                {
            { 1, "consult", 2 },
            { 2, "eerste consult", 4 },
            { 3, "vaccinatie", 3 },
            { 4, "anaal klieren legen", 4 },
            { 5, "nagels knippen", 2 },
            { 6, "bloed onderzoek", 3 },
            { 7, "urine onderzoek", 3 },
            { 8, "gebitscontrole", 2 },
            { 9, "postoperatieve controle", 2 },
            { 10, "herhaal recept bestellen", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
