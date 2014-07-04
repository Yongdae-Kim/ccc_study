using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _PerpetualCalendar
{
    class MonthTableMaker
    {
        private int leapDay, dayOfTheYear;

        private Boolean isLeapYear(int solarYear)
        {
            if (solarYear % 4 == 0 && solarYear % 100 != 0 || solarYear % 400 == 0) return true;
            else return false;
        }

        public int getDayOfTheYear(int solarYear)
        {
            if (isLeapYear(solarYear))
                dayOfTheYear = 366;
            else
                dayOfTheYear = 365;

            return dayOfTheYear;
        }

        public int getLeapDay(int solarYear)
        {
            if (isLeapYear(solarYear))
                leapDay = 29;
            else
                leapDay = 28;

            return leapDay;
        }

        public int[] getMonthTable(int solarYear)
        {
            leapDay = this.getLeapDay(solarYear);
            int[] monthTable = { 0, 31, leapDay, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            return monthTable;
        }
    }
}
