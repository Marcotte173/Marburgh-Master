using System;
using System.Collections.Generic;
using System.Text;

internal class CombatUI
{
    public static List<string> stunOption = new List<string> { Color.STUNNED + " You are stunned. Press Any Key to continue" + Color.RESET };
    public static List<string> stunButton = new List<string> { "X" };
    public static List<string> targetOption = new List<string> {  };
    public static List<string> targetButton = new List<string> {  };

    internal static void Stunned()
    {
        Box();
        Write.Line(50, 20,"You are " + Color.STUNNED + "stunned"+ Color.RESET);
        Console.ReadKey(true);
    }

    private static void Monster(Monster mon)
    {
        int x = 0;
        if (mon == Create.p.combatMonsters[0])
        {
            if (Create.p.combatMonsters.Count == 1) x = 59 - mon.Name.Length / 2;
            else if (Create.p.combatMonsters.Count == 2) x = 39 - mon.Name.Length / 2;
            else if (Create.p.combatMonsters.Count == 3) x = 29 - mon.Name.Length / 2;
            else if (Create.p.combatMonsters.Count == 4) x = 23 - mon.Name.Length / 2;
            else if (Create.p.combatMonsters.Count == 5) x = 19 - mon.Name.Length / 2;
            else if (Create.p.combatMonsters.Count == 6) x = 10 - mon.Name.Length / 2;
        }
        else if (mon == Create.p.combatMonsters[1])
        {
            if (Create.p.combatMonsters.Count == 2) x = 79 - mon.Name.Length / 2;
            else if (Create.p.combatMonsters.Count == 3) x = 59 - mon.Name.Length / 2;
            else if (Create.p.combatMonsters.Count == 4) x = 47 - mon.Name.Length / 2;
            else if (Create.p.combatMonsters.Count == 5) x = 39 - mon.Name.Length / 2;
            else if (Create.p.combatMonsters.Count == 6) x = 30 - mon.Name.Length / 2;
        }
        else if (mon == Create.p.combatMonsters[2])
        {
            if (Create.p.combatMonsters.Count == 3) x = 89 - mon.Name.Length / 2;
            else if (Create.p.combatMonsters.Count == 4) x = 71 - mon.Name.Length / 2;
            else if (Create.p.combatMonsters.Count == 5) x = 59 - mon.Name.Length / 2;
            else if (Create.p.combatMonsters.Count == 6) x = 51 - mon.Name.Length / 2;
        }
        else if (mon == Create.p.combatMonsters[3])
        {
            if (Create.p.combatMonsters.Count == 4) x = 95 - mon.Name.Length / 2;
            else if (Create.p.combatMonsters.Count == 5) x = 79 - mon.Name.Length / 2;
            else if (Create.p.combatMonsters.Count == 6) x = 70 - mon.Name.Length / 2;
        }
        else if (mon == Create.p.combatMonsters[4])
        {
            if (Create.p.combatMonsters.Count == 5) x = 99 - mon.Name.Length / 2;
            else if (Create.p.combatMonsters.Count == 6) x = 90 - mon.Name.Length / 2;
        }
        else if (mon == Create.p.combatMonsters[5])
        {
             x = 110 - mon.Name.Length / 2;
        }
        Write.Line(x, 0, Color.MONSTER + mon.Name + Color.RESET);
        Write.Line(x, 2, Color.HEALTH + mon.Health + Color.RESET);
        Write.Line(x, 1, Color.ABILITY + mon.Intention + Color.RESET);
        for (int i = 0; i < mon.Status.Count; i++)
        {
            Write.Position(x - mon.Name.Length / 2, 3+i);
            Console.WriteLine($"{mon.Status[i]} ");
        }
    }

    public static void AttackOptions()
    {
        if (Create.p.tutorial && Create.p.Health <= Create.p.MaxHealth / 2 && Create.p.PotionSize > 0)
        {
            Write.Line(35, 14, Color.HEALTH + "YOU ARE LOW ON HEALTH. HIT H TO USE YOUR POTION");
        }
        if (Create.p.combatMonsters.Count < 2) Button.cleaveButton.active = false;
        Utilities.Buttons(Button.listOfCombatOptions);        
        if (Create.p.CanAct) UIComponent.OptionsText(Button.list1, Button.button1,3);
        else UIComponent.OptionsText(stunOption, stunButton,3);
    }

    internal static Monster Target()
    {
        targetButton.Clear();
        targetOption.Clear();
        if (Create.p.combatMonsters.Count != 1)
        {
            targetOption.Add(Color.MONSTER + Create.p.combatMonsters[0].Name + Color.RESET);
            targetButton.Add("1");
            targetOption.Add(Color.MONSTER + Create.p.combatMonsters[1].Name + Color.RESET);
            targetButton.Add("2");
            if (Create.p.combatMonsters.Count >2)
            {
                targetOption.Add(Color.MONSTER+ Create.p.combatMonsters[2].Name + Color.RESET);
                targetButton.Add("3");
            }
            if (Create.p.combatMonsters.Count > 3)
            {
                targetOption.Add(Color.MONSTER + Create.p.combatMonsters[3].Name + Color.RESET);
                targetButton.Add("4");
            }
            if (Create.p.combatMonsters.Count > 4)
            {
                targetOption.Add(Color.MONSTER + Create.p.combatMonsters[4].Name + Color.RESET);
                targetButton.Add("5");
            }
            if (Create.p.combatMonsters.Count > 5)
            {
                targetOption.Add(Color.MONSTER + Create.p.combatMonsters[4].Name + Color.RESET);
                targetButton.Add("6");
            }
            Box();
            Write.Line(50, 10,"Please select a target");
            UIComponent.OptionsText(targetOption, targetButton,3);
            int choice = Return.Int();
            if (choice >= 0 && choice < 4)
            {
                Console.Clear();
                CombatUI.Box();
                if (choice == 1) return Create.p.combatMonsters[0];
                else if (choice == 2 && Create.p.combatMonsters.Count > 1) return Create.p.combatMonsters[1];
                else if (choice == 3 && Create.p.combatMonsters.Count == 3) return Create.p.combatMonsters[2];
                else if (choice == 3 && Create.p.combatMonsters.Count == 4) return Create.p.combatMonsters[3];
                else if (choice == 3 && Create.p.combatMonsters.Count == 5) return Create.p.combatMonsters[4];
                else if (choice == 0) return null;
                else Target();
            }
            else Target();
            return null;
        }
        else return Create.p.combatMonsters[0];
    }

    internal static void Box()
    {
        Console.Clear();
        if (Create.p.combatMonsters.Count > 0) Monster(Create.p.combatMonsters[0]);
        if (Create.p.combatMonsters.Count > 1) Monster(Create.p.combatMonsters[1]);
        if (Create.p.combatMonsters.Count > 2) Monster(Create.p.combatMonsters[2]);
        if (Create.p.combatMonsters.Count > 3) Monster(Create.p.combatMonsters[3]);
        if (Create.p.combatMonsters.Count > 4) Monster(Create.p.combatMonsters[4]);
        if (Create.p.combatMonsters.Count > 5) Monster(Create.p.combatMonsters[5]);
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
        foreach (string s in Create.p.Status) Console.Write(s+ " ");
        Write.Line( 0, 5, "------------------------------------------------------------------------------------------------------------------------");
    }
}