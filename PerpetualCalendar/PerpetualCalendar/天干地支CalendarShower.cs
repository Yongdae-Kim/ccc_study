using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _PerpetualCalendar
{
    class 天干地支CalendarShower
    {
        private MonthTableMaker monthTableMaker;

        private int solarYear, solarMonth,elapsedDay;
        private int[] monthTable;
        private String 干支_0001_01_01;
        private String[] 干支_60DB,干支Array;
        private const int Constant = 1;
 
        public 天干地支CalendarShower(int solarYear,int solarMonth, int elapsedDay, String 干支_0001_01_01 )
        {
            this.solarYear = solarYear;
            this.solarMonth = solarMonth;
            this.elapsedDay = elapsedDay;
            this.干支_0001_01_01 = 干支_0001_01_01;

            monthTableMaker = new MonthTableMaker();
            this.monthTable = monthTableMaker.getMonthTable(solarYear);

            this.set干支_60DB();
        }

        private void set干支_60DB()
        {
            干支_60DB = new String[] {"갑자(甲子)", "을축(乙丑)", "병인(丙寅)", "정묘(丁卯)", "무진(戊辰)",
                                    "기사(己巳)", "경오(庚午)", "신미(辛未)", "임신(壬申)", "계유(癸酉)", 
                                    "갑술(甲戌)", "을해(乙亥)", "병자(丙子)", "정축(丁丑)", "무인(戊寅)",
                                    "기묘(己卯)", "경진(庚辰)", "신사(辛巳)", "임오(壬午)", "계미(癸未)", 
                                    "갑신(甲申)", "을유(乙酉)", "병술(丙戌)", "정해(丁亥)", "무자(戊子)",
                                    "기축(己丑)", "경인(庚寅)", "신묘(辛卯)", "임진(壬辰)", "계사(癸巳)", 
                                    "갑오(甲午)", "을미(乙未)", "병신(丙申)", "정유(丁酉)", "무술(戊戌)",
                                    "기해(己亥)", "경자(庚子)", "신축(辛丑)", "임인(壬寅)", "계묘(癸卯)", 
                                    "갑진(甲辰)", "을사(乙巳)", "병오(丙午)"," 정미(丁未)"," 무신(戊申)",
                                    "기유(己酉)", "경술(庚戌)", "신해(辛亥)", "임자(壬子)", "계축(癸丑)", 
                                    "갑인(甲寅)", "을묘(乙卯)", "병진(丙辰)", "정사(丁巳)", "무오(戊午)",
                                    "기미(己未)", "경신(庚申)", "신유(辛酉)", "임술(壬戌)", "계해(癸亥)"};
        }

        public void makeThe天干地支Calendar()
        {
            int 干支Index;
            this.干支Array = new String[monthTable[solarMonth]];

            干支Index = this.calculateThe干支(干支_0001_01_01, elapsedDay);

            for (int j = 0; j < monthTable[solarMonth]; j++)
            {
                干支Array[j] = 干支_60DB[干支Index];
                干支Index = (干支Index + 1) % 60;
            }
        }

        private int calculateThe干支(String 干支_0001_01_01, int elapsedDay)
        {
            int i;

            for (i = 0; i < 60; i++)
                if (干支_0001_01_01.Equals(干支_60DB[i])) break;

            if (i < 60)
                elapsedDay = (elapsedDay + i) % 60;

            return elapsedDay;
        }

        public String[] get干支Array() { return 干支Array; }
    }
}
