using System;

namespace GOOS_Sample.Models
{
    public class Budget
    {
        public string YearMonth { get; set; }

        public long Amount { get; set; }

        public int Year => Convert.ToInt32(YearMonth.Substring(0, 4));

        public int Month => Convert.ToInt32(YearMonth.Substring(YearMonth.Length - 2));

        public int DaysInMonth => DateTime.DaysInMonth(Year, Month);

        public DateTime EndOfBudget => DateTime.ParseExact(YearMonth + "-" + DaysInMonth, "yyyy-MM-dd", null);

        public DateTime StartOfBudget => DateTime.ParseExact(YearMonth + "-01", "yyyy-MM-dd", null);

        public decimal DailyAmount => (decimal)Amount / DaysInMonth;
    }
}