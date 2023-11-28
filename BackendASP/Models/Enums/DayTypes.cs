namespace BackendASP.Models.Enums
{
    [Flags]
    public enum DayTypes
    {
     /*   SUNDAY = 0b00000001,
        MONDAY = 0b00000010,
        TUESDAY = 0b00000100,
        WEDNESDAY = 0b00001000,
        THURSDAY = 0b00010000,
        FRIDAY = 0b00100000,
        SATURDAY = 0b01000000,
*/
        SUNDAY = 1 << DayOfWeek.Sunday,      // 0b00000001
        MONDAY = 1 << DayOfWeek.Monday,      // 0b00000010
        TUESDAY = 1 << DayOfWeek.Tuesday,    // 0b00000100
        WEDNESDAY = 1 << DayOfWeek.Wednesday,// 0b00001000
        THURSDAY = 1 << DayOfWeek.Thursday,  // 0b00010000
        FRIDAY = 1 << DayOfWeek.Friday,      // 0b00100000
        SATURDAY = 1 << DayOfWeek.Saturday,  // 0b01000000

        ALL_DAYS = SUNDAY | MONDAY | TUESDAY | WEDNESDAY | THURSDAY | FRIDAY | SATURDAY,
        WORKING_DAYS = TUESDAY | WEDNESDAY | THURSDAY | FRIDAY | SATURDAY,
    }
}
