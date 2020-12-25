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

    internal static bool StatCheck(int stat, int numberTobeat) => RandomInt(0, stat) > numberTobeat;

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
    internal static void RewardEquipment(Equipment[] list, int level)
    {
        UI.Keypress(new List<int> { 1 }, new List<string>
        {
            Color.ITEM,"You a ", list[level].Name, ""
        });
        if (UI.Confirm(new List<int> { 1 }, new List<string>
        {
            Color.ITEM, "Would you like to equip the ", list[level].Name, "?",
        }))
        {
            Create.p.Equip(list[level]);
        }
    }

    internal static void RewardEquipment(int min, int max, int rep, Equipment[] list, int level)
    {
        int gold = RandomInt(min, max) * level;
        UI.Keypress(new List<int> {3}, new List<string>
        {
            Color.GOLD,Color.ITEM,Color.HIT,"You receive ", gold.ToString() ," gold, a ", list[level].Name," and your reputation is increased by ", rep.ToString() , ""
        });
        Create.p.Gold += gold;
        Create.p.RepAdd(rep);
        if (UI.Confirm(new List<int> { 1 }, new List<string>
        {
            Color.ITEM, "Would you like to equip the ", list[level].Name, "?",
        }))
        {
            Create.p.Equip(list[level]);
        }      
    }
    internal static void RewardPotion(int min, int max, int rep)
    {
        Drop potion = Shop.potionList[RandomInt(0, Shop.potionList.Count)];
        int gold = RandomInt(min, max) * Create.p.Level;
        UI.Keypress(new List<int> { 3 }, new List<string>
        {
            Color.GOLD,Color.POTION,Color.HIT,"You receive ", gold.ToString() ," gold, a ", potion.name," and your reputation is increased by ", rep.ToString() , ""
        });        
        Create.p.Gold += gold;
        Create.p.RepAdd(rep);
        Create.p.AddDrop(potion);
    }

    internal static void RewardPotion(int rep)
    {
        Drop potion = Shop.potionList[RandomInt(0, Shop.potionList.Count)];
        UI.Keypress(new List<int> { 3 }, new List<string>
        {
            Color.POTION,Color.HIT,"You receive a ", potion.name," and your reputation is increased by ", rep.ToString() , ""
        });
        Create.p.RepAdd(rep);
        Create.p.AddDrop(potion);
    }

    internal static void RewardPotion()
    {
        Drop potion = Shop.potionList[RandomInt(0, Shop.potionList.Count)];
        UI.Keypress(new List<int> { 1 }, new List<string>
        {
            Color.POTION,"You receive a ", potion.name, ""
        });
        Create.p.AddDrop(potion);
    }
    internal static void RewardGold(int min, int max, int rep)
    {
        int gold = RandomInt(min, max) * RandomInt(10, 20)*Create.p.Level;
        UI.Keypress(new List<int> {2 }, new List<string>
        {
            Color.GOLD,Color.HIT,"You receive ", gold.ToString() ," gold and your reputation is increased by ",rep.ToString(),""
        });
        Create.p.Gold += gold;
        Create.p.RepAdd(rep);
    }

    internal static bool RoomForPotions()
    {
        int pots=0;
        foreach(Drop p in Create.p.Drops)
        {
            if (p.rare == 2) pots++;
        }
        if (pots < 5) return true;
        return false;
    }
}