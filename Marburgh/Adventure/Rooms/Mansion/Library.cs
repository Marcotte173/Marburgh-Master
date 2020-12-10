using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Library : Room
{
    public Library()
       : base()
    {
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found a Library" };
        name = $"Library";
    }
    internal override void Explore()
    {
        UI.Choice(new List<int> { 0,1,0,0,0,1,0,1 }, new List<string>
        {
            "",
            Color.XP,"You enter a room filled with stacks of ","books!","",
            "",
            "In the corner you can see a small, well kept deskdesk",
            "",
            Color.DEATH,"Open on the desk appears to be a book the ","necromancer"," himself was just reading",
            "",
            Color.DEATH,"This could be a ","powerful"," source of information. Will you read it or a regular book from the pile?"

        }, new List<string> { "egular book", "ecromancer's book", "alk away" }, new List<string> { Color.DAMAGE + "R" + Color.RESET, Color.HIT + "N" + Color.RESET, Color.DEFENCE + "W" + Color.RESET });
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        int xp = Return.RandomInt(15, 20);
        int xpRegular = Return.RandomInt(40, 50);
        if (choice == "n")
        {
            int fate = Return.RandomInt(1, 101);
            if (fate >= 90)
            {
                UI.Keypress(new List<int> { 2, 0, 1}, new List<string>
                {
                    Color.ENERGY, Color.DEATH,"You learn ","Secrets ","of ","power","!",
                    "",
                    Color.ENERGY,"You gain 1 ","intelligence"," permanently!"
                });
                Create.p.Intelilgence++;
                Create.p.Update();
            }
            else if (fate <= 15)
            {
                UI.Keypress(new List<int> { 0,0,1,0,0,0,1 }, new List<string>
                {
                    "Regular books are read...",
                    "",
                    Color.DEATH,"Books of ","power"," read you",
                    "",
                    "Your head feels cloudy as your intelligence is stolen",
                    "",
                    Color.ENERGY,"You lose 1 ","intelligence"," permanently!"
                });
                Create.p.Intelilgence--;
                Create.p.Update();
            }
            else
            {
                UI.Keypress(new List<int> { 1,0,0,0,0,0,1}, new List<string>
                {
                    Color.XP,"You read the ","book",", mouth moving during the dificult bits",
                    "",
                    "You're pretty sure you understand half of it. A quarter at least.",
                    "",
                    "You recognize many of the words..",
                    "",
                    Color.XP,"You gain ",xp.ToString()," experience!",
                });
                Create.p.XP += xp;
            }
        }
        else if (choice == "r")
        {
            UI.Keypress(new List<int> { 1,0,1, 0, 1}, new List<string>
            {
                Color.XP,"You grab a ","book"," at random, hoping it will be informative",
                "",                
                Color.XP,"You read the ","book",", learning quite a bit",
                "",
                Color.XP,"You gain ",xpRegular.ToString()," experience!",
            });
            Create.p.XP += xpRegular;
        }
        else if (choice == "w") { }
        else if (choice == "9")
        {
            CharacterSheet.Display();
            Explore();
        }
        CharacterSheet.Display();
    }

    public override List<string> Flavor
    {
        get
        {
            if (visited) return new List<string> { $"You see a library. You have already gleaned any knowedge that you can." };
            else return flavor;
        }
    }
}