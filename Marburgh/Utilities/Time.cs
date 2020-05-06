using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Time
{
    public static int day = 1;
    public static int week = 1;
    public static int month = 1;
    public static int year = 345;
    public static string[] weeks = new string[] { "none", "first", "second" };
    public static string[] months = new string[] { "none", "Janbruarch", "ApmaJune", "Jaugtempber", "Octvemdec" };

    public static List<TimeEvent> Events = new List<TimeEvent>
    {
        new TimeEvent(1,3,1,345, false, true, true, new List<int> { 1 ,1 },
            new List<string>
            {
                Colour.BOSS, "","Time has run out.","",
                Colour.BOSS, "","The Savage orc's forces have overrun your town.",""
            })
    };

    public static void DayChange(int amount)
    {
        day += amount;
        Create.p.Refresh();
        Bank.bankRate = Bank.RateCalculate();
        if (Bank.term == 0 && Bank.investment > 0) Bank.InvestPay();
        else if(Bank.term > 0)
        {
            Bank.InvestmentCalculate();
            Bank.term--;
        }         
        PassingOfTime();
    }

    public static void PassingOfTime()
    {
        int addweek = 0;
        int addmonth = 0;
        int addyear = 0;
        while (day > 5)
        {
            day -= 5;
            addweek++;
        }
        week += addweek;
        while (week > 2)
        {
            week -= 2;
            addmonth++;
        }
        month += addmonth;
        while (month > 4)
        {
            month -= 4;
            addyear++;
        }
        year += addyear;
        DayCheck();
    }
    private static void DayCheck()
    {
        for (int i = 0; i < Events.Count; i++)
        {
            Events[i].trigger = false;
        }
        for (int i = 0; i < Events.Count; i++)
        {
            if (Events[i].day == day && Events[i].week == week && Events[i].month == month && Events[i].year == year)
            {
                Events[i].trigger = true;
                if (Events[i].active && Events[i].trigger)
                {
                    Console.Clear();
                    UI.KeypressNEW(Events[i].colourArray, Events[i].descriptions);
                    if (Events[i].gameOver) Utilities.Quit();
                }
            }
        }
    }
}