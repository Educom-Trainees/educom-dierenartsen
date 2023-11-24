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


        public DbSet<User> Users { get; set; }


        public PetCareContext(IConfiguration config)
        {
            _configuration = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("PetCareDatabase"), x => x.UseDateOnlyTimeOnly());
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
                    AppointmentTypeId = 5
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
                new { Id = 9, Duration = 30, TreatmentTimeId = 4}
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
                     Role = UserRoles.GUEST
                 },
                 new
                 {
                     Id = 3,
                     Salutation = "Meneer",
                     FirstName = "Karel",
                     LastName = "Lant",
                     Email = "karel@happypaw.nl",
                     PasswordHash = "$2a$10$fuY21uRpsloZwQCL4SJzUuCv0lvf6H3CfC0QzLP1DAjsV2ntwvbPG",
                     Role = UserRoles.EMPLOYEE
                 });
            base.OnModelCreating(modelBuilder);
        }
    }
}
