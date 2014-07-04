using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _PerpetualCalendar
{
    public partial class CalendarForm : Form
    {
        private CalendarDataMaker calendarDataMaker;

        private readonly int todayYear = DateTime.Today.Year;
        private readonly int todayMonth = DateTime.Today.Month;

        private int solarYear, solarMonth, startDayPosition, endDay;
        private int[]  solarDayArray;
        private String[] lunarCalendar, 天支Array;

        public CalendarForm() { InitializeComponent(); }

        private void makeTheCalendar()
        {
            this.initializeTheCalendarForm(); // 달력 폼 초기화
            this.loadTheInuttedData();        // 입력한 년과 월을 받아옴
            this.setCalendarData();           // 달력에 필요한 데이타를 설정함
            this.showTheCalendar();           // 달력을 보여줌
        }

        private void setCalendarData()
        {
            calendarDataMaker = new CalendarDataMaker();
            calendarDataMaker.makeTheCalendarData(solarYear, solarMonth);

            this.startDayPosition = calendarDataMaker.getStartDayPosition();
            this.endDay = calendarDataMaker.getEndDay();
            this.solarDayArray = calendarDataMaker.getSolarDayArray();
            this.lunarCalendar = calendarDataMaker.getLunarCalendar();
            this.天支Array = calendarDataMaker.get天支Array();
        }

        private void initializeTheYearCB()
        {
            yearCB.Items.Clear();

            for (int i = 1971; i < 2021; i++)
                yearCB.Items.Add(i);
        }

        private void initializeTheMonthCB()
        {
            monthCB.Items.Clear();

            for (int i = 1; i < 13; i++)
                monthCB.Items.Add(i);
        }

        private void initializeTheCalendarForm()
        {
            for (int tbNum = 0; tbNum < 42; tbNum++)
            {
                Controls["solarTB" + tbNum].Text = "";
                Controls["干支L" + tbNum].Text = "";
                Controls["lunarL" + tbNum].Text = "";
            }
        }

        private void loadTheInuttedData()
        {
            solarYear = int.Parse(yearCB.Text);
            solarMonth = int.Parse(monthCB.Text);
        }

        private void setToday()
        {
            yearCB.SelectedText = todayYear.ToString();
            monthCB.SelectedText = todayMonth.ToString();

            yearCB.SelectedIndex = 42;
            monthCB.SelectedIndex = 10;
        }

        private void Calendar_Load(object sender, EventArgs e)
        {
            this.initializeTheYearCB();
            this.initializeTheMonthCB();
            this.setToday();
            this.makeTheCalendar();
        }

        private void yearCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.makeTheCalendar();  
        }

        private void monthCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.makeTheCalendar();  
        }

        private void selectBTN_Click(object sender, EventArgs e)
        {
            this.makeTheCalendar();
        }
   
        private void previousYear_Click(object sender, EventArgs e) { buttonActionEvent(yearCB, "previous"); }
        private void nextYear_Click(object sender, EventArgs e) { buttonActionEvent(yearCB, "next"); }
        private void previousMonth_Click(object sender, EventArgs e) { buttonActionEvent(monthCB, "previous"); }
        private void nextMonth_Click(object sender, EventArgs e) { buttonActionEvent(monthCB, "next"); }

        private void buttonActionEvent(ComboBox cb, String buttonName)
        {
            this.changeTheSelectedIndex(cb, buttonName);
        }

        private void changeTheSelectedIndex(ComboBox cb, String btnName)
        {
            if (btnName.Equals("previous") && cb.SelectedIndex > 0)
                cb.SelectedIndex = cb.SelectedIndex - 1;

            else if (btnName.Equals("next") && cb.SelectedIndex < cb.Items.Count - 1)
                cb.SelectedIndex = cb.SelectedIndex + 1;
        }

        private void showTheCalendar()
        {
            int index = 0;

            for (int tbNum = startDayPosition; tbNum < startDayPosition + endDay; tbNum++)
            {
                Controls["solarTB" + tbNum].Text = solarDayArray[index].ToString(); // 양력 달력 출력
                Controls["干支L" + tbNum].Text = 天支Array[index];                  // 음력 달력 출력
                Controls["lunarL" + tbNum].Text = lunarCalendar[index].ToString();  // 간지 달력 출력
                index++;
            }
        }
    }
}