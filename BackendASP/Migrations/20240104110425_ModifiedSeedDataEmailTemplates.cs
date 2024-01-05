using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedSeedDataEmailTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "Body",
                value: "Beste {appointmentDTO.CustomerName},\r\n                <br />\r\n                <br />\r\n                Bij deze bevestigen wij dat uw afspraak gepland is voor:\r\n                <br />\r\n                <br />\r\n                Datum: {appointmentDTO.Date}\r\n                <br />\r\n                Tijd: {appointmentDTO.TimeSlotTime}\r\n                <br />\r\n                Dierenarts: {appointmentDTO.Doctor.ToFriendlyString()}\r\n                <br />\r\n                <br />\r\n                We kijken ernaar uit om uw huisdier te ontvangen. Als u nog specifieke vragen heeft of bepaalde informatie met ons wilt delen, aarzel dan niet om contact met ons op te nemen.\r\n                <br />\r\n                <br />\r\n                Tot ziens in de praktijk!\r\n                <br />\r\n                <br />\r\n                Met vriendelijke groeten,\r\n                <br />\r\n                <br />\r\n                Karel en Danique van Dierenpraktijk HappyPaws");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "Body",
                value: "\"\r\n                Beste {appointmentDTO.CustomerName},\r\n                <br />\r\n                <br />\r\n                Bij deze bevestigen wij dat uw afspraak gepland is voor:\r\n                <br />\r\n                <br />\r\n                Datum: {appointmentDTO.Date}\r\n                <br />\r\n                Tijd: {appointmentDTO.TimeSlotTime}\r\n                <br />\r\n                Dierenarts: {appointmentDTO.Doctor.ToFriendlyString()}\r\n                <br />\r\n                <br />\r\n                We kijken ernaar uit om uw huisdier te ontvangen. Als u nog specifieke vragen heeft of bepaalde informatie met ons wilt delen, aarzel dan niet om contact met ons op te nemen.\r\n                <br />\r\n                <br />\r\n                Tot ziens in de praktijk!\r\n                <br />\r\n                <br />\r\n                Met vriendelijke groeten,\r\n                <br />\r\n                <br />\r\n                Karel en Danique van Dierenpraktijk HappyPaws\r\n                \"");
        }
    }
}
