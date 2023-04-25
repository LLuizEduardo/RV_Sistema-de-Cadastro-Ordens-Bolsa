using System;

namespace RV
{
    public class Calendar
    {
        public DateTime CalculateThirdFriday(DateTime date)
        {
            DateTime thirdFriday = new(date.Year, date.Month, 15);

            while (thirdFriday.DayOfWeek != DayOfWeek.Friday)
            {
                thirdFriday = thirdFriday.AddDays(1);
            }

            return thirdFriday;
        }
    }
}
