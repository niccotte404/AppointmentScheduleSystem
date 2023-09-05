using AppointmentScheduleSystem.DataValidtion.Enum;
using EnumsNET;

namespace AppointmentScheduleSystem.DataValidtion.Repository
{
    public static class SimpleDateValidation
    {
        public static bool Validate(int days, string month, int year)
        {
            if (days < 1 || days > 31 || year < 2023)
            {
                return false;
            }
            else if (MonthValidation<HugeMonths>.Validate(month) == false && days > 30)
            {
                return false;
            }
            else if (MonthValidation<ExceptionMonth>.Validate(month) == true && days > 28)
            {
                return false;
            }
            return true;
        }
    }
}
