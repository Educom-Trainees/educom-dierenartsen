using BackendASP.Controllers;
using BackendASP.Models.DTO;
using BackendASP.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendASP.UnitTests.Database
{
    internal class TimeSlotControllerTests
    {
        static bool InTimeWindow(TimeSlotDTO s)
        {
            return (s.Time == "10:00" || s.Time == "10:15" || s.Time == "10:30" || s.Time == "10:45");
        }

        [Test]
        public void TestGetEmptyListOfTimeSlotDTOs()
        {
            // Prepare
            TimeSlotBuilder tsb = new TimeSlotBuilder();
            List<TimeSlotDTO> start = tsb.GetSlots();

            // Run
            var result = TimeSlotsController.CalculateBreak(start);

            // Validate
            Assert.That(result, Has.Count.EqualTo(22));
            Assert.That(result, Has.None.Property(nameof(TimeSlotDTO.Available)).EqualTo(SlotAvailable.BREAK));
            Assert.That(result, Has.All.Property(nameof(TimeSlotDTO.Available)).EqualTo(SlotAvailable.AVAILABLE_45));
        }

        [Test]
        public void TestBookedOutsideWindow()
        {
            // Prepare
            TimeSlotBuilder tsb = new TimeSlotBuilder();
            tsb.SetAvailable(EIndex.K_09_45, SlotAvailable.BOOKED);
            tsb.SetAvailable(EIndex.K_09_30, SlotAvailable.AVAILABLE_15);
            tsb.SetAvailable(EIndex.K_09_15, SlotAvailable.AVAILABLE_30);
            List<TimeSlotDTO> start = tsb.GetSlots();

            // Run
            var result = TimeSlotsController.CalculateBreak(start);

            // Validate
            Assert.That(result, Has.Count.EqualTo(22));
            Assert.That(result, Has.None.Property(nameof(TimeSlotDTO.Available)).EqualTo(SlotAvailable.BREAK));
            Assert.That(result.Where(s =>s.Doctor == DoctorTypes.KAREL_LANT && InTimeWindow(s)), Has.All.Property(nameof(TimeSlotDTO.Available)).EqualTo(SlotAvailable.AVAILABLE_45));
        }

        [Test]
        public void TestBookedInsideWindow()
        {
            // Prepare
            TimeSlotBuilder tsb = new TimeSlotBuilder();
            tsb.SetAvailable(EIndex.K_10_00, SlotAvailable.BOOKED);
            tsb.SetAvailable(EIndex.K_09_45, SlotAvailable.AVAILABLE_15);
            tsb.SetAvailable(EIndex.K_09_30, SlotAvailable.AVAILABLE_30);
            List<TimeSlotDTO> start = tsb.GetSlots();

            // Run
            var result = TimeSlotsController.CalculateBreak(start);

            // Validate
            Assert.That(result, Has.Count.EqualTo(22));
            Assert.That(result, Has.None.Property(nameof(TimeSlotDTO.Available)).EqualTo(SlotAvailable.BREAK));
            Assert.That(result, Has.ItemAt(EIndex.K_10_15).Property(nameof(TimeSlotDTO.Available)).EqualTo(SlotAvailable.AVAILABLE_30));
        }

    }
}
