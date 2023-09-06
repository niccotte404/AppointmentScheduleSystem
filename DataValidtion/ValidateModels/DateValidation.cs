using AppointmentScheduleSystem.Data.Enum;
using AppointmentScheduleSystem.DataValidtion.Repository;
using AppointmentScheduleSystem.Models;
using AppointmentScheduleSystem.ViewModels;
using EnumsNET;
using System.ComponentModel.DataAnnotations;

namespace AppointmentScheduleSystem.DataValidtion.ValidateModels
{
    public class DateValidation : ValidationAttribute
    {
        public DateValidation()
        {
            ErrorMessage = "Wrong date format";
        }

        public override bool IsValid(object? value)
        {
            Date? date = value as Date;
            var monthInString = Enums.GetValues(typeof(Months)).Cast<Months>().Select(elem => elem.ToString()).ToList()[date.Month]; // get month from enum by index and convert it to 
            return SimpleDateValidation.Validate(date.Day, monthInString, date.Year);
        }
    }
}
