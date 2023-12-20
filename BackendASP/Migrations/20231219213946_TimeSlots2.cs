using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendASP.Migrations
{
    /// <inheritdoc />
    public partial class TimeSlots2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Step 2 copy the data 
            migrationBuilder.Sql("INSERT INTO AppointmentTimeSlot (AppointmentsId, TimeSlotsId) " +
                                 "SELECT id, TimeSlotId FROM Appointments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Appointments SET TimeSlotId=" +
                                 "(SELECT TimeSlotsId FROM AppointmentTimeSlot " +
                                 " WHERE AppointmentTimeSlot.AppointmentsId = Appointments.Id)");
        }
    }
}
