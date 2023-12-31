﻿using BackendASP.Migrations;
using BackendASP.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackendASP.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int AppointmentNumber { get; set; }
        public DateOnly Date { get; set; }
        public int Duration { get; set; }
        [MaxLength(100)]
        public required string CustomerName { get; set; }
        [MaxLength(15)]
        public required string PhoneNumber { get; set; }
        [MaxLength(254)]
        public required string Email { get; set; }
        public DoctorTypes Preference { get; set; }
        public DoctorTypes Doctor { get; set; }
        public StatusTypes Status { get; set; }
        public LateStatus LateStatus { get; set; }

        // FK's
        public required PetType PetType { get; set; }
        public required AppointmentType AppointmentType { get; set; }
        public required ICollection<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();
        public User? User { get; set; }
        virtual public ICollection<AppointmentPet> Pets { get; set; } = new List<AppointmentPet>();
        public required int PetCount { get; set; }
    }
}
