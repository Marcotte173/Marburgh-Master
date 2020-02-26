using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Combat : Location
{
    public static bool desecrated;
    public static int xpReward;
    public static int goldReward;
    public static List<Drop> dropList = new List<Drop> { };
    
    internal static List<Monster> monsters = new List<Monster> {};
    public Combat()
    : base()
    {
        
    }

    public override void Menu()
    {
        while (monsters.Count > 0)
        {
            foreach (Monster m in monsters.ToList()) m.Declare();
            Create.p.AttackChoice();
            foreach (Monster m in monsters.ToList())
            {
                if (m.Stun > 0) m.CanAct = false;
                else m.CanAct = true;
                if (m.CanAct) m.MakeAttack();
                else Console.WriteLine("The monster is stunned and cannot act!");
            }
            Console.ReadKey(true);
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
        text.Add(Colour.GOLD);
        text.Add("You find ");
        text.Add($"{ gold} ");
        text.Add("gold");
        colours.Add(0);
        text.Add("");
        colours.Add(1);
        text.Add(Colour.XP);
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
            text.Add(Colour.XP);
            text.Add("");
            text.Add("YOU ARE ELIGIBLE FOR A LEVEL RAISE");
            text.Add("");
        }
        //Get the drops on the drop list
        for (int i = 0; i < dropList.Count; i++)
        {
            //If you already have it, increase the amount. Otherwise, add it to the list
            colours.Add(0);
            text.Add("");
            colours.Add(1);
            text.Add(Colour.dropColour[dropList[i].rare]);
            text.Add("You find a ");
            text.Add($"{dropList[i].name}");
            text.Add("");
            bool exists = false;
            for (int x = 0; x < Create.p.Drops.Count; x++)
            {
                if (Create.p.Drops[x] == dropList[i])
                {
                    Create.p.Drops[x].amount++;
                    exists = true;
                    break;
                }
            }
            if (exists == false) Create.p.Drops.Add(dropList[i]);
        }
        UI.Keypress(colours, text);
        dropList.Clear();
        Create.p.Burning = 0;
        Create.p.Bleed = 0;
        Create.p.Stun = 0;
    }
}