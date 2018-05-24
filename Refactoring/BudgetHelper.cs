using System;
using System.Collections.Generic;
using GOOS_Sample.Models;

namespace GOOS_Sample.Helper
{
    public class BudgetHelper
    {
        public static decimal CalculateTotalBudget(DateRange dateRange, List<Budget> budgetList)
        {
            decimal total = 0;

            foreach (var b in budgetList)
            {
                var month = Convert.ToInt32(b.YearMonth.Substring(b.YearMonth.Length - 2));
                var year = Convert.ToInt32(b.YearMonth.Substring(0, 4));
                var daysInMonth = DateTime.DaysInMonth(year, month);
                var startOfBudget = DateTime.ParseExact(b.YearMonth + "-01", "yyyy-MM-dd", null);
                var endOfBudget = DateTime.ParseExact(b.YearMonth + "-" + daysInMonth, "yyyy-MM-dd", null);
                var averageEachDay = (decimal)b.Amount / daysInMonth;
                int totalDay;

                if (dateRange.Start > endOfBudget || dateRange.End < startOfBudget)
                {
                    totalDay = 0;
                }
                else if (dateRange.Start.ToString("yyyyMM") == dateRange.End.ToString("yyyyMM"))
                {
                    totalDay = (dateRange.End.Day - dateRange.Start.Day + 1);
                }
                else if (dateRange.Start.ToString("yyyyMM") == startOfBudget.ToString("yyyyMM"))
                {
                    totalDay = (daysInMonth - dateRange.Start.Day + 1);
                }
                else if (dateRange.End.ToString("yyyyMM") == startOfBudget.ToString("yyyyMM"))
                {
                    totalDay = dateRange.End.Day;
                }
                else
                {
                    totalDay = daysInMonth;
                }

                total += averageEachDay * totalDay;
            }

            return total;
        }
    }
}