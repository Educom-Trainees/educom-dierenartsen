using BackendASP.Controllers;
using BackendASP.Models.DTO;
using BackendASP.Models.Enums;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendASP.UnitTests.Controllers
{
    internal class TimeSlotControllerTests
    {
        static bool InTimeWindow(TimeSlotDTO s)
        {
            return s.Time == "10:00" || s.Time == "10:15" || s.Time == "10:30" || s.Time == "10:45";
        }

        [Test]
        public void TestGetEmptyListOfTimeSlotDTOs()
        {
            // Prepare
            TimeSlotBuilder tsb = new TimeSlotBuilder(false);
            List<TimeSlotDTO> start = tsb.GetTimeSlotDTOs();

            // Run
            var result = TimeSlotsController.CalculateBreak(start);

            // Validate
            Assert.That(result, Has.Count.EqualTo(20));
            Assert.That(result, Has.None.Available().EqualTo(SlotAvailable.BREAK));
            Assert.That(result, Has.All.Available().EqualTo(SlotAvailable.AVAILABLE_45));
        }

        [Test]
        public void TestBookedOutsideWindow()
        {
            // Prepare
            TimeSlotBuilder tsb = new TimeSlotBuilder(false);
            tsb.MarkBooked(EIndex.K_09_45); // Mark 9:45 - 10:00 booked for Karel
            List<TimeSlotDTO> start = tsb.GetTimeSlotDTOs();

            // Run
            var result = TimeSlotsController.CalculateBreak(start);

            // Validate
            Assert.That(result, Has.Count.EqualTo(20));
            Assert.That(result, Has.None.Available().EqualTo(SlotAvailable.BREAK));
            Assert.That(result.Where(s => s.Doctor == DoctorTypes.KAREL_LANT && InTimeWindow(s)), Has.All.Available().EqualTo(SlotAvailable.AVAILABLE_45));
        }

        [Test]
        public void TestBookedInsideWindow_NoBreakNeededYet()
        {
            // Prepare
            TimeSlotBuilder tsb = new TimeSlotBuilder(false);
            tsb.MarkBooked(EIndex.K_10_00, EIndex.K_10_15); // Mark 10:00 - 10:15 booked for Karel
            List<TimeSlotDTO> start = tsb.GetTimeSlotDTOs();
            // prepare expected result
            tsb.SetAvailable(EIndex.K_10_15, SlotAvailable.AVAILABLE_30); // Expect 10:15 to 10:45 to be restricted, to prevent a booking from 10:15 to 11:00
            List<TimeSlotDTO> expected = tsb.GetTimeSlotDTOs();

            // Run
            var result = TimeSlotsController.CalculateBreak(start);

            // Validate
            Assert.That(result, Has.Count.EqualTo(20));
            Assert.That(result, Has.None.Available().EqualTo(SlotAvailable.BREAK));
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestBreakNeeded_2Bookings_InLine()
        {
            // Prepare
            TimeSlotBuilder tsb = new TimeSlotBuilder(false);
            tsb.MarkBooked(EIndex.K_10_00, EIndex.K_10_15); // Mark 10:00 - 10:15 booked for Karel
            tsb.MarkBooked(EIndex.K_10_15, EIndex.K_10_45); // Mark 10:15 - 10:45 booked for Karel
            List<TimeSlotDTO> start = tsb.GetTimeSlotDTOs();
            // prepare expected result
            tsb.SetAvailable(EIndex.K_10_45, SlotAvailable.BREAK);
            tsb.SetAvailable(EIndex.D_10_45, SlotAvailable.BREAK);
            List<TimeSlotDTO> expected = tsb.GetTimeSlotDTOs();

            // Run
            var result = TimeSlotsController.CalculateBreak(start);

            // Validate
            Assert.That(result, Has.Count.EqualTo(20));
            Assert.That(result, Has.Exactly(2).Available().EqualTo(SlotAvailable.BREAK));
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TestBreakNeeded_2Bookings_NotInLine()
        {
            // Prepare
            TimeSlotBuilder tsb = new TimeSlotBuilder(false);
            tsb.MarkBooked(EIndex.K_10_00, EIndex.K_10_30); // Mark 10:00 - 10:30 booked for Karel
            tsb.MarkBooked(EIndex.K_10_45, EIndex.K_11_30); // Mark 10:45 - 11:30 booked for Karel
            List<TimeSlotDTO> start = tsb.GetTimeSlotDTOs();
            // prepare expected result
            tsb.SetAvailable(EIndex.K_10_30, SlotAvailable.BREAK);
            tsb.SetAvailable(EIndex.D_10_30, SlotAvailable.BREAK);
            List<TimeSlotDTO> expected = tsb.GetTimeSlotDTOs();

            // Run
            var result = TimeSlotsController.CalculateBreak(start);

            // Validate
            Assert.That(result, Has.Count.EqualTo(20));
            Assert.That(result, Has.Exactly(2).Available().EqualTo(SlotAvailable.BREAK));
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestBreakNeeded_3Bookings_NotInLine_NotSameDoctor()
        {
            // Prepare
            TimeSlotBuilder tsb = new TimeSlotBuilder(false);
            tsb.MarkBooked(EIndex.K_10_00, EIndex.K_10_15); // Mark 10:00 - 10:15 booked for Karel
            tsb.MarkBooked(EIndex.D_10_30, EIndex.D_10_45); // Mark 10:30 - 10:45 booked for Danique
            tsb.MarkBooked(EIndex.K_10_45, EIndex.K_11_30); // Mark 10:45 - 11:30 booked for Karel
            List<TimeSlotDTO> start = tsb.GetTimeSlotDTOs();
            // prepare expected result
            tsb.SetAvailable(EIndex.K_10_15, SlotAvailable.BREAK);
            tsb.SetAvailable(EIndex.D_10_15, SlotAvailable.BREAK);
            List<TimeSlotDTO> expected = tsb.GetTimeSlotDTOs();

            // Run
            var result = TimeSlotsController.CalculateBreak(start);

            // Validate
            Assert.That(result, Has.Count.EqualTo(20));
            Assert.That(result, Has.Exactly(2).Available().EqualTo(SlotAvailable.BREAK));
            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
