using BackendASP.Models.DTO;
using BackendASP.Models.Enums;

namespace BackendASP.UnitTests.Database
{
    internal class TimeSlotBuilder
    {
        private readonly TimeSlotDTO[] slots = new TimeSlotDTO[22];
        public TimeSlotBuilder()
        {
            slots[(int)EIndex.K_09_00] = new() { Id = 1, Time = "09:00", Doctor = DoctorTypes.KAREL_LANT, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.K_09_15] = new() { Id = 3, Time = "09:15", Doctor = DoctorTypes.KAREL_LANT, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.K_09_30] = new() { Id = 5, Time = "09:30", Doctor = DoctorTypes.KAREL_LANT, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.K_09_45] = new() { Id = 7, Time = "09:45", Doctor = DoctorTypes.KAREL_LANT, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.K_10_00] = new() { Id = 9, Time = "10:00", Doctor = DoctorTypes.KAREL_LANT, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.K_10_15] = new() { Id = 11, Time = "10:15", Doctor = DoctorTypes.KAREL_LANT, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.K_10_30] = new() { Id = 13, Time = "10:30", Doctor = DoctorTypes.KAREL_LANT, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.K_10_45] = new() { Id = 15, Time = "10:45", Doctor = DoctorTypes.KAREL_LANT, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.K_11_00] = new() { Id = 17, Time = "11:00", Doctor = DoctorTypes.KAREL_LANT, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.K_11_15] = new() { Id = 19, Time = "11:15", Doctor = DoctorTypes.KAREL_LANT, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.K_11_30] = new() { Id = 21, Time = "11:30", Doctor = DoctorTypes.KAREL_LANT, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.D_09_00] = new() { Id = 2, Time = "09:00", Doctor = DoctorTypes.DANIQUE_DE_BEER, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.D_09_15] = new() { Id = 4, Time = "09:15", Doctor = DoctorTypes.DANIQUE_DE_BEER, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.D_09_30] = new() { Id = 6, Time = "09:30", Doctor = DoctorTypes.DANIQUE_DE_BEER, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.D_09_45] = new() { Id = 8, Time = "09:45", Doctor = DoctorTypes.DANIQUE_DE_BEER, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.D_10_00] = new() { Id = 10, Time = "10:00", Doctor = DoctorTypes.DANIQUE_DE_BEER, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.D_10_15] = new() { Id = 12, Time = "10:15", Doctor = DoctorTypes.DANIQUE_DE_BEER, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.D_10_30] = new() { Id = 14, Time = "10:30", Doctor = DoctorTypes.DANIQUE_DE_BEER, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.D_10_45] = new() { Id = 16, Time = "10:45", Doctor = DoctorTypes.DANIQUE_DE_BEER, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.D_11_00] = new() { Id = 18, Time = "11:00", Doctor = DoctorTypes.DANIQUE_DE_BEER, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.D_11_15] = new() { Id = 20, Time = "11:15", Doctor = DoctorTypes.DANIQUE_DE_BEER, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.D_11_30] = new() { Id = 22, Time = "11:30", Doctor = DoctorTypes.DANIQUE_DE_BEER, Available = SlotAvailable.AVAILABLE_45 };
        }

        internal List<TimeSlotDTO> GetSlots()
        {
            return slots.ToList();
        }

        internal void SetAvailable(EIndex index, SlotAvailable slotAvailable)
        {
            slots[(int)index].Available = slotAvailable;
        }
    }
    public enum EIndex
    {
        K_09_00 = 0,
        D_09_00 = 1,
        K_09_15 = 2,
        D_09_15 = 3,
        K_09_30 = 4,
        D_09_30 = 5,
        K_09_45 = 6,
        D_09_45 = 7,
        K_10_00 = 8,
        D_10_00 = 9,
        K_10_15 = 10,
        D_10_15 = 11,
        K_10_30 = 12,
        D_10_30 = 13,
        K_10_45 = 14,
        D_10_45 = 15,
        K_11_00 = 16,
        D_11_00 = 17,
        K_11_15 = 18,
        D_11_15 = 19,
        K_11_30 = 20,
        D_11_30 = 21,
    }
}