namespace AppointmentScheduleSystem.DataValidtion.Helpers
{
    public static class SimpleTimeValidation
    {
        public static bool IsTimeValid(string time)
        {
            if (PunctuationValidation.CheckTimeFormat(time) == true)
            {
                return true;
            }
            return false;
        }
    }
}
