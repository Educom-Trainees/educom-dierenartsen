using BackendASP.Models;
using BackendASP.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendASP.UnitTests.Services
{
    internal class TimeSlotServiceTests
    {
        [Test]
        public void GenerateSchedule()
        {
            // prepare
            TimeSlotBuilder tsb = new TimeSlotBuilder(false);
            tsb.AddAvailableDays();
            List<TimeSlot> start = tsb.GetTimeSlots();

            // run


            // test
            Assert.Fail("Not defined yet.");
        }
    }
}
