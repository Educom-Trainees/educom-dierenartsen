using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class AddedPetTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PetTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Plural = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Image = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetTypes_PetTypes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "PetTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "PetTypes",
                columns: new[] { "Id", "Image", "Name", "ParentId", "Plural" },
                values: new object[,]
                {
                    { 1, "dog.png", "hond", null, "honden" },
                    { 2, "black-cat.png", "kat", null, "katten" },
                    { 3, "rabbit.png", "konijn", null, "konijnen" },
                    { 4, "guinea-pig.png", "cavia", null, "cavia's" },
                    { 5, "hamster.png", "hamster", null, "hamsters" },
                    { 6, "rat.png", "rat", null, "ratten" },
                    { 7, "muis.png", "muis", null, "muizen" },
                    { 8, "dog.png", "kleine hond", 1, "kleine honden" },
                    { 9, "dog.png", "grote hond", 1, "grote honden" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetTypes_ParentId",
                table: "PetTypes",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetTypes");
        }
    }
}
