using BackendASP.Models.Enums;

namespace BackendASP
{
    public static class DoctorTypeExtensions
    {
        public static string ToFriendlyString(this DoctorTypes doctorType)
        {
            switch (doctorType)
            {
                case DoctorTypes.KAREL_LANT:
                    return "Karel Lant";
                case DoctorTypes.DANIQUE_DE_BEER:
                    return "Danique de Beer";
                default:
                    return doctorType.ToString(); // Default behavior: return the enum name
            }
        }
    }

}
