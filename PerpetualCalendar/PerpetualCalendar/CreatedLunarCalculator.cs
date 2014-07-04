using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _PerpetualCalendar
{
    class CreatedLunarCalculator : LunarCalculable
    {
        private MonthTableMaker monthTableMaker;

        private readonly int standardYear, standardMonth, standardDay;
        private int lunarYear, lunarMonth, lunarDay; 
        private String lunarCalendarString;
        private int[] monthTable, specificDayOfTheLunar, generalDayOfTheLeap;
        private int[,] lunarCalendarDB;
       
      
        public CreatedLunarCalculator(MonthTableMaker monthTableMaker)
        {
            this.monthTableMaker = monthTableMaker;
            this.setLunarCalendarDB();
            specificDayOfTheLunar = new int[]{ 29, 30, 58, 59, 59, 60 };
            generalDayOfTheLeap = new int[] { 0, 0, 29, 29, 30, 30 };
            standardYear = 1970;
            standardMonth = 2;
            standardDay = 6;
            // 1970년 2월 6일 1월 1일로 시작함
        }

        /// <summary>
        /// 음력 달의 특징<br/>
        /// 1: 평달 (작은달)<br/>
        /// 2: 평달 (큰달)<br/>
        /// 3: 윤달 (작은달 + 작은달)<br/>
        /// 4: 윤달 (작은달 + 큰달)<br/>
        /// 5: 윤달 (큰달 + 작은달)<br/>
        /// 6: 윤달 (큰달 + 큰달)<br/>
        /// 작은달=29, 큰달=30<br/>
        /// 
        public void setLunarCalendarDB()
        {
            lunarCalendarDB = new int[,]{ 
            {2,1,1,2,2,1,2,1,2,2,1,2}, // 1970 
            {1,2,1,1,5,2,1,2,2,2,1,2}, // 1971 
            {1,2,1,1,2,1,2,1,2,2,2,1}, // 1972 
            {2,1,2,1,1,2,1,1,2,2,2,1}, // 1973 
            {2,2,1,5,1,2,1,1,2,2,1,2}, // 1974 
            {2,2,1,2,1,1,2,1,1,2,1,2}, // 1975 
            {2,2,1,2,1,2,1,5,2,1,1,2}, // 1976 
            {2,1,2,2,1,2,1,2,1,2,1,1}, // 1977 
            {2,2,1,2,1,2,2,1,2,1,2,1}, // 1978 
            {2,1,1,2,1,6,1,2,2,1,2,1}, // 1979 
            {2,1,1,2,1,2,1,2,2,1,2,2}, // 1980 
            {1,2,1,1,2,1,1,2,2,1,2,2}, // 1981 
            {2,1,2,3,2,1,1,2,2,1,2,2}, // 1982 
            {2,1,2,1,1,2,1,1,2,1,2,2}, // 1983 
            {2,1,2,2,1,1,2,1,1,5,2,2}, // 1984 
            {1,2,2,1,2,1,2,1,1,2,1,2}, // 1985 
            {1,2,2,1,2,2,1,2,1,2,1,1}, // 1986 
            {2,1,2,2,1,5,2,2,1,2,1,2}, // 1987 
            {1,1,2,1,2,1,2,2,1,2,2,1}, // 1988 
            {2,1,1,2,1,2,1,2,2,1,2,2}, // 1989 
            {1,2,1,1,5,1,2,2,1,2,2,2}, // 1990 
            {1,2,1,1,2,1,1,2,1,2,2,2}, // 1991 
            {1,2,2,1,1,2,1,1,2,1,2,2}, // 1992 
            {1,2,5,2,1,2,1,1,2,1,2,1}, // 1993 
            {2,2,2,1,2,1,2,1,1,2,1,2}, // 1994 
            {1,2,2,1,2,2,1,5,2,1,1,2}, // 1995 
            {1,2,1,2,2,1,2,1,2,2,1,2}, // 1996 
            {1,1,2,1,2,1,2,2,1,2,2,1}, // 1997 
            {2,1,1,2,3,2,2,1,2,2,2,1}, // 1998 
            {2,1,1,2,1,1,2,1,2,2,2,1}, // 1999 
            {2,2,1,1,2,1,1,2,1,2,2,1}, // 2000 
            {2,2,2,3,2,1,1,2,1,2,1,2}, // 2001 
            {2,2,1,2,1,2,1,1,2,1,2,1}, // 2002 
            {2,2,1,2,2,1,2,1,1,2,1,2}, // 2003 
            {1,5,2,2,1,2,1,2,1,2,1,2}, // 2004 
            {1,2,1,2,1,2,2,1,2,2,1,1}, // 2005 
            {2,1,2,1,2,1,5,2,2,1,2,2}, // 2006 
            {1,1,2,1,1,2,1,2,2,2,1,2}, // 2007 
            {2,1,1,2,1,1,2,1,2,2,1,2}, // 2008 
            {2,2,1,1,5,1,2,1,2,1,2,2}, // 2009 
            {2,1,2,1,2,1,1,2,1,2,1,2}, // 2010 
            {2,1,2,2,1,2,1,1,2,1,2,1}, // 2011 
            {2,1,6,2,1,2,1,1,2,1,2,1}, // 2012 
            {2,1,2,2,1,2,1,2,1,2,1,2}, // 2013 
            {1,2,1,2,1,2,1,2,5,2,1,2}, // 2014 
            {1,2,1,1,2,1,2,2,2,1,2,1}, // 2015 
            {2,1,2,1,1,2,1,2,2,1,2,2}, // 2016 
            {1,2,1,2,3,2,1,2,1,2,2,2}, // 2017 
            {1,2,1,2,1,1,2,1,2,1,2,2}, // 2018 
            {2,1,2,1,2,1,1,2,1,2,1,2}, // 2019 
            {2,1,2,5,2,1,1,2,1,2,1,2}, // 2020 
            {1,2,2,1,2,1,2,1,2,1,2,1}, // 2021 
        };
        }

        private int getElapsedDaySince1970(int solarYear, int solarMonth, int solarDay)
        {
            this.monthTable = monthTableMaker.getMonthTable(solarYear);
            int elapsedDay = 0;
            int i;

            for (i = standardYear; i < solarYear; i++)
                elapsedDay = elapsedDay + monthTableMaker.getDayOfTheYear(i);

            for (i = 1; i < solarMonth; i++)
                elapsedDay = elapsedDay + monthTable[i];
            
            elapsedDay = elapsedDay + solarDay;

            for (i = 1; i < standardMonth; i++)
                elapsedDay = elapsedDay - monthTable[i];
            
            elapsedDay = elapsedDay - standardDay;

            return elapsedDay;
        }


        public String getLunarCalendarString(int solarYear, int solarMonth, int solarDay)
        {
            int elapsedDaySince1971 = this.getElapsedDaySince1970(solarYear, solarMonth, solarDay);
            int generalLunarDay = 0;
            lunarYear = 0;
            lunarMonth = 0;
            lunarDay = 0;

            for (int y = 0; y < lunarCalendarDB.GetLength(0); y++)
            {
                for (int m = 0; m < 12; m++)
                {
                    int specificLunarDay = specificDayOfTheLunar[lunarCalendarDB[y, m] - 1];

                    if (generalLunarDay + specificLunarDay > elapsedDaySince1971)
                    {
                        lunarYear = y + standardYear;
                        lunarMonth = m + 1;
                        lunarDay = elapsedDaySince1971 - generalLunarDay + 1;

                        if (lunarDay > generalDayOfTheLeap[lunarCalendarDB[y, m] - 1])
                            lunarDay = lunarDay - generalDayOfTheLeap[lunarCalendarDB[y, m] - 1];

                        lunarCalendarString = this.getFormattedString(lunarYear, lunarMonth, lunarDay);
                        return lunarCalendarString;
                    }
                    generalLunarDay = generalLunarDay + specificLunarDay;
                }
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
