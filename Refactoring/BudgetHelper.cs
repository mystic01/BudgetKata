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

            foreach (var budget in budgetList)
            {
                var daysInMonth = budget.DaysInMonth;
                var startOfBudget = budget.StartOfBudget;
                var endOfBudget = budget.EndOfBudget;
                var dailyAmount = budget.DailyAmount;
                var totalDay = GetOverlapDays(dateRange, endOfBudget, startOfBudget, daysInMonth);

                total += dailyAmount * totalDay;
            }

            return total;
        }

        private static int GetOverlapDays(DateRange dateRange, DateTime endOfBudget, DateTime startOfBudget, int daysInMonth)
        {
            int overlapDays;

            if (dateRange.Start > endOfBudget || dateRange.End < startOfBudget)
            {
                overlapDays = 0;
            }
            else if (dateRange.Start.ToString("yyyyMM") == dateRange.End.ToString("yyyyMM"))
            {
                overlapDays = (dateRange.End.Day - dateRange.Start.Day + 1);
            }
            else if (dateRange.Start.ToString("yyyyMM") == startOfBudget.ToString("yyyyMM"))
            {
                overlapDays = (daysInMonth - dateRange.Start.Day + 1);
            }
            else if (dateRange.End.ToString("yyyyMM") == startOfBudget.ToString("yyyyMM"))
            {
                overlapDays = dateRange.End.Day;
            }
            else
            {
                overlapDays = daysInMonth;
            }

            return overlapDays;
        }
    }
}