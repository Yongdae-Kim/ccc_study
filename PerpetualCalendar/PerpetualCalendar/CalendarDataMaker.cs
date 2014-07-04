using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _PerpetualCalendar
{
    class CalendarDataMaker
    {
        private Calculator calculator;
        private SolarCalendarShower solarCalendarShower;
        private LunarCalendarShower lunarCalendarShower;
        private 天干地支CalendarShower 天干地支calendarShower;

        private const String 干支_0001_01_01 = "기묘(己卯)";  //1년 1월 1일은 기묘

        private int startDayPosition, endDay, elapsedDay;
        private int[]  solarDayArray;
        private String[] lunarCalendar, 天支Array;

        public void makeTheCalendarData(int solarYear, int solarMonth)
        {
            calculator = new Calculator(solarYear, solarMonth);
            calculator.calculateTheStartDayPosition();
            calculator.calculateTheElapsedDay();

            this.startDayPosition = calculator.getStartDayPosition();
            this.endDay = calculator.getEndDay();
            this.elapsedDay = calculator.getElapsedDay();

            solarCalendarShower = new SolarCalendarShower(solarYear, solarMonth);
            solarCalendarShower.makeTheSolarCalendar();

            this.solarDayArray = solarCalendarShower.getSolarDayArray();

            lunarCalendarShower = new LunarCalendarShower(solarYear, solarMonth, solarDayArray, elapsedDay);
            lunarCalendarShower.makeTheLunarCalendar();

            this.lunarCalendar = lunarCalendarShower.getLunarCalendar();

            天干地支calendarShower = new 天干地支CalendarShower(solarYear, solarMonth, elapsedDay, 干支_0001_01_01);
            天干地支calendarShower.makeThe天干地支Calendar();

            this.天支Array = 天干地支calendarShower.get干支Array();
        }

        public int getStartDayPosition() { return startDayPosition; }
        public int getEndDay() { return endDay; }
        public int[] getSolarDayArray() { return solarDayArray; }
        public String[] getLunarCalendar() { return lunarCalendar; }
        public String[] get天支Array() { return 天支Array; }
    }
}
