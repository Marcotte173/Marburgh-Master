using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Create
{
    internal static Warrior w = new Warrior(3, 2, 3, 2);
    internal static Mage m = new Mage(3, 2, 2, 3);
    internal static Rogue r = new Rogue(3, 3, 3, 2);
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
        UIComponent.DisplayText(new List<int> { 1,0,3,0,1,0,0,0,1,0,1,0,0}, new List<string>
            {
               Color.CLASS,"You come from a long line of ","adventurers","",
               "",
               Color.NAME, Color.CLASS, Color.MONSTER, "Your ","mother",", an ","adventurer ","herself, was murdered by ","Orcs",", as they ransacked your town",
               "",
               Color.DAMAGE,"Many villagers ","died",", and even more were captured. ",
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
        if (w.Alive)
        {
            Write.Line(0, 6, "[1]" + Color.NAME + Family.alive[0]);
            Write.Line(32, 6, "The " + Color.SHIELD + "firstborn" + Color.RESET + ". With the weight of the world on their shoulders, they trained everyday");
            Write.Line(32, 7, "Bulding themelves into the ultimate " + Color.CLASS + "warrior");
        }
        if (r.Alive)
        {
            Write.Line(0, 9, "[2]" + Color.NAME + Family.alive[1]);
            Write.Line(32, 9, "The " + Color.SHIELD + "middle child" + Color.RESET + ". Fed up with the pressure, they fell into the wrong crowd.");
            Write.Line(32, 10, "Sneaking and dirty tricks became the norm for this " + Color.CLASS + "rogue");
        }
        if (m.Alive)
        {
            Write.Line(0, 12, "[3]" + Color.NAME + Family.alive[2]);
            Write.Line(32, 12, "The " + Color.SHIELD + "youngest" + Color.RESET + ". Free to persue their own interests, They studied the occult");
            Write.Line(32, 13, "One day they hope to be an all powerful " + Color.CLASS + "mage");
        }
        Write.Line(47, 22, "Please select a sibling");
        string choice = Return.Option();
        p = new Player(2, 2, 2, 2);
        if (choice == "1" && w.Alive)
        {
            if (!UI.ConfirmNEW(new List<int> { 1 }, new List<string> { Color.NAME, "You have chosen ", Family.alive[0], ", correct?" })) ChooseSibling();
            else
            {
                p = w;
                foreach (Button b in Button.listOfCombatOptions) b.active = false;
                Button.attackButton.active = true;
                Button.defendButton.active = true;
                p.Name = Family.alive[0];
                if (Family.cursed) p.Intelilgence -= 1;
                Name(0);
            }
        }
        else if (choice == "2" && r.Alive)
        {
            if (!UI.ConfirmNEW(new List<int> { 1 }, new List<string> { Color.NAME, "You have chosen ", Family.alive[1], ", correct?" })) ChooseSibling();
            else
            {
                p = r;
                foreach (Button b in Button.listOfCombatOptions) b.active = false;
                Button.attackButton.active = true;
                Button.defendButton.active = true;
                p.Name = Family.alive[1];
                if (Family.cursed) p.Intelilgence -= 1;
                Name(1);
            }
        }
        else if (choice == "3" && m.Alive)
        {
            if (!UI.ConfirmNEW(new List<int> { 1 }, new List<string> { Color.NAME, "You have chosen ", Family.alive[2], ", correct?" })) ChooseSibling();
            else
            {
                p = m;
                foreach (Button b in Button.listOfCombatOptions) b.active = false;
                Button.attackButton.active = true;
                Button.shieldButton.active = true;
                p.Name = Family.alive[2];
                if (Family.cursed) p.Agility -= 1;
                Name(2);
            }
        }
        else ChooseSibling();   
    }

    internal static void Name(int birthOrder)
    {
        string a = (birthOrder == 0) ? "You have the weight of the world on your shoulders. It's all up to you now" : (birthOrder == 1) ? "It's time to come back into the fold and use the skills you learned on the streets" : "You're not much of a fighter, but maybe brute strength isn't what's required";
        string b = (birthOrder == 0) ? "You were by her side as she fell, and swore revenge." : (birthOrder == 1) ? "You have returned to Marburgh to pay your respects... and get revenge" : "You were never close, but you love Marburgh, and know that the Orcs mean the destruction of everything you known";
        string[] order = new string[] { "eldest", "middle", "youngest" };
        Console.Clear();
        UI.KeypressNEW(new List<int> { 1,0,1,0,1,0,1,0,1 }, new List<string>
        {
            Color.NAME,  "Your name is ", p.Name ,"",
            "",
            Color.NAME,  "Your Mother, ", $"Helen {Family.lastName}", " was an adventurer.",
            "",
            Color.BOSS,"She was recently killed by an ","Orc", $". {b}.",
            "",
            Color.TIME,$"You are the ",order[birthOrder]," child.",
            "",
            Color.CLASS,"",a,""
        });        
        Console.Clear();
        if (p.PClass == PlayerClass.Warrior) Help.Warrior();
        else if (p.PClass == PlayerClass.Mage) Help.Mage();
        else if (p.PClass == PlayerClass.Rogue) Help.Rogue();
        Write.Line(94, 28, Color.TIME, "Press any key to continue");
        Console.ReadKey(true);
        if (Family.dead.Count >0)
        {
            int goldGet = (GameState.phase2b) ? 800 : (GameState.phase2b) ? 800 : (GameState.phase1b) ? 500 : (GameState.firstBossDead) ? 300 : 100;          
            UI.KeypressNEW(new List<int> {0,0,0,0,0,0,0,0,1 }, new List<string>
            {
                "Seargeant Billiam approaches you as you enter town",
                "",
                "I'm glad I caught you. I'm so sorry to hear about you sibling. Were you close?",
                "",
                "Well, we're down a Hero and really hope you're able to step up",
                "",
                "We raised a little money to get you started. I know it's not much but but hopefully it'll help",
                "",
                Color.GOLD,"You receive " ,goldGet.ToString(), " gold"
            }) ;
            Create.p.Gold += goldGet;
        }
        Utilities.ToTown();
    }



}