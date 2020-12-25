using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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
        //Get intention and display to start, after that, do it at the end
        foreach (Monster m in Create.p.combatMonsters.ToList()) m.Declare();
        Console.Clear();
        CombatUI.Box();
        while (Create.p.combatMonsters.Count > 0)
        {            
            Create.p.ItemCheck();
            Create.p.AttackChoice();
            foreach (Monster m in Create.p.combatMonsters.ToList())
            {
                if (m.Bleed > 0)
                {
                    AddCombatText(Color.MONSTER + m.Name + Color.BLOOD + " bleeds " + Color.RESET + "for " + Color.DAMAGE + m.BleedDam + Color.RESET + " damage!");
                    m.TakeDamage(m.BleedDam);
                    m.Bleed--;                    
                }
                else
                {
                    if (m.Status.Contains("Bleeding")) m.Status.Remove("Bleeding");
                }
                if (m.Burning > 0)
                {
                    Combat.AddCombatText(Color.MONSTER + m.Name + Color.BURNING + " burns " + Color.RESET + "for " + Color.DAMAGE + m.BurnDam + Color.RESET + " damage!");
                    m.TakeDamage(m.BurnDam);
                    m.Burning--;                    
                }
                else
                {
                    if (m.Status.Contains("Burning")) m.Status.Remove("Stunned");
                }
                if (m.Stun > 0)
                {
                    m.CanAct = false;
                    m.Stun--;                    
                }
                else
                {
                    m.CanAct = true;
                    if (m.Status.Contains("Stunned")) m.Status.Remove("Stunned");
                }
                if (m.CanAct && Create.p.Health>0) m.MakeAttack();
                else if (!m.CanAct)AddCombatText($"The {Color.MONSTER + m.Name+Color.RESET} is "+Color.STUNNED+ "stunned "+Color.RESET+"and cannot act!");
            }
            foreach (Monster m in Create.p.combatMonsters.ToList()) m.Declare();
            foreach (Zombie z in outOfFight.ToList())
            {
                z.deadCount--;
                if (z.deadCount <= 0 && Create.p.combatMonsters.Count<3) z.Revive();
            }
            if(Create.p.combatMonsters.Count ==0)
            {
                Console.Clear();
                CombatUI.Box();
                for (int i = 0; i < Combat.combatText.Count; i++)
                {
                    Write.Line(0, 6 + i, Combat.combatText[i]);
                }
                Write.Line(46, 22, Color.DAMAGE + "Press any key to continue");
                Console.ReadKey(true);
                foreach (Zombie z in outOfFight)
                {
                    goldReward += z.Gold;
                    xpReward += z.XP;
                    z.Drop();
                }
            }
            if (Create.p.Health == 0)
            {
                Console.Clear();
                CombatUI.Box();
                int n = 6;
                for (int i = 0; i < Combat.combatText.Count; i++)
                {
                    Write.Line(0, n + i, Combat.combatText[i]);
                }
                if (Create.p.nonLethal) Combat.AddCombatText("You have been " + Color.BOSS + "defeated" + Color.RESET + " by the " + Color.MONSTER + Create.p.lastHit.Name + Color.RESET + "!");
                else Combat.AddCombatText("You have been " + Color.BOSS + "killed" + Color.RESET + " by the " + Color.MONSTER + Create.p.lastHit.Name + Color.RESET + "!");
                Console.Clear();
                CombatUI.Box();
                for (int i = 0; i < Combat.combatText.Count; i++)
                {
                    Write.Line(0, 6 + i, Combat.combatText[i]);
                }
                Write.Line(46, 22, Color.DAMAGE + "Press any key to continue");
                Console.ReadKey(true);
                Create.p.Death(Create.p.lastHit);
            }
            combatText.Clear();
        }        
        List<int> colours = new List<int> { };
        List<string> text = new List<string> { };
        int goldroll = Return.RandomInt(-2, 6);
        int xproll = Return.RandomInt(-1, 3);
        int gold =  goldReward + goldroll;
        int xp = (Create.p.tempXp > 0)?Convert.ToInt32((xpReward + xproll) * (1 + Create.p.tempXp)) :xpReward + xproll;
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
            Button.levelMasterButton.active = true;
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

    public static void AddCombatText(string text)
    {
        combatText.Add(text);
        Console.Clear();
        CombatUI.Box();
        CombatUI.AttackOptions();
        if (combatText.Count > 9)
        {
            combatText.RemoveAt(0);
            int n = 6;
            for (int i = 0; i < combatText.Count; i++)
            {
                Write.Line(0, n + i, combatText[i]);
            }
        }
        int x = 6;
        for (int i = 0; i < combatText.Count; i++)
        {
            Write.Line(0, x + i, combatText[i]);
        }
        Thread.Sleep(200);
    }
}