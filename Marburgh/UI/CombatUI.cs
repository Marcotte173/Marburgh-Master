using System;
using System.Collections.Generic;
using System.Text;

internal class CombatUI
{
    public static List<string> option = new List<string> { Color.DAMAGE + "Attack" + Color.RESET, Color.DEFENCE + "Defend" + Color.RESET };
    public static List<string> button = new List<string> { "1" , "2" };
    public static List<string> optionBasic = new List<string> { Color.DAMAGE + "Attack" + Color.RESET, Color.DEFENCE + "Defend" + Color.RESET };
    public static List<string> buttonBasic = new List<string> { "1", "2" };
    public static List<string> targetOption = new List<string> {  };
    public static List<string> targetButton = new List<string> {  };


    internal static void Declare()
    {                
        Box();
        AttackOptions();        
    }
    internal static void Stunned()
    {
        Box();
        Write.Position(45, 20);
        Console.WriteLine("You are stunned");
        Console.ReadKey(true);
    }

    private static void Monster1()
    {
        int x = (Create.p.combatMonsters.Count == 2) ? 35 : 60; 
        Monster a = Create.p.combatMonsters[0];
        Write.SetX(x - a.Name.Length/2);
        Console.WriteLine(Color.MONSTER + a.Name + Color.RESET);
        Write.Position(x-1, 2);
        Console.WriteLine(Color.HEALTH + a.Health + Color.RESET);
        Write.Position(x - a.Name.Length / 2, 1);
        Console.WriteLine(Color.ABILITY + a.Intention + Color.RESET);
        for (int i = 0; i < a.Status.Count; i++)
        {
            Write.Position(x - a.Name.Length / 2, 3+i);
            Console.WriteLine( a.Status[i]);
        }
    }

    private static void Monster2()
    {
        Monster b = Create.p.combatMonsters[1];
        Write.Position(90 - b.Name.Length / 2, 0);
        Console.WriteLine(Color.MONSTER + b.Name + Color.RESET);
        Write.Position(89, 2);
        Console.WriteLine(Color.HEALTH + b.Health + Color.RESET);
        Write.Position(90 - b.Name.Length / 2, 1);
        Console.WriteLine(Color.ABILITY + b.Intention + Color.RESET);
        for (int i = 0; i < b.Status.Count; i++)
        {
            Write.Position(90 - b.Name.Length / 2, 3 + i);
            Console.WriteLine(b.Status[i]);
        }
    }

    private static void Monster3()
    {
        Monster b = Create.p.combatMonsters[2];
        Write.Position(35 - b.Name.Length / 2, 0);
        Console.WriteLine(Color.MONSTER + b.Name + Color.RESET);
        Write.Position(34, 2);
        Console.WriteLine(Color.HEALTH + b.Health + Color.RESET);
        Write.Position(35 - b.Name.Length / 2, 1);
        Console.WriteLine(Color.ABILITY + b.Intention + Color.RESET);
        for (int i = 0; i < b.Status.Count; i++)
        {
            Write.Position(35 - b.Name.Length / 2, 3 + i);
            Console.WriteLine(b.Status[i]);
        }        
    }

    private static void AttackOptions()
    {
        UIComponent.OptionsText(option, button);
    }

    internal static Monster Target()
    {
        targetButton.Clear();
        targetOption.Clear();
        if (Create.p.combatMonsters.Count != 1)
        {
            targetOption.Add(Create.p.combatMonsters[0].Name);
            targetButton.Add("1");
            targetOption.Add(Create.p.combatMonsters[1].Name);
            targetButton.Add("2");
            if (Create.p.combatMonsters.Count == 3)
            {
                targetOption.Add(Create.p.combatMonsters[2].Name);
                targetButton.Add("3");
            }
            Box();
            Write.Position(45, 20);
            Console.WriteLine("Please select a target");
            UIComponent.OptionsText(targetOption, targetButton);
            int choice = Return.Int();
            if (choice > 0 && choice < 4)
            {                
                if (choice == 1) return Create.p.combatMonsters[0];
                else if (choice == 2 && Create.p.combatMonsters.Count > 1) return Create.p.combatMonsters[1];
                else if (choice == 3 && Create.p.combatMonsters.Count == 3) return Create.p.combatMonsters[2];
                else return null;
            }
            else return null;
        }
        else return Create.p.combatMonsters[0];
    }

    internal static void Box()
    {
        Console.Clear();
        Monster1();
        if (Create.p.combatMonsters.Count > 1) Monster2();
        if (Create.p.combatMonsters.Count > 2) Monster3();
        Write.SetY(5);
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.SetCursorPosition(0, 15);
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("|                       |                       |                       |                       |                      |");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("|xxxxxxxxxxxxxxxxx|                                                                                  |xxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxx   "+Color.SPEAK + "Health"+Color.RESET+"  xxx|                                                                                  |xxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxx       xxxxx|                                                                                  |xxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxx|                                                                                  |x  " + Color.SPEAK + "Potion Size" + Color.RESET + "  x|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxx|                                                                                  |xxx           xxx|");
        Console.WriteLine("|xxx   " + Color.SPEAK + "Energy" + Color.RESET + "  xxx|                                                                                  |xxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxxx      xxxxx|                                                                                  |xxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxx|                                                                                  |xxxxxxxxxxxxxxxxx|");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("|                                                                                                                      |");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Write.Position(7, 20);
        Console.WriteLine(Color.HEALTH + Create.p.Health + Color.RESET + "/" + Color.HEALTH + Create.p.MaxHealth + Color.RESET);
        Write.Position(108, 22);
        Console.WriteLine(Color.HEALTH + Create.p.PotionSize + Color.RESET + "/" + Color.HEALTH + Create.p.MaxPotionSize + Color.RESET);
        Write.Position(9, 24);
        Console.WriteLine(Color.ENERGY + Create.p.Energy + Color.RESET + "/" + Color.ENERGY + Create.p.MaxEnergy + Color.RESET);
        Console.SetCursorPosition(Return.Width(10) - Create.p.Name.Length / 2, 16);
        Console.WriteLine(Color.NAME + $"{Create.p.Name}" + Color.RESET);
        Console.SetCursorPosition(Return.Width(28), 16);
        Console.WriteLine("Level:" + Color.XP + $"{Create.p.Level}" + Color.RESET);
        Console.SetCursorPosition(Return.Width(47), 16);
        Console.WriteLine("["+Color.HEALTH + "H" + Color.RESET+"]eal");
        Console.SetCursorPosition(Return.Width(67), 16);
        Console.WriteLine("[" + Color.CLASS + "9" + Color.RESET + "]Character");
        Console.SetCursorPosition(Return.Width(88), 16);
        Console.WriteLine("[" + Color.MITIGATION + "0" + Color.RESET + "]Run");
        Console.SetCursorPosition(20, 27);
        foreach (string s in Create.p.Status) Console.Write(s);
    }
}