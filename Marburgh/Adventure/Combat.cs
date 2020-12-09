using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Combat
{
    public static bool desecrated;
    public static int xpReward;
    public static int goldReward;
    public static List<Zombie> outOfFight = new List<Zombie> { };
    public static List<string> combatText = new List<string>  { };
    
    public static void Menu()
    {        
        goldReward = 0;
        xpReward = 0;
        combatText.Clear();
        outOfFight.Clear();
        GameState.location = Location.Combat;
        if (Create.p == Create.m) CombatUI.option[1] = Color.SHIELD + "Shield" + Color.RESET;
        else CombatUI.option[1] = Color.DEFENCE + "Defend" + Color.RESET;
        //Get intention and display to start, after that, do it at the end
        foreach (Monster m in Create.p.combatMonsters.ToList()) m.Declare();
        DisplayCombatText();
        while (Create.p.combatMonsters.Count > 0)
        {
            ItemCheck();
            Create.p.AttackChoice();
            foreach (Monster m in Create.p.combatMonsters.ToList())
            {
                if (m.Stun > 0) m.CanAct = false;
                else m.CanAct = true;
                if (m.CanAct) m.MakeAttack();
                else combatText.Add($"The {Color.MONSTER + m.Name+Color.RESET} is "+Color.STUNNED+ "stunned "+Color.RESET+"and cannot act!");
            }
            foreach (Monster m in Create.p.combatMonsters.ToList()) m.Declare();
            foreach (Zombie z in outOfFight.ToList())
            {
                z.deadCount--;
                if (z.deadCount <= 0) z.Revive();
            }
            DisplayCombatText();
            if(Create.p.combatMonsters.Count ==0)
            {
                Console.WriteLine("\n\nPress any Key to continue");
                Console.ReadKey(true);
                foreach(Zombie z in outOfFight)
                {
                    goldReward += z.Gold;
                    xpReward += z.XP;
                    z.Drop();
                }
            }
        }
        
        List<int> colours = new List<int> { };
        List<string> text = new List<string> { };
        int goldroll = Return.RandomInt(-2, 6);
        int xproll = Return.RandomInt(-1, 3);
        int gold =  goldReward + goldroll;
        int xp =  xpReward + xproll;
        colours.Add(0);
        text.Add("You have defeated your enemies");
        colours.Add(0);
        text.Add("");
        colours.Add(1);
        text.Add(Color.GOLD);
        text.Add("You find ");
        text.Add($"{ gold} ");
        text.Add("gold");
        colours.Add(0);
        text.Add("");
        colours.Add(1);
        text.Add(Color.XP);
        text.Add("You gain ");
        text.Add($"{ xp} ");
        text.Add("experience");
        Create.p.Gold += gold;
        Create.p.XP += xp;
        if (Create.p.XP >= Create.p.XPNeeded[Create.p.Level])
        {
            colours.Add(0);
            text.Add("");
            colours.Add(1);
            text.Add(Color.XP);
            text.Add("");
            text.Add("YOU ARE ELIGIBLE FOR A LEVEL RAISE");
            text.Add("");
        }
        //Get the drops on the drop list
        foreach(Drop d in Create.p.combatDropList)
        {
            colours.Add(0);
            text.Add("");
            colours.Add(1);
            text.Add(Color.dropColour[d.rare]);
            text.Add("You find a ");
            text.Add($"{d.name}");
            text.Add("");
            Create.p.AddDrop(d);
        }
        UI.Keypress(colours, text);
        Create.p.combatDropList.Clear();
        Create.p.Burning = 0;
        Create.p.Bleed = 0;
        Create.p.Stun = 0;
    }

    private static void ItemCheck()
    {
        Create.p.HaveItems = false ;
        foreach (string s in CombatUI.option.ToList()) if (s == Color.POTION + "Items" + Color.RESET) CombatUI.option.Remove(s);
        foreach (string s in CombatUI.button.ToList()) if (s == Color.POTION + "6" + Color.RESET)     CombatUI.button.Remove(s);
        foreach(Drop d in Create.p.Drops) if (d.rare == 2)
            {
                Create.p.HaveItems = true;
                CombatUI.option.Add(Color.POTION + "Items" + Color.RESET);
                CombatUI.button.Add("6");
                break;
            }
    }

    public static void DisplayCombatText()
    {
        Console.Clear();
        CombatUI.Box();
        Write.Position(0, 6);          
        int n = 6;
        for (int i = 0; i < combatText.Count; i++)
        {
            Write.Line(0, n + i, combatText[i]);
        }
        combatText.Clear();
    }
}