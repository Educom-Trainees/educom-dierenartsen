using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class AddedEmailTemplateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "TemplateName",
                value: "Afspraak bevestiging");

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "Body", "Subject", "TemplateName" },
                values: new object[,]
                {
                    { 2, "Beste {userDTO.FirstName} {userDTO.LastName},\r\n                <br />\r\n                <br />\r\n                Welkom bij Dierenpraktijk HappyPaws! Jouw account is succesvol geactiveerd. Hier zijn je inloggegevens:\r\n                <br />\r\n                <br />\r\n                E-mailadres: {userDTO.Email}\r\n                <br />\r\n                <br />\r\n                Met jouw account kun je afspraken plannen en de medische geschiedenis van jouw huisdier(en) volgen. \r\n                Voor vragen staan we altijd klaar.\r\n                <br />\r\n                <br />\r\n                Bedankt voor het vertrouwen in HappyPaws.\r\n                <br />\r\n                <br />\r\n                Met vriendelijke groeten,\r\n                <br />\r\n                <br />\r\n                Karel en Danique van Dierenpraktijk HappyPaws", "Aanmeldingsbevestiging - HappyPaws Dierenartspraktijk", "Aanmeldingsbevestiging" },
                    { 3, "Beste {appointmentDTO.CustomerName},\r\n                <br />\r\n                <br />\r\n                Helaas hebben we vernomen dat je jouw geplande afspraak bij HappyPaws Dierenartspraktijk wilt annuleren. \r\n                We begrijpen dat situaties kunnen veranderen, en we willen ervoor zorgen dat het annuleringsproces soepel verloopt.\r\n                <br />\r\n                <br />\r\n                Hier zijn de details van de geannuleerde afspraak:\r\n                <br />\r\n                <br />\r\n                Datum: {appointmentDTO.Date}\r\n                <br />\r\n                Tijd: {appointmentDTO.TimeSlotTime}\r\n                <br />\r\n                Dierenarts: {appointmentDTO.Doctor.ToFriendlyString()}\r\n                <br />\r\n                <br />\r\n                Mocht je op een later moment opnieuw een afspraak willen maken, aarzel dan niet om contact met ons op te nemen. \r\n                De gezondheid en het welzijn van jouw huisdier zijn onze hoogste prioriteit, en we staan altijd klaar om te helpen.                <br />\r\n                <br />\r\n                Bedankt voor je begrip en we hopen je snel weer te zien bij Dierenpraktijk HappyPaws.\r\n                <br />\r\n                <br />\r\n                Met vriendelijke groeten,\r\n                <br />\r\n                <br />\r\n                Karel en Danique van Dierenpraktijk HappyPaws", "Geannuleerde Afspraak op {appointmentDTO.Date}", "Geannuleerde afspraak" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "TemplateName",
                value: "Appointment Confirmation");
        }
    }
}
