using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEmailAndPasswordSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "Body",
                value: "Beste {Naam klant},\r\n\r\nBij deze bevestigen wij dat uw afspraak gepland is voor:\r\n\r\nDatum: {Datum}\r\nTijd: {Tijdslot}\r\nDuur: {Duur}\r\nDierenarts: {Dierenarts}\r\n\r\nWe kijken ernaar uit om uw huisdier te ontvangen. Als u nog specifieke vragen heeft of bepaalde informatie met ons wilt delen, aarzel dan niet om contact met ons op te nemen.\r\n\r\nTot ziens in de praktijk!\r\n\r\nMet vriendelijke groeten,\r\n\r\nKarel en Danique van Dierenpraktijk HappyPaws");

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 2,
                column: "Body",
                value: "Beste {Naam klant},\r\n\r\nWelkom bij Dierenpraktijk HappyPaws! Jouw account is succesvol geactiveerd. Hier zijn je inloggegevens:\r\n\r\nE-mailadres: {Email}\r\n\r\nMet jouw account kun je afspraken plannen en de medische geschiedenis van jouw huisdier(en) volgen. \r\nVoor vragen staan we altijd klaar.\r\n\r\nBedankt voor het vertrouwen in HappyPaws.\r\n\r\nMet vriendelijke groeten,\r\n\r\nKarel en Danique van Dierenpraktijk HappyPaws");

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 3,
                column: "Body",
                value: "Beste {Naam klant},\r\n\r\nHelaas hebben we vernomen dat je jouw geplande afspraak bij HappyPaws Dierenartspraktijk wilt annuleren. \r\nWe begrijpen dat situaties kunnen veranderen, en we willen ervoor zorgen dat het annuleringsproces soepel verloopt.\r\n\r\nHier zijn de details van de geannuleerde afspraak:\r\n\r\nDatum: {Datum}\r\nTijd: {Tijdslot}\r\nDierenarts: {Dierenarts}\r\n\r\nMocht je op een later moment opnieuw een afspraak willen maken, aarzel dan niet om contact met ons op te nemen. \r\n\r\nDe gezondheid en het welzijn van jouw huisdier zijn onze hoogste prioriteit, en we staan altijd klaar om te helpen.                \r\n\r\nBedankt voor je begrip en we hopen je snel weer te zien bij Dierenpraktijk HappyPaws.\r\n\r\nMet vriendelijke groeten,\r\n\r\nKarel en Danique van Dierenpraktijk HappyPaws");

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "Body", "EmailType", "Subject", "TemplateName" },
                values: new object[] { 4, "Beste {Naam klant},\r\n\r\nEr is een wijziging opgetreden in uw afspraakgegevens. Hieronder vind u de nieuwe afspraakgegevens:\r\n\r\nDatum: {Datum}\r\nTijd: {Tijdslot}\r\nDuur: {Duur}\r\nDierenarts: {Dierenarts}\r\n\r\nWe begrijpen dat uw tijd waardevol is, en we willen ervoor zorgen dat u op de hoogte bent van deze verandering. Als deze wijziging problemen oplevert of als u verdere vragen heeft, aarzel dan niet om contact met ons op te nemen.\r\n\r\nBedankt voor uw begrip.\r\n\r\nMet vriendelijke groeten,\r\n\r\nKarel en Danique van Dierenpraktijk HappyPaws", 1, "Wijziging afspraak Dierenpraktijk HappyPaws", "Gewijzigde afspraak" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber" },
                values: new object[] { "de Goede", "BRANDON@GMAIL.COM", "BRANDON@GMAIL.COM", "AQAAAAIAAYagAAAAEJE3/kzxZhl41T3xIBUCIh9qT0kapAo7eGsM5mfailcaVtCdabNrdQRGV9nsoxUmQQ==", "0678904561" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "KAREL@HAPPYPAW.NL", "KAREL@HAPPYPAW.NL", "AQAAAAIAAYagAAAAEA0gZ3SHRvqRjYpoLwD4yv3SL58dXlErFRu+JZqVjBkPeHaUf3qWnNWX3aFaeSZxqg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "DANIQUE@HAPPYPAW.NL", "DANIQUE@HAPPYPAW.NL", "AQAAAAIAAYagAAAAELhnkrmqI76SR4Le6vLbaSEBMMFlGe8qW0cT/ET3PzVqeha38txEbL8MQsk/6Olofg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "ADMIN@HAPPYPAW.NL", "ADMIN@HAPPYPAW.NL", "AQAAAAIAAYagAAAAEOpb/U4gu26yIKC9fsLNgZZ5L6IYN9qxOCtsre70v9NQo92644/kMw8iuLIMxW+hFw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "Body",
                value: "Beste {appointmentDTO.CustomerName},\r\n                <br />\r\n                <br />\r\n                Bij deze bevestigen wij dat uw afspraak gepland is voor:\r\n                <br />\r\n                <br />\r\n                Datum: {appointmentDTO.Date}\r\n                <br />\r\n                Tijd: {appointmentDTO.TimeSlotTime}\r\n                <br />\r\n                Dierenarts: {appointmentDTO.Doctor.ToFriendlyString()}\r\n                <br />\r\n                <br />\r\n                We kijken ernaar uit om uw huisdier te ontvangen. Als u nog specifieke vragen heeft of bepaalde informatie met ons wilt delen, aarzel dan niet om contact met ons op te nemen.\r\n                <br />\r\n                <br />\r\n                Tot ziens in de praktijk!\r\n                <br />\r\n                <br />\r\n                Met vriendelijke groeten,\r\n                <br />\r\n                <br />\r\n                Karel en Danique van Dierenpraktijk HappyPaws");

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 2,
                column: "Body",
                value: "Beste {userDTO.FirstName} {userDTO.LastName},\r\n                <br />\r\n                <br />\r\n                Welkom bij Dierenpraktijk HappyPaws! Jouw account is succesvol geactiveerd. Hier zijn je inloggegevens:\r\n                <br />\r\n                <br />\r\n                E-mailadres: {userDTO.Email}\r\n                <br />\r\n                <br />\r\n                Met jouw account kun je afspraken plannen en de medische geschiedenis van jouw huisdier(en) volgen. \r\n                Voor vragen staan we altijd klaar.\r\n                <br />\r\n                <br />\r\n                Bedankt voor het vertrouwen in HappyPaws.\r\n                <br />\r\n                <br />\r\n                Met vriendelijke groeten,\r\n                <br />\r\n                <br />\r\n                Karel en Danique van Dierenpraktijk HappyPaws");

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 3,
                column: "Body",
                value: "Beste {appointmentDTO.CustomerName},\r\n                <br />\r\n                <br />\r\n                Helaas hebben we vernomen dat je jouw geplande afspraak bij HappyPaws Dierenartspraktijk wilt annuleren. \r\n                We begrijpen dat situaties kunnen veranderen, en we willen ervoor zorgen dat het annuleringsproces soepel verloopt.\r\n                <br />\r\n                <br />\r\n                Hier zijn de details van de geannuleerde afspraak:\r\n                <br />\r\n                <br />\r\n                Datum: {appointmentDTO.Date}\r\n                <br />\r\n                Tijd: {appointmentDTO.TimeSlotTime}\r\n                <br />\r\n                Dierenarts: {appointmentDTO.Doctor.ToFriendlyString()}\r\n                <br />\r\n                <br />\r\n                Mocht je op een later moment opnieuw een afspraak willen maken, aarzel dan niet om contact met ons op te nemen. \r\n                De gezondheid en het welzijn van jouw huisdier zijn onze hoogste prioriteit, en we staan altijd klaar om te helpen.                <br />\r\n                <br />\r\n                Bedankt voor je begrip en we hopen je snel weer te zien bij Dierenpraktijk HappyPaws.\r\n                <br />\r\n                <br />\r\n                Met vriendelijke groeten,\r\n                <br />\r\n                <br />\r\n                Karel en Danique van Dierenpraktijk HappyPaws");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber" },
                values: new object[] { "Klant", null, null, "$2a$10$SvgoFJscAHARXBJRzqG4wO8.hW5b3Xjoea/5QQchHAAPPYoJZLmpS", "067890456" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { null, null, "$2a$10$fuY21uRpsloZwQCL4SJzUuCv0lvf6H3CfC0QzLP1DAjsV2ntwvbPG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { null, null, "$2a$10$d42bHqP0V.N/99GPmWm6QeSgN92euYdvTHH2SHzHQzI2T2I/6HeIq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { null, null, "$2a$10$ueqBUHOfk8IuBG6XhCZG2.XVuJUfwVQDjhCg4fktmtSVZLaGaXdqG" });
        }
    }
}
