using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Create
{
    internal static Warrior w = new Warrior();
    internal static Mage m = new Mage();
    internal static Rogue r = new Rogue();
    internal static Player p;

    public static void Story()
    {
        Console.Clear();
        Write.SetY(15);
        UIComponent.BarBlank();
        UIComponent.StandardMiddle(8);
        UIComponent.BarBlank();
        Write.Position(47, 22);
        Write.Line(Color.ENERGY, "Press any key to continue");
        UIComponent.DisplayText(new List<int> { 1, 0, 3, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0 }, new List<string>
            {
               Color.CLASS,"You come from a long line of ","adventurers","",
               "",
               Color.NAME, Color.CLASS, Color.MONSTER, "Your ","mother",", an ","adventurer ","herself, was murdered by ","Orcs",", as they ransacked your town",
               "",
               "Many villagers died, and even more were captured. ",
               "",
               "Until they are free, your town is but a shadow of its old self",
               "",
               Color.BOSS, "Worse yet, the ","Savage Orc ","that leads them is getting stronger and building an army",
               "",
               Color.TIME, "In ","ten days",", your town will be overrun",
               "",
               "Are you a bad enough dude to save them?",
            });
        Console.ReadKey(true);
        ChooseSibling();
    }

    public static void ChooseSibling()
    {
        Console.Clear();
        Write.SetY(15);
        UIComponent.BarBlank();
        UIComponent.StandardMiddle(8);
        UIComponent.BarBlank();
        Console.SetCursorPosition(Return.Width(0), Return.Height(7));
        if (w.Alive) Write.Line(Color.NAME, "[1]", Family.alive[0], ". The Warrior");
        Console.SetCursorPosition(Return.Width(0), Return.Height(12));
        if (r.Alive) Write.Line(Color.NAME,  "[2]", Family.alive[1], ". The Rogue");
        Console.SetCursorPosition(Return.Width(0), Return.Height(16));
        if (m.Alive) Write.Line(Color.NAME, "[3]", Family.alive[2],". The Mage");
        Write.Position(47, 22);
        Console.WriteLine("Please select a sibling");
        string choice = Return.Option();
        p = new Player();
        if (choice != "1" & choice != "2" && choice != "3") ChooseSibling();
        else
        {
            if (choice == "1") if (!UI.ConfirmNEW(new List<int> { 1 }, new List<string> { Color.NAME, "You have chosen ", Family.alive[0], ", correct?" })) ChooseSibling();
            else
            {
                p = w;
                p.Name = Family.alive[0];
                Name(0);
            }
            else if (choice == "2") if (!UI.ConfirmNEW(new List<int> { 1 }, new List<string> { Color.NAME, "You have chosen ", Family.alive[1], ", correct?" })) ChooseSibling();
            else
            {
                p = r;
                p.Name = Family.alive[1];
                Name(1);
            }
            else if (!UI.ConfirmNEW(new List<int> { 1 }, new List<string> { Color.NAME, "You have chosen ", Family.alive[2], ", correct?" })) ChooseSibling();
            else
            {
                p = m;
                p.Name = Family.alive[2];
                Name(2);
            }            
        }
    }

    internal static void Name(int birthOrder)
    {
        string a = (birthOrder == 0)?"You have the weight of the world on your shoulders. It's all up to you now":(birthOrder ==1)?"It's time to come back into the fold and use the skills you learned on the streets":"You're not much of a fighter, but maybe brute strength isn't what's required";
        string b = (birthOrder == 0) ? "You were by her side as she fell, and swore revenge." : (birthOrder == 1) ? "You have returned to Marburgh to pay your respects... and get revenge" : "You were never close, but you love Marburgh, and know that the Orcs mean the destruction of everything you known";
        string[] order = new string[] { "eldest", "middle", "youngest" };
        Console.Clear();
        UI.KeypressNEW(new List<int> { 1, 1, 0, 0, 0 ,0,0}, new List<string>
            {
               Color.NAME,  "Your name is ", p.Name ,"",
               Color.NAME,  "Your Mother, ", $"Helen {Family.lastName}", " was an adventurer.",
               $"She was recently killed by an Orc. {b}.",
               "",
               $"You are the {order[birthOrder]} child.",
               "",
               a
            });
        Sound.Stop();
        Utilities.ToTown();
    }

    
    
}