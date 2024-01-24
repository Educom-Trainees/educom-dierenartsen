using BackendASP.Models.DTO;
using BackendASP.Models.Enums;

namespace BackendASP.UnitTests.Database
{
    internal class TimeSlotBuilder
    {
        private readonly TimeSlotDTO[] slots = new TimeSlotDTO[20];
        public TimeSlotBuilder(bool afternoon)
        {
            slots[(int)EIndex.K_09_15] = new() { Id = afternoon ? 27 : 3, Time = afternoon ? "14:15" : "09:15", Doctor = DoctorTypes.KAREL_LANT, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.K_09_30] = new() { Id = afternoon ? 29 : 5, Time = afternoon ? "14:30" : "09:30", Doctor = DoctorTypes.KAREL_LANT, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.K_09_45] = new() { Id = afternoon ? 31 : 7, Time = afternoon ? "14:45" : "09:45", Doctor = DoctorTypes.KAREL_LANT, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.K_10_00] = new() { Id = afternoon ? 33 : 9, Time = afternoon ? "15:00" : "10:00", Doctor = DoctorTypes.KAREL_LANT, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.K_10_15] = new() { Id = afternoon ? 35 : 11, Time = afternoon ? "15:15" : "10:15", Doctor = DoctorTypes.KAREL_LANT, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.K_10_30] = new() { Id = afternoon ? 37 : 13, Time = afternoon ? "15:30" : "10:30", Doctor = DoctorTypes.KAREL_LANT, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.K_10_45] = new() { Id = afternoon ? 39 : 15, Time = afternoon ? "15:45" : "10:45", Doctor = DoctorTypes.KAREL_LANT, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.K_11_00] = new() { Id = afternoon ? 41 : 17, Time = afternoon ? "16:00" : "11:00", Doctor = DoctorTypes.KAREL_LANT, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.K_11_15] = new() { Id = afternoon ? 43 : 19, Time = afternoon ? "16:15" : "11:15", Doctor = DoctorTypes.KAREL_LANT, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.K_11_30] = new() { Id = afternoon ? 45 : 21, Time = afternoon ? "16:30" : "11:30", Doctor = DoctorTypes.KAREL_LANT, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.D_09_15] = new() { Id = afternoon ? 33 : 4, Time = afternoon ? "15:00" : "09:15", Doctor = DoctorTypes.DANIQUE_DE_BEER, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.D_09_30] = new() { Id = afternoon ? 33 : 6, Time = afternoon ? "15:00" : "09:30", Doctor = DoctorTypes.DANIQUE_DE_BEER, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.D_09_45] = new() { Id = afternoon ? 33 : 8, Time = afternoon ? "15:00" : "09:45", Doctor = DoctorTypes.DANIQUE_DE_BEER, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.D_10_00] = new() { Id = afternoon ? 33 : 10, Time = afternoon ? "15:00" : "10:00", Doctor = DoctorTypes.DANIQUE_DE_BEER, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.D_10_15] = new() { Id = afternoon ? 33 : 12, Time = afternoon ? "15:00" : "10:15", Doctor = DoctorTypes.DANIQUE_DE_BEER, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.D_10_30] = new() { Id = afternoon ? 33 : 14, Time = afternoon ? "15:00" : "10:30", Doctor = DoctorTypes.DANIQUE_DE_BEER, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.D_10_45] = new() { Id = afternoon ? 33 : 16, Time = afternoon ? "15:00" : "10:45", Doctor = DoctorTypes.DANIQUE_DE_BEER, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.D_11_00] = new() { Id = afternoon ? 33 : 18, Time = afternoon ? "15:00" : "11:00", Doctor = DoctorTypes.DANIQUE_DE_BEER, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.D_11_15] = new() { Id = afternoon ? 33 : 20, Time = afternoon ? "15:00" : "11:15", Doctor = DoctorTypes.DANIQUE_DE_BEER, Available = SlotAvailable.AVAILABLE_45 };
            slots[(int)EIndex.D_11_30] = new() { Id = afternoon ? 33 : 22, Time = afternoon ? "15:00" : "11:30", Doctor = DoctorTypes.DANIQUE_DE_BEER, Available = SlotAvailable.AVAILABLE_45 };
        }

        internal List<TimeSlotDTO> GetSlots()
        {
            // Return a list of copies here, so we can reuse our builder to build upon the list for the expected value
            return slots.Select(s => new TimeSlotDTO() { Id = s.Id, Time = s.Time, Doctor = s.Doctor, Available = s.Available }).ToList();
        }

        internal void SetAvailable(EIndex index, SlotAvailable slotAvailable)
        {
            slots[(int)index].Available = slotAvailable;
        }

        /// <summary>
        /// Mark a 15 minute slot BOOKED and the entries before that are AVALIABLE_15 and AVAILABLE_30
        /// </summary>
        /// <param name="index">The first index</param>
        /// <exception cref="ArgumentException">When last is before or same as first or when the indexes are from different doctors </exception>
        internal void MarkBooked(EIndex index)
        {
            MarkBooked(index, (EIndex)(index + 2));
        }

        /// <summary>
        /// Mark a number of slot BOOKED and the entries before that are AVALIABLE_15 and AVAILABLE_30
        /// </summary>
        /// <param name="index">The first index</param>
        /// <param name="untilExcluded">The index AFTER the booked period</param>
        /// <exception cref="ArgumentException">When last is before or same as first or when the indexes are from different doctors </exception>
        internal void MarkBooked(EIndex index, EIndex untilExcluded)
        {
            int start = (int)index;
            int end = (int)untilExcluded;
            if ((end - start) <= 0 || (end - start) % 2 != 0)
            {
                throw new ArgumentException("Last index should be of the same doctor and after 'index'", nameof(untilExcluded));
            }

            for (int i = start; i < end; i += 2)
            {
                slots[i].Available = SlotAvailable.BOOKED;
            }

            if (start >= 2 && slots[start - 2].Available > SlotAvailable.AVAILABLE_15)
            {
                slots[start - 2].Available = SlotAvailable.AVAILABLE_15;
            }
            if (start >= 4 && slots[start - 4].Available > SlotAvailable.AVAILABLE_30)
            {
                slots[start - 4].Available = SlotAvailable.AVAILABLE_30;
            }
        }
    }
    public enum EIndex
    {
        K_09_15 = 0,
        D_09_15 = 1,
        K_09_30 = 2,
        D_09_30 = 3,
        K_09_45 = 4,
        D_09_45 = 5,
        K_10_00 = 6,
        D_10_00 = 7,
        K_10_15 = 8,
        D_10_15 = 9,
        K_10_30 = 10,
        D_10_30 = 11,
        K_10_45 = 12,
        D_10_45 = 13,
        K_11_00 = 14,
        D_11_00 = 15,
        K_11_15 = 16,
        D_11_15 = 17,
        K_11_30 = 18,
        D_11_30 = 19,

        K_14_15 = 0,
        D_14_15 = 1,
        K_14_30 = 2,
        D_14_30 = 3,
        K_14_45 = 4,
        D_14_45 = 5,
        K_15_00 = 6,
        D_15_00 = 7,
        K_15_15 = 8,
        D_15_15 = 9,
        K_15_30 = 10,
        D_15_30 = 11,
        K_15_45 = 12,
        D_15_45 = 13,
        K_16_00 = 14,
        D_16_00 = 15,
        K_16_15 = 16,
        D_16_15 = 17,
        K_16_30 = 18,
        D_16_30 = 19,
    }
}