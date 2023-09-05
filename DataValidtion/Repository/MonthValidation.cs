using EnumsNET;

namespace AppointmentScheduleSystem.DataValidtion.Repository
{
    public static class MonthValidation<T>
    {
        public static bool Validate(string requestedMonth)
        {
            var months = Enums.GetValues(typeof(T)).Cast<T>().Select(elem => elem.ToString()); // get all month from enum using tempalte

            // find requested month in enum
            foreach (var month in months)
            {
                if (month == requestedMonth)
                {
                    return true; // if found => true
                }
            }
            return false; // else => false
        }
    }
}
