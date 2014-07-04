using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _PerpetualCalendar
{
    class LunarCalendarShower
    {
        private MonthTableMaker monthTableMaker;
        private LunarCalculatorFactory lunarCalculatorFactory;
        private LunarCalculable lunarCalculable; 

        private int solarYear, solarMonth, elaspedDays;
        private String lunarData;
        private int[] solarDayArray, monthTable;
        private String[] lunarCalendar;

        public LunarCalendarShower(int solarYear, int solarMonth, int[] solarDayArray, int elaspedDays)
        {
            this.solarYear = solarYear;
            this.solarMonth = solarMonth;
            this.solarDayArray = solarDayArray;
            this.elaspedDays = elaspedDays;

            monthTableMaker = new MonthTableMaker();
            this.monthTable = monthTableMaker.getMonthTable(solarYear);
        }

        public void makeTheLunarCalendar()
        {
            calculateTheLunarCalendar(solarYear);
        }

        private void calculateTheLunarCalendar(int solarYear)
        {
            lunarCalculatorFactory = new LunarCalculatorFactory();
            lunarCalculable = lunarCalculatorFactory.getInstance(solarYear);

            int index = 0;
            lunarCalendar = new String[monthTable[solarMonth]];

            for (int i = 0; i < monthTable[solarMonth]; i++)
            {
                this.lunarData = lunarCalculable.getLunarCalendarString(solarYear, solarMonth, solarDayArray[i]);
                lunarCalendar[index] = lunarData;
                index++;
            }
        }

        public String[] getLunarCalendar() { return lunarCalendar; }
    }
}