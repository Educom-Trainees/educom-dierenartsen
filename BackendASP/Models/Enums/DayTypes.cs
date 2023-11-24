namespace BackendASP.Models.Enums
{
    [Flags]
    public enum DayTypes
    {
        SUNDAY = 0b00000001,
        MONDAY = 0b00000010,
        TUESDAY = 0b00000100,
        WEDNESDAY = 0b00001000,
        THURSDAY = 0b00010000,
        FRIDAY = 0b00100000,
        SATURDAY = 0b01000000,
        ALL_DAYS = SUNDAY | MONDAY | TUESDAY | WEDNESDAY | THURSDAY | FRIDAY | SATURDAY,
        WORKING_DAYS = TUESDAY | WEDNESDAY | THURSDAY | FRIDAY | SATURDAY,
    }
}
