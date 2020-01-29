using System;
using System.Collections.Generic;
using System.Text;

internal class CombatUI
{
    public static List<string> option = new List<string> {"Attack" , "Defend"};
    public static List<string> button = new List<string> {Colour.ABILITY +  "1"     + Colour.RESET, Colour.ABILITY + "2"      + Colour.RESET };
    public static List<string> targetOption = new List<string> {  };
    public static List<string> targetButton = new List<string> {  };


    internal static void Declare()
    {                
        Box();
        AttackOptions();        
    }

    private static void Monster1()
    {
        int x = (Combat.monsters.Count == 2) ? 35 : 60; 
        Monster a = Combat.monsters[0];
        Write.SetX(x - a.Name.Length/2);
        Console.WriteLine(Colour.MONSTER + a.Name + Colour.RESET);
        Write.Position(x-1, 2);
        Console.WriteLine(Colour.HEALTH + a.Health + Colour.RESET);
        Write.Position(x - a.Name.Length / 2, 1);
        Console.WriteLine(Colour.ABILITY + a.Intention + Colour.RESET);
        targetOption.Add(Combat.monsters[0].Name);
        targetButton.Add("1");
    }

    private static void Monster2()
    {
        Monster b = Combat.monsters[1];
        Write.Position(90 - b.Name.Length / 2, 0);
        Console.WriteLine(Colour.MONSTER + b.Name + Colour.RESET);
        Write.Position(89, 2);
        Console.WriteLine(Colour.HEALTH + b.Health + Colour.RESET);
        Write.Position(90 - b.Name.Length / 2, 1);
        Console.WriteLine(Colour.ABILITY + b.Intention + Colour.RESET);
        Write.Position(90 - b.Name.Length / 2, 4);
        Console.WriteLine(Colour.ABILITY + b.Intention + Colour.RESET);
        targetOption.Add(Combat.monsters[1].Name);
        targetButton.Add("2");
    }

    private static void Monster3()
    {
        Monster b = Combat.monsters[2];
        Write.Position(35 - b.Name.Length / 2, 0);
        Console.WriteLine(Colour.MONSTER + b.Name + Colour.RESET);
        Write.Position(34, 2);
        Console.WriteLine(Colour.HEALTH + b.Health + Colour.RESET);
        Write.Position(35 - b.Name.Length / 2, 1);
        Console.WriteLine(Colour.ABILITY + b.Intention + Colour.RESET);
        targetOption.Add(Combat.monsters[2].Name);
        targetButton.Add("3");
    }

    private static void AttackOptions()
    {
        UIComponent.OptionsText(option, button);
    }

    internal static Monster Target()
    {
        if (Combat.monsters.Count != 1)
        {
            Box();
            Write.Position(45, 20);
            Console.WriteLine("Please select a target");
            UIComponent.OptionsText(option, button);
            int choice = Return.Int();
            if (choice > 0 && choice < 4)
            {
                if (choice == 1) return Combat.monsters[0];
                else if (choice == 2 && Combat.monsters.Count > 1) return Combat.monsters[1];
                else if (choice == 3 && Combat.monsters.Count == 3) return Combat.monsters[2];
                else return null;
            }
            else return null;
        }
        else return Combat.monsters[0];
    }

    internal static void Box()
    {
        Console.Clear();
        Monster1();
        if (Combat.monsters.Count > 1) Monster2();
        if (Combat.monsters.Count > 2) Monster3();
        Write.SetY(5);
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
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