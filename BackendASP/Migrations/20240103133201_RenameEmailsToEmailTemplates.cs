using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class RenameEmailsToEmailTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "Body", "Name", "Subject" },
                values: new object[] { 1, "\"\r\n                Beste {appointmentDTO.CustomerName},\r\n                <br />\r\n                <br />\r\n                Bij deze bevestigen wij dat uw afspraak gepland is voor:\r\n                <br />\r\n                <br />\r\n                Datum: {appointmentDTO.Date}\r\n                <br />\r\n                Tijd: {appointmentDTO.TimeSlotTime}\r\n                <br />\r\n                Dierenarts: {appointmentDTO.Doctor.ToFriendlyString()}\r\n                <br />\r\n                <br />\r\n                We kijken ernaar uit om uw huisdier te ontvangen. Als u nog specifieke vragen heeft of bepaalde informatie met ons wilt delen, aarzel dan niet om contact met ons op te nemen.\r\n                <br />\r\n                <br />\r\n                Tot ziens in de praktijk!\r\n                <br />\r\n                <br />\r\n                Met vriendelijke groeten,\r\n                <br />\r\n                <br />\r\n                Karel en Danique van Dierenpraktijk HappyPaws\r\n                \"", "Appointment Confirmation", "Afspraak bevestiging voor {appointmentDTO.Date}" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Body", "Name", "Subject" },
                values: new object[] { 1, "\"\r\n                Beste {appointmentDTO.CustomerName},\r\n                <br />\r\n                <br />\r\n                Bij deze bevestigen wij dat uw afspraak gepland is voor:\r\n                <br />\r\n                <br />\r\n                Datum: {appointmentDTO.Date}\r\n                <br />\r\n                Tijd: {appointmentDTO.TimeSlotTime}\r\n                <br />\r\n                Dierenarts: {appointmentDTO.Doctor.ToFriendlyString()}\r\n                <br />\r\n                <br />\r\n                We kijken ernaar uit om uw huisdier te ontvangen. Als u nog specifieke vragen heeft of bepaalde informatie met ons wilt delen, aarzel dan niet om contact met ons op te nemen.\r\n                <br />\r\n                <br />\r\n                Tot ziens in de praktijk!\r\n                <br />\r\n                <br />\r\n                Met vriendelijke groeten,\r\n                <br />\r\n                <br />\r\n                Karel en Danique van Dierenpraktijk HappyPaws\r\n                \"", "Appointment Confirmation", "Afspraak bevestiging voor {appointmentDTO.Date}" });
        }
    }
}
