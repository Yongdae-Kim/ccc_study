using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _PerpetualCalendar
{
    class Calculator
    {
        private MonthTableMaker monthTableMaker;

        private int solarYear, solarMonth;
        private int startDayPosition = 0;
        private int elapsedDay = 0;
        private int[] monthTable;

        public Calculator(int solarYear, int solarMonth)
        {
            this.solarYear = solarYear;
            this.solarMonth = solarMonth;

            monthTableMaker = new MonthTableMaker();
            this.monthTable = monthTableMaker.getMonthTable(solarYear);
        }

        public void calculateTheStartDayPosition()
        {
            int century, year, inYear, inMonth;
            inYear = solarYear;
            inMonth = solarMonth;

            if ((inMonth == 1) || (inMonth == 2))
            {
                inYear--;
                inMonth += 12;
            }
            century = inYear / 100;
            year = inYear % 100;

            startDayPosition = ((21 * century / 4) + (5 * year / 4) + (26 * (inMonth + 1)) / 10) % 7;
        }

        public void calculateTheElapsedDay()
        {
            this.addTheElapsedYear();
            this.addTheElapsedMonth();        
        }

        private void addTheElapsedYear()
        {
            for (int i = 1; i < solarYear; i++)
                elapsedDay = elapsedDay + monthTableMaker.getDayOfTheYear(i);
        }

        private void addTheElapsedMonth()
        {
            for (int i = 1; i < solarMonth; i++)
                elapsedDay = elapsedDay + monthTable[i];
        }

        public int getStartDayPosition() { return startDayPosition; }
        public int getEndDay() { return monthTable[solarMonth]; }
        public int getElapsedDay() { return elapsedDay; }
    }
}
