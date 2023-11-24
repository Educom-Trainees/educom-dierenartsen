using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class AddedCalculation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calculations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: true),
                    PetTypeId = table.Column<int>(type: "int", nullable: true),
                    TreatmentTimeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calculations_PetTypes_PetTypeId",
                        column: x => x.PetTypeId,
                        principalTable: "PetTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Calculations_TreatmentTimes_TreatmentTimeId",
                        column: x => x.TreatmentTimeId,
                        principalTable: "TreatmentTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Calculations",
                columns: new[] { "Id", "Count", "Duration", "PetTypeId", "TreatmentTimeId" },
                values: new object[,]
                {
                    { 1, null, 15, null, 1 },
                    { 2, null, 15, null, 2 },
                    { 3, 4, 30, null, 2 },
                    { 4, null, 15, null, 3 },
                    { 5, 3, 30, null, 3 },
                    { 6, 4, 30, null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calculations_PetTypeId",
                table: "Calculations",
                column: "PetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Calculations_TreatmentTimeId",
                table: "Calculations",
                column: "TreatmentTimeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calculations");
        }
    }
}
