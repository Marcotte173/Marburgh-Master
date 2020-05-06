using System.Collections.Generic;
public class TimeEvent
{
    public bool gameOver;
    public int day;
    public int week;
    public int month;
    public int year;
    public bool active;
    public bool trigger;
    public List<int> colourArray;
    public List<string> descriptions;

    public TimeEvent( int day, int week, int month, int year, bool trigger, bool active, bool gameOver, List<int> colourArray, List<string> descriptions)
    {
        this.day = day;
        this.week = week;
        this.month = month;
        this.year = year;
        this.active = active;
        this.gameOver = gameOver;
        this.trigger = trigger;
        this.colourArray = colourArray;
        this.descriptions = descriptions;
    }
}