using System;
using System.Collections.Generic;

namespace _11._09_CalculatingWorkingDaysNumber
{
    class Program
    {
        static class HolidaysList
        {
            public class Date
            {
                private int month;
                private int date;

                public int Month
                {
                    get => month;
                    set => month = value;
                }
                public int DayNumber { get => date; set => date = value; }

                public Date(int entryMonth, int entryDate)
                {
                    if ((entryMonth < 1 || entryMonth > 12)) throw new Exception();
                    if (entryDate < 1 || entryDate > 31) throw new Exception();
                    this.Month = entryMonth;
                    this.DayNumber = entryDate;
                }
            }

            static List<Date> holidaysList = new List<Date>();
            static void AddDates(params Date[] dateArr)
            {
                foreach (Date element in dateArr)
                {
                    holidaysList.Add(element);
                }
            }
            static void InitializeHolidays()
            {
                Date newYearEve = new Date(12, 31);
                Date newYearDay = new Date(01, 12);
                Date independenceDay = new Date(07, 04);

                AddDates(newYearEve, newYearDay, independenceDay);
            }
            static HolidaysList()
            {
                InitializeHolidays();

            }


            public static bool Contains(DateTime entryDateTime)
            {
                foreach(Date element in holidaysList)
                {
                    if (element.Month == Convert.ToInt32(entryDateTime.Month))
                    {
                        if (element.DayNumber == Convert.ToInt32(entryDateTime.Day))
                        {
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                return false;
            }
        }
            



        static void Main(string[] args)
        {
            DateTime today = DateTime.Now.Date;
            DateTime thisDayNextYear = DateTime.Now.Date.AddYears(1);
            Console.WriteLine("Today: {0}", today);
            Console.WriteLine("This day in a year: {0}", thisDayNextYear);

           



            DateTime tempDate = today;
            int workingDaysCount = 0;
            while (tempDate < thisDayNextYear)
            {
                tempDate = tempDate.AddDays(1);
                int intDayOfWeek = Convert.ToInt32(tempDate.DayOfWeek);

                if(intDayOfWeek!=0 && intDayOfWeek!=1)
                {
                    continue;
                }
                if (HolidaysList.Contains(tempDate))
                {
                    continue;
                }

                workingDaysCount += 1;

            }
            Console.WriteLine(workingDaysCount);
        }
    }
}
