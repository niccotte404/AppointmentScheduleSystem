using AppointmentScheduleSystem.DataValidtion.Enum;
using EnumsNET;

namespace AppointmentScheduleSystem.DataValidtion.Repository
{
    public static class SimpleDateValidation
    {
        public static bool Validate(int days, string month, int year)
        {
            if (days < 1 || days > 31 || year < 2023) // simple amount limitation
            {
                return false;
            }
            else if (MonthValidation<HugeMonths>.Validate(month) == false && days > 30) // validate months with 31 days
            {
                return false;
            }
            else if (MonthValidation<ExceptionMonth>.Validate(month) == true && days > 28) // validate month with 28 day (I don't use 29 day 'cause I don't need it)
            // if I'll need this there would be a little patch
            {
                return false;
            }
            return true;
        }
    }
}
