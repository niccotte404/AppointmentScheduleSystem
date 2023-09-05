using AppointmentScheduleSystem.DataValidtion.Enum;
using EnumsNET;

namespace AppointmentScheduleSystem.DataValidtion.Repository
{
    public static class MonthValidation<T>
    {
        public static bool Validate(string requestedMonth)
        {
            var months = Enums.GetValues(typeof(T)).Cast<T>().Select(elem => elem.ToString());

            foreach (var month in months)
            {
                if (month == requestedMonth)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
