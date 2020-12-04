using System;
using System.Collections.Generic;
using System.Text;

public class Return
{
    static Random rand = new Random();
    internal static string String()
    {
        return Console.ReadLine();
    }

    public static int MitigatedDamage(int damage, int mitigation) => (damage - mitigation <= 0) ? 0 : damage - mitigation;
    internal static int Integer()
    {
        int sellChoice;
        do
        {

        } while (!int.TryParse(Console.ReadLine(), out sellChoice));
        return sellChoice;
    }

    internal static int RandomInt(int min, int max)
    {
        return rand.Next(min, max);
    }

    internal static int Int()
    {        
        int sellChoice;
        do
        {

        } while (!int.TryParse(Console.ReadKey(true).KeyChar.ToString().ToLower(), out sellChoice));
        return sellChoice;
    }

    internal static string Option()
    {
        return Console.ReadKey(true).KeyChar.ToString().ToLower();
    }

    internal static int Height(double x)
    {
        double percent = (50 - x) / 50;
        double newdouble = percent * Convert.ToDouble(Console.WindowHeight);
        int newint = Convert.ToInt32(newdouble);
        return Console.WindowHeight - newint;
    }

    internal static int Width(double x)
    {
        double percent = (100 - x) / 100;
        double newdouble = percent * Convert.ToDouble(Console.WindowWidth);
        int newint = Convert.ToInt32(newdouble);
        return Console.WindowWidth - newint;
    }
    internal static int CurrentX()
    {
        return Console.CursorLeft;
    }
    internal static int CurrentY()
    {
        return Console.CursorTop;
    }    

    internal static int MaxWidth()
    {
        return Console.WindowWidth - 1;
    }

    internal static bool HaveGold(int price)
    {
        return (Create.p.Gold >= price);
    }
    internal static bool HaveEnergy(int energyCost)
    {
        return (Create.p.Energy >= energyCost);
    }
}