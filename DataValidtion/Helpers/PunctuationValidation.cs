using Newtonsoft.Json;

namespace AppointmentScheduleSystem.DataValidtion.Helpers
{
    internal static class PunctuationValidation
    {
        internal static bool CheckTimeFormat(string ruquiredTime)
        {
            var timeEnumerationDoubleDots = ruquiredTime.Split(':');
            var timeEnumerationDot = ruquiredTime.Split('.');

            // fix timeEnumeration to enumeration of punctuation marks
            // that should be more flexible

            if (timeEnumerationDot != null || timeEnumerationDoubleDots != null)
            {
                return true;
            }
            return false;
        }
    }
}
