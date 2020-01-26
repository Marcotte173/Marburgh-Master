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
    }    
}