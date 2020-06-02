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
    public static List<string> combatText = new List<string>  { };
    
    public static void Menu()
    {
        combatText.Clear();
        GameState.location = Location.Combat;
        while (Create.p.combatMonsters.Count > 0)
        {
            foreach (Monster m in Create.p.combatMonsters.ToList()) m.Declare();
            DisplayCombatText();            
            Create.p.AttackChoice();
            foreach (Monster m in Create.p.combatMonsters.ToList())
            {
                if (m.Stun > 0) m.CanAct = false;
                else m.CanAct = true;
                if (m.CanAct) m.MakeAttack();
                else Console.WriteLine("The monster is stunned and cannot act!");
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
        for (int i = 0; i < Create.p.combatDropList.Count; i++)
        {
            //If you already have it, increase the amount. Otherwise, add it to the list
            colours.Add(0);
            text.Add("");
            colours.Add(1);
            text.Add(Color.dropColour[Create.p.combatDropList[i].rare]);
            text.Add("You find a ");
            text.Add($"{Create.p.combatDropList[i].name}");
            text.Add("");
            bool exists = false;
            for (int x = 0; x < Create.p.Drops.Count; x++)
            {
                if (Create.p.Drops[x] == Create.p.combatDropList[i])
                {
                    Create.p.Drops[x].amount++;
                    exists = true;
                    break;
                }
            }
            if (exists == false) Create.p.Drops.Add(Create.p.combatDropList[i]);
        }
        UI.Keypress(colours, text);
        Create.p.combatDropList.Clear();
        Create.p.Burning = 0;
        Create.p.Bleed = 0;
        Create.p.Stun = 0;
    }
    public static void DisplayCombatText()
    {
        Console.Clear();
        CombatUI.Box();
        Write.Position(0, 6);
        if (Create.p.Stun > 0)
        {
            Create.p.CanAct = false;
            Create.p.Stun--;
            if (Create.p.Stun <= 0 && Create.p.Status.Contains("Stunned")) Create.p.Status.Remove("Stunned");
            combatText.Add(Color.NAME + "You " + Color.RESET + "are " + Color.STUNNED + "stunned" + Color.RESET + "!\n");
        }
        if (Create.p.CanAct) CombatUI.AttackOptions();
        else CombatUI.Stunned();        
        int n = 6;
        for (int i = 0; i < combatText.Count; i++)
        {
            Write.Line(0, n + i, combatText[i]);
        }
        combatText.Clear();
    }
}