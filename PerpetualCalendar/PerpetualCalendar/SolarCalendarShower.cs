using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _PerpetualCalendar
{
    class SolarCalendarShower
    {
        private MonthTableMaker monthTableMaker;

        private int solarYear, solarMonth;
        private int[] solarDayArray, monthTable;

        public SolarCalendarShower(int solarYear, int solarMonth)
        {
            this.solarYear = solarYear;
            this.solarMonth = solarMonth;

            monthTableMaker = new MonthTableMaker();
            this.monthTable = monthTableMaker.getMonthTable(solarYear);
        }

        public void makeTheSolarCalendar()
        {
            solarDayArray = new int[monthTable[solarMonth]];
            for (int i = 0; i < monthTable[solarMonth]; i++)
                solarDayArray[i] = i + 1;
        }

        public int[] getSolarDayArray() { return solarDayArray; }
    }
}
