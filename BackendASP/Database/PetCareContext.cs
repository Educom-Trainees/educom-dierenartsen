using BackendASP.Models;
using BackendASP.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace BackendASP.Database
{
    public class PetCareContext : DbContext
    {
        private readonly IConfiguration _configuration;


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

        public PetCareContext(IConfiguration config)
        {
            _configuration = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(_configuration.GetConnectionString("PetCareDatabase"), x => x.UseDateOnlyTimeOnly());
            optionsBuilder.UseMySql(_configuration.GetConnectionString("PetCareDatabaseMySql"), ServerVersion.AutoDetect(_configuration.GetConnectionString("PetCareDatabaseMySql")));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                    PetTypeId = 4,
                    AppointmentTypeId = 5,
                    TimeSlotId = 6
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

            modelBuilder.Entity<User>().HasData(
                 new
                 {
                     Id = 1,
                     Salutation = "Meneer",
                     FirstName = "Brandon",
                     LastName = "Klant",
                     Email = "brandon@gmail.com",
                     PhoneNumber = "067890456",
                     PasswordHash = "$2a$10$SvgoFJscAHARXBJRzqG4wO8.hW5b3Xjoea/5QQchHAAPPYoJZLmpS",
                     Doctor = DoctorTypes.NO_PREFERENCE,
                     Role = UserRoles.GUEST
                 },
                 new
                 {
                     Id = 2,
                     Salutation = "Mevrouw",
                     FirstName = "Stijn",
                     LastName = "Engelmoer",
                     Email = "s123s12dass@s.com",
                     PhoneNumber = "123321",
                     PasswordHash = "$2a$10$gPUJzQBPvMNpuHU2C337n.bmKeTgjjX9PVRFUTVi624lShT3A263u",
                     Doctor = DoctorTypes.NO_PREFERENCE,
                     Role = UserRoles.GUEST
                 },
                 new
                 {
                     Id = 3,
                     Salutation = "Meneer",
                     FirstName = "Karel",
                     LastName = "Lant",
                     Email = "karel@happypaw.nl",
                     PhoneNumber = "0611223344",
                     PasswordHash = "$2a$10$fuY21uRpsloZwQCL4SJzUuCv0lvf6H3CfC0QzLP1DAjsV2ntwvbPG",
                     Doctor = DoctorTypes.KAREL_LANT,
                     Role = UserRoles.EMPLOYEE
                 },
                new
                {
                    Id = 4,
                    Salutation = "Mevrou",
                    FirstName = "Danique",
                    LastName = "de Beer",
                    Email = "danique@happypaw.nl",
                    PhoneNumber = "0687654321",
                    PasswordHash = "$2a$10$d42bHqP0V.N/99GPmWm6QeSgN92euYdvTHH2SHzHQzI2T2I/6HeIq",
                    Doctor = DoctorTypes.DANIQUE_DE_BEER,
                    Role = UserRoles.EMPLOYEE
                },
                new
                {
                    Id = 5,
                    Salutation = "Mevrouw",
                    FirstName = "Admin",
                    LastName = "Secretaresse",
                    Email = "admin@happypaw.nl",
                    PhoneNumber = "0623445443",
                    PasswordHash = "$2a$10$ueqBUHOfk8IuBG6XhCZG2.XVuJUfwVQDjhCg4fktmtSVZLaGaXdqG",
                    Doctor = DoctorTypes.NO_PREFERENCE,
                    Role = UserRoles.ADMIN
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
