using System;

namespace DatingApp.API.Extensions
{
    // Extension class (Must be static)
    public static class DateTimeExtension
    {
        public static int CalculateAge(this DateTime dob)
        {

            var today = DateTime.Today;
            var age = today.Year - dob.Year;
            if (dob.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}