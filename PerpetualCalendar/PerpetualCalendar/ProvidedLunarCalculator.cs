using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace _PerpetualCalendar
{
    class ProvidedLunarCalculator : LunarCalculable
    {
        private KoreanLunisolarCalendar koreanLunisolarCalendar; //음력 달력 프레임워크
        private DateTime dateTime;
        private MonthTableMaker monthTableMaker;

        private int lunarYear, lunarMonth, lunarDay;
        private int[] monthTable;

        public ProvidedLunarCalculator(MonthTableMaker monthTableMaker)
        {
            this.monthTableMaker = monthTableMaker;
        }

        public String getLunarCalendarString(int solarYear, int solarMonth, int solarDay)
        {
            koreanLunisolarCalendar = new KoreanLunisolarCalendar(); // C#에서 제공되는 프레임워크
            this.monthTable = monthTableMaker.getMonthTable(solarYear);

            int leapMonth;
            String lunarCalendarString;

            dateTime = new DateTime(solarYear, solarMonth, solarDay, 0, 0, 0);

            lunarYear = koreanLunisolarCalendar.GetYear(dateTime);
            lunarMonth = koreanLunisolarCalendar.GetMonth(dateTime);
            lunarDay = koreanLunisolarCalendar.GetDayOfMonth(dateTime);

            if (koreanLunisolarCalendar.GetMonthsInYear(lunarYear) > 12) //1년이 12이상이면 윤달이 있음..
            {
                leapMonth = koreanLunisolarCalendar.GetLeapMonth(lunarYear);
                //년도의 윤달이 몇월인지?
                if (lunarMonth >= leapMonth)
                    lunarMonth--;
            }
            lunarCalendarString = this.getFormattedString(lunarYear, lunarMonth, lunarDay);
            return lunarCalendarString;
        }

        private String getFormattedString(int lunarYear, int lunarMonth, int lunarDay)
        {
            String formattedString;

            if (lunarMonth == 1 && lunarDay == 1)
                formattedString = lunarYear + "/" + lunarMonth + "/" + lunarDay;
            else
                formattedString = lunarMonth + "/" + lunarDay;
            return formattedString;
        }
    }
}
