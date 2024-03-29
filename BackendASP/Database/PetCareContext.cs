﻿using BackendASP.Models;
using BackendASP.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackendASP.Database
{
    public class PetCareContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        private readonly IConfiguration _configuration;
        private readonly IPasswordHasherService _passwordHasher;

        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentPet> AppointmentPets { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }
        public DbSet<TreatmentTime> TreatmentTimes { get; set; }
        public DbSet<Calculation> Calculations { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<AvailableDays> AvailableDays { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<UserPet> UserPets { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }

        public PetCareContext(IConfiguration config, IPasswordHasherService passwordHasher, DbContextOptions options) : base(options)
        {
            _configuration = config;
            _passwordHasher = passwordHasher;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(System.Console.WriteLine, minimumLevel: LogLevel.Information); // turn on logging
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity => { entity.ToTable(name: "Users"); });
            modelBuilder.Entity<IdentityRole<int>>(entity => { entity.ToTable(name: "Roles"); });

            modelBuilder.Entity<PetType>().HasData(
                    new { Id = 1, Name = "hond", Plural = "honden", Image = "dog.png" },
                    new { Id = 2, Name = "kat", Plural = "katten", Image = "black-cat.png" },
                    new { Id = 3, Name = "konijn", Plural = "konijnen", Image = "rabbit.png" },
                    new { Id = 4, Name = "cavia", Plural = "cavia's", Image = "guinea-pig.png" },
                    new { Id = 5, Name = "hamster", Plural = "hamsters", Image = "hamster.png" },
                    new { Id = 6, Name = "rat", Plural = "ratten", Image = "rat.png" },
                    new { Id = 7, Name = "muis", Plural = "muizen", Image = "muis.png" },
                    new { Id = 8, Name = "kleine hond", Plural = "kleine honden", Image = "dog.png", ParentId = 1 },
                    new { Id = 9, Name = "grote hond", Plural = "grote honden", Image = "dog.png", ParentId = 1 }
                );

            modelBuilder.Entity<Appointment>().HasData(
                new
                {
                    Id = 1,
                    AppointmentNumber = 1,
                    Date = DateOnly.Parse("2023-11-20"),
                    Duration = 30,
                    CustomerName = "Corbijn Bulsink",
                    PhoneNumber = "0611330161",
                    Email = "corbijn.bullie@hoi.nl",
                    Preference = DoctorTypes.KAREL_LANT,
                    Doctor = DoctorTypes.KAREL_LANT,
                    Status = StatusTypes.ACTIVE,
                    LateStatus = LateStatus.NOT_LATE,
                    PetTypeId = 4,
                    AppointmentTypeId = 5,
                    TimeSlotId = 6,
                    PetCount = 1
                });

            modelBuilder.Entity<AppointmentPet>().HasData(
                new { Id = 1, Name = "Fifi", AppointmentId = 1 }
            );

            modelBuilder.Entity<AppointmentType>().HasData(
                new { Id = 1, Name = "consult", TreatmentTimeId = 2 },
                new { Id = 2, Name = "eerste consult", TreatmentTimeId = 4 },
                new { Id = 3, Name = "vaccinatie", TreatmentTimeId = 3 },
                new { Id = 4, Name = "anaal klieren legen", TreatmentTimeId = 4 },
                new { Id = 5, Name = "nagels knippen", TreatmentTimeId = 2 },
                new { Id = 6, Name = "bloed onderzoek", TreatmentTimeId = 3 },
                new { Id = 7, Name = "urine onderzoek", TreatmentTimeId = 3 },
                new { Id = 8, Name = "gebitscontrole", TreatmentTimeId = 2 },
                new { Id = 9, Name = "postoperatieve controle", TreatmentTimeId = 2 },
                new { Id = 10, Name = "herhaal recept bestellen", TreatmentTimeId = 1 }
            );

            modelBuilder.Entity<TreatmentTime>().HasData(
                new { Id = 1, Name = "kort" },
                new { Id = 2, Name = "kort - gemiddeld" },
                new { Id = 3, Name = "gemiddeld" },
                new { Id = 4, Name = "gemiddeld - lang" }
            );

            modelBuilder.Entity<Calculation>().HasData(
                new { Id = 1, Duration = 15, TreatmentTimeId = 1 },

                new { Id = 2, Duration = 30, Count = 4, TreatmentTimeId = 2 },
                new { Id = 3, Duration = 15, TreatmentTimeId = 2 },


                new { Id = 4, Duration = 30, Count = 4, TreatmentTimeId = 3 },
                new { Id = 5, Duration = 30, Count = 3, TreatmentTimeId = 3 },
                new { Id = 6, Duration = 15, TreatmentTimeId = 3 },


                new { Id = 7, Duration = 45, Count = 4, TreatmentTimeId = 4 },
                new { Id = 8, Duration = 45, Count = 3, PetTypeId = 9, TreatmentTimeId = 4 },
                new { Id = 9, Duration = 30, TreatmentTimeId = 4 }
            );

            modelBuilder.Entity<TimeSlot>().HasData(
                new { Id = 1, Time = "09:00", Doctor = DoctorTypes.KAREL_LANT },
                new { Id = 2, Time = "09:00", Doctor = DoctorTypes.DANIQUE_DE_BEER },
                new { Id = 3, Time = "09:15", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 1 },
                new { Id = 4, Time = "09:15", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 2 },
                new { Id = 5, Time = "09:30", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 3 },
                new { Id = 6, Time = "09:30", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 4 },
                new { Id = 7, Time = "09:45", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 5 },
                new { Id = 8, Time = "09:45", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 6 },
                new { Id = 9, Time = "10:00", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 7 },
                new { Id = 10, Time = "10:00", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 8 },
                new { Id = 11, Time = "10:15", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 9 },
                new { Id = 12, Time = "10:15", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 10 },
                new { Id = 13, Time = "10:30", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 11 },
                new { Id = 14, Time = "10:30", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 12 },
                new { Id = 15, Time = "10:45", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 13 },
                new { Id = 16, Time = "10:45", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 14 },
                new { Id = 17, Time = "11:00", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 15 },
                new { Id = 18, Time = "11:00", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 16 },
                new { Id = 19, Time = "11:15", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 17 },
                new { Id = 20, Time = "11:15", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 18 },
                new { Id = 21, Time = "11:30", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 19 },
                new { Id = 22, Time = "11:30", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 20 },
                new { Id = 23, Time = "11:45", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 21 },
                new { Id = 24, Time = "11:45", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 22 },
                new { Id = 25, Time = "12:00", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 23 },
                new { Id = 26, Time = "12:00", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 24 },
                new { Id = 27, Time = "14:15", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 25 },
                new { Id = 28, Time = "14:15", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 26 },
                new { Id = 29, Time = "14:30", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 27 },
                new { Id = 30, Time = "14:30", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 28 },
                new { Id = 31, Time = "14:45", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 29 },
                new { Id = 32, Time = "14:45", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 30 },
                new { Id = 33, Time = "15:00", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 31 },
                new { Id = 34, Time = "15:00", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 32 },
                new { Id = 35, Time = "15:15", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 33 },
                new { Id = 36, Time = "15:15", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 34 },
                new { Id = 37, Time = "15:30", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 35 },
                new { Id = 38, Time = "15:30", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 36 },
                new { Id = 39, Time = "15:45", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 37 },
                new { Id = 40, Time = "15:45", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 38 },
                new { Id = 41, Time = "16:00", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 39 },
                new { Id = 42, Time = "16:00", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 40 },
                new { Id = 43, Time = "16:15", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 41 },
                new { Id = 44, Time = "16:15", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 42 },
                new { Id = 45, Time = "16:30", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 43 },
                new { Id = 46, Time = "16:30", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 44 },
                new { Id = 47, Time = "16:45", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 45 },
                new { Id = 48, Time = "16:45", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 46 },
                new { Id = 49, Time = "17:00", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 47 },
                new { Id = 50, Time = "17:00", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 48 },
                new { Id = 51, Time = "17:15", Doctor = DoctorTypes.KAREL_LANT, PreviousTimeSlotId = 49 },
                new { Id = 52, Time = "17:15", Doctor = DoctorTypes.DANIQUE_DE_BEER, PreviousTimeSlotId = 50 }
            );

            modelBuilder.Entity<AvailableDays>().HasData(
                new { Id = 1, TimeSlotId = 1, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 2, TimeSlotId = 2, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 3, TimeSlotId = 3, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 4, TimeSlotId = 4, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 5, TimeSlotId = 5, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 6, TimeSlotId = 6, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 7, TimeSlotId = 7, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 8, TimeSlotId = 8, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 9, TimeSlotId = 9, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 10, TimeSlotId = 10, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 11, TimeSlotId = 11, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 12, TimeSlotId = 12, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 13, TimeSlotId = 13, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 14, TimeSlotId = 14, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 15, TimeSlotId = 15, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 16, TimeSlotId = 16, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 17, TimeSlotId = 17, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 18, TimeSlotId = 18, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 19, TimeSlotId = 19, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 20, TimeSlotId = 20, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 21, TimeSlotId = 21, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 22, TimeSlotId = 22, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 23, TimeSlotId = 23, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 24, TimeSlotId = 24, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 25, TimeSlotId = 25, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 26, TimeSlotId = 26, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 27, TimeSlotId = 27, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 28, TimeSlotId = 28, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 29, TimeSlotId = 29, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 30, TimeSlotId = 30, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 31, TimeSlotId = 31, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 32, TimeSlotId = 32, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 33, TimeSlotId = 33, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 34, TimeSlotId = 34, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 35, TimeSlotId = 35, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 36, TimeSlotId = 36, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 37, TimeSlotId = 37, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 38, TimeSlotId = 38, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 39, TimeSlotId = 39, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 40, TimeSlotId = 40, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 41, TimeSlotId = 41, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 42, TimeSlotId = 42, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 43, TimeSlotId = 43, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 44, TimeSlotId = 44, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 45, TimeSlotId = 45, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 46, TimeSlotId = 46, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 47, TimeSlotId = 47, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 48, TimeSlotId = 48, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 49, TimeSlotId = 49, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 50, TimeSlotId = 50, Days = 0b0000000, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 51, TimeSlotId = 51, Days = 0b1111100, StartDate = DateOnly.Parse("2023-11-01") },
                new { Id = 52, TimeSlotId = 52, Days = 0b0000000, StartDate = DateOnly.Parse("2023-11-01") }
             );

            modelBuilder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 3, Name = "ADMIN", NormalizedName = "admin" },
                new IdentityRole<int> { Id = 2, Name = "EMPLOYEE", NormalizedName = "employee" },
                new IdentityRole<int> { Id = 1, Name = "GUEST", NormalizedName = "guest" }
                );

            modelBuilder.Entity<User>().HasData(
                 new
                 {
                     Id = 1,
                     UserName = "brandon@gmail.com",
                     NormalizedUserName = "BRANDON@GMAIL.COM",
                     Email = "brandon@gmail.com",
                     NormalizedEmail = "BRANDON@GMAIL.COM",
                     EmailConfirmed = true,
                     PasswordHash = _passwordHasher.HashPassword("Hallo123!"),
                     AccessFailedCount = 0,
                     Salutation = "Meneer",
                     FirstName = "Brandon",
                     LastName = "de Goede",
                     PhoneNumber = "0678904561",
                     PhoneNumberConfirmed = true,
                     Doctor = DoctorTypes.NO_PREFERENCE,
                     LockoutEnabled = false,
                     TwoFactorEnabled = false

                 },
                 new
                 {
                     Id = 2,
                     UserName = "karel@happypaw.nl",
                     NormalizedUserName = "KAREL@HAPPYPAW.NL",
                     Email = "karel@happypaw.nl",
                     NormalizedEmail = "KAREL@HAPPYPAW.NL",
                     EmailConfirmed = true,
                     PasswordHash = _passwordHasher.HashPassword("43nvw4zN6F!YBX5"),
                     AccessFailedCount = 0,
                     Salutation = "Meneer",
                     FirstName = "Karel",
                     LastName = "Lant",
                     PhoneNumber = "0611223344",
                     PhoneNumberConfirmed = true,
                     Doctor = DoctorTypes.KAREL_LANT,
                     LockoutEnabled = false,
                     TwoFactorEnabled = false
                 },
                new
                {
                    Id = 3,
                    UserName = "danique@happypaw.nl",
                    NormalizedUserName = "DANIQUE@HAPPYPAW.NL",
                    Email = "danique@happypaw.nl",
                    NormalizedEmail = "DANIQUE@HAPPYPAW.NL",
                    EmailConfirmed = true,
                    PasswordHash = _passwordHasher.HashPassword("9gyoa@8$tapNQPN"), 
                    AccessFailedCount = 0,
                    Salutation = "Mevrouw",
                    FirstName = "Danique",
                    LastName = "de Beer",
                    PhoneNumber = "0687654321",
                    PhoneNumberConfirmed = true,
                    Doctor = DoctorTypes.DANIQUE_DE_BEER,
                    LockoutEnabled = false,
                    TwoFactorEnabled = false
                },
                new
                {
                    Id = 4,
                    UserName = "admin@happypaw.nl",
                    NormalizedUserName = "ADMIN@HAPPYPAW.NL",
                    Email = "admin@happypaw.nl",
                    NormalizedEmail = "ADMIN@HAPPYPAW.NL",
                    EmailConfirmed = true,
                    PasswordHash = _passwordHasher.HashPassword("FPFAr9shsFsi%Rs"),
                    AccessFailedCount = 0,
                    Salutation = "Mevrouw",
                    FirstName = "Admin",
                    LastName = "Secretaresse",
                    PhoneNumber = "0623445443",
                    PhoneNumberConfirmed = true,
                    Doctor = DoctorTypes.NO_PREFERENCE,
                    LockoutEnabled = false,
                    TwoFactorEnabled = false
                }
                );

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>
                {
                    RoleId = 1,
                    UserId = 1
                },
                new IdentityUserRole<int>
                {
                    RoleId = 2,
                    UserId = 2
                },
                new IdentityUserRole<int>
                {
                    RoleId = 2,
                    UserId = 3
                },
                new IdentityUserRole<int>
                {
                    RoleId = 3,
                    UserId = 4
                }
                );

            modelBuilder.Entity<EmailTemplate>().HasData(
                new
                {
                    Id = 1,
                    TemplateName = "Afspraak bevestiging",
                    Subject = "Afspraak bevestiging voor {Datum}",
                    Body = "Beste {Naam klant},\r\n\r\nBij deze bevestigen wij dat uw afspraak gepland is voor:\r\n\r\nDatum: {Datum}\r\nTijd: {Tijdslot}\r\nDuur: {Duur}\r\nDierenarts: {Dierenarts}\r\n\r\nWe kijken ernaar uit om uw huisdier te ontvangen. Als u nog specifieke vragen heeft of bepaalde informatie met ons wilt delen, aarzel dan niet om contact met ons op te nemen.\r\n\r\nTot ziens in de praktijk!\r\n\r\nMet vriendelijke groeten,\r\n\r\nKarel en Danique van Dierenpraktijk HappyPaws",
                    EmailType = EmailTypes.APPOINTMENT
                },
                new
                {
                    Id = 2,
                    TemplateName = "Aanmeldingsbevestiging",
                    Subject = "Aanmeldingsbevestiging - HappyPaws Dierenartspraktijk",
                    Body = "Beste {Naam klant},\r\n\r\nWelkom bij Dierenpraktijk HappyPaws! Jouw account is succesvol geactiveerd. Hier zijn je inloggegevens:\r\n\r\nE-mailadres: {Email}\r\n\r\nMet jouw account kun je afspraken plannen en de medische geschiedenis van jouw huisdier(en) volgen. \r\nVoor vragen staan we altijd klaar.\r\n\r\nBedankt voor het vertrouwen in HappyPaws.\r\n\r\nMet vriendelijke groeten,\r\n\r\nKarel en Danique van Dierenpraktijk HappyPaws",
                    EmailType = EmailTypes.USER
                },
                new
                {
                    Id = 3,
                    TemplateName = "Geannuleerde afspraak",
                    Subject = "Geannuleerde Afspraak op {Datum}",
                    Body = "Beste {Naam klant},\r\n\r\nHelaas hebben we vernomen dat je jouw geplande afspraak bij HappyPaws Dierenartspraktijk wilt annuleren. \r\nWe begrijpen dat situaties kunnen veranderen, en we willen ervoor zorgen dat het annuleringsproces soepel verloopt.\r\n\r\nHier zijn de details van de geannuleerde afspraak:\r\n\r\nDatum: {Datum}\r\nTijd: {Tijdslot}\r\nDierenarts: {Dierenarts}\r\n\r\nMocht je op een later moment opnieuw een afspraak willen maken, aarzel dan niet om contact met ons op te nemen. \r\n\r\nDe gezondheid en het welzijn van jouw huisdier zijn onze hoogste prioriteit, en we staan altijd klaar om te helpen.                \r\n\r\nBedankt voor je begrip en we hopen je snel weer te zien bij Dierenpraktijk HappyPaws.\r\n\r\nMet vriendelijke groeten,\r\n\r\nKarel en Danique van Dierenpraktijk HappyPaws",
                    EmailType = EmailTypes.APPOINTMENT
                },
                new
                {
                    Id = 4,
                    TemplateName = "Gewijzigde afspraak",
                    Subject = "Wijziging afspraak Dierenpraktijk HappyPaws",
                    Body = "Beste {Naam klant},\r\n\r\nEr is een wijziging opgetreden in uw afspraakgegevens. Hieronder vind u de nieuwe afspraakgegevens:\r\n\r\nDatum: {Datum}\r\nTijd: {Tijdslot}\r\nDuur: {Duur}\r\nDierenarts: {Dierenarts}\r\n\r\nWe begrijpen dat uw tijd waardevol is, en we willen ervoor zorgen dat u op de hoogte bent van deze verandering. Als deze wijziging problemen oplevert of als u verdere vragen heeft, aarzel dan niet om contact met ons op te nemen.\r\n\r\nBedankt voor uw begrip.\r\n\r\nMet vriendelijke groeten,\r\n\r\nKarel en Danique van Dierenpraktijk HappyPaws",
                    EmailType = EmailTypes.APPOINTMENT
                }
                );

            
        }
    }
}
