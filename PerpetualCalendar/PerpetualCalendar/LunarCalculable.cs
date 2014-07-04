using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _PerpetualCalendar
{
    interface LunarCalculable
    {
        String getLunarCalendarString(int solarYear, int solarMonth, int solarDay);
    }
}
