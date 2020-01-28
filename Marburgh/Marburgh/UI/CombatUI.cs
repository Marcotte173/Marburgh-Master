using System;
using System.Collections.Generic;
using System.Text;

internal class CombatUI
{
    public static List<string> option = new List<string> {"Attack" , "Defend"};
    public static List<string> button = new List<string> {Colour.ABILITY +  "1"     + Colour.RESET, Colour.ABILITY + "2"      + Colour.RESET };

    internal static void Declare()
    {
        Console.Clear();
        Monster1();
        if (Combat.monsters.Count > 1) Monster2();
        if (Combat.monsters.Count > 2) Monster3();
        Box();
        AttackOptions();
        Console.ReadLine();
    }

    private static void Monster1()
    {
        int x = (Combat.monsters.Count == 2) ? 35 : 60; 
        Monster a = Combat.monsters[0];
        Write.Position(x - a.Name.Length/2, 3);
        Console.WriteLine(Colour.MONSTER + a.Name + Colour.RESET);
        Write.Position(x-1, 5);
        Console.WriteLine(Colour.HEALTH + a.Health + Colour.RESET);
        Write.Position(x - a.Name.Length / 2, 7);
        Console.WriteLine(Colour.ABILITY + a.Intention + Colour.RESET);
    }

    private static void Monster2()
    {
        Monster b = Combat.monsters[1];
        Write.Position(90 - b.Name.Length / 2, 3);
        Console.WriteLine(Colour.MONSTER + b.Name + Colour.RESET);
        Write.Position(89, 5);
        Console.WriteLine(Colour.HEALTH + b.Health + Colour.RESET);
        Write.Position(90 - b.Name.Length / 2, 7);
        Console.WriteLine(Colour.ABILITY + b.Intention + Colour.RESET);
    }

    private static void Monster3()
    {
        Monster b = Combat.monsters[2];
        Write.Position(35 - b.Name.Length / 2, 3);
        Console.WriteLine(Colour.MONSTER + b.Name + Colour.RESET);
        Write.Position(34, 5);
        Console.WriteLine(Colour.HEALTH + b.Health + Colour.RESET);
        Write.Position(35 - b.Name.Length / 2, 7);
        Console.WriteLine(Colour.ABILITY + b.Intention + Colour.RESET);
    }

    private static void AttackOptions()
    {
        UIComponent.OptionsText(option, button);
    }

    private static void Box()
    {
        Console.SetCursorPosition(0, 15);
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("|                       |                       |                       |                       |                      |");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("|xxxxxxxxxxxxxxxxx|                                                                                  |xxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxx   "+Colour.SPEAK + "Health"+Colour.RESET+"  xxx|                                                                                  |xxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxx       xxxxx|                                                                                  |xxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxx|                                                                                  |x  " + Colour.SPEAK + "Potion Size" + Colour.RESET + "  x|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxx|                                                                                  |xxx           xxx|");
        Console.WriteLine("|xxx   " + Colour.SPEAK + "Energy" + Colour.RESET + "  xxx|                                                                                  |xxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxxx      xxxxx|                                                                                  |xxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxx|                                                                                  |xxxxxxxxxxxxxxxxx|");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("|                                                                                                                      |");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Write.Position(7, 20);
        Console.WriteLine(Colour.HEALTH + Create.p.Health + Colour.RESET + "/" + Colour.HEALTH + Create.p.MaxHealth + Colour.RESET);
        Write.Position(108, 22);
        Console.WriteLine(Colour.HEALTH + Create.p.PotionSize + Colour.RESET + "/" + Colour.HEALTH + Create.p.MaxPotionSize + Colour.RESET);
        Write.Position(9, 24);
        Console.WriteLine(Colour.ENERGY + Create.p.Energy + Colour.RESET + "/" + Colour.ENERGY + Create.p.MaxEnergy + Colour.RESET);
        Console.SetCursorPosition(Return.Width(10) - Create.p.Name.Length / 2, 16);
        Console.WriteLine(Colour.NAME + $"{Create.p.Name}" + Colour.RESET);
        Console.SetCursorPosition(Return.Width(28), 16);
        Console.WriteLine("Level:" + Colour.XP + $"{Create.p.Level}" + Colour.RESET);
        Console.SetCursorPosition(Return.Width(47), 16);
        Console.WriteLine("Gold:" + Colour.GOLD + $"{Create.p.Gold}" + Colour.RESET);
        Console.SetCursorPosition(Return.Width(67), 16);
        Console.WriteLine("[" + Colour.CLASS + "C" + Colour.RESET + "]haracter");
        Console.SetCursorPosition(Return.Width(88), 16);
        Console.WriteLine("[" + Colour.MITIGATION + "R" + Colour.RESET + "]un");
    }
}