using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _PerpetualCalendar
{
    class LunarCalculatorFactory
    {
        private MonthTableMaker monthTableMaker;
     
        public LunarCalculatorFactory()
        {
            this.monthTableMaker = new MonthTableMaker();
        }

        public LunarCalculable getInstance(int solarYear)
        {
            if (solarYear >= 919 && solarYear < 1971 || solarYear > 2020 && solarYear <= 2050)
                return new ProvidedLunarCalculator(monthTableMaker);
            else if (solarYear >= 1971 && solarYear <= 2020)
                return new CreatedLunarCalculator(monthTableMaker);
            else
                return new NotingLunarCalculator();
        }
    }    
}
