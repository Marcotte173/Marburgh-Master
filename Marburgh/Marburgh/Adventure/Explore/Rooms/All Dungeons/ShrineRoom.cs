using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class ShrineRoom : Room
{
    public ShrineRoom(int size, int tier)
    : base(size, tier)
    {
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You find a shrine!" };
        name = $"Shrine";
    }
    internal override void Explore()
    {
        UI.Choice(new List<int> { 0, 1, 0, 1, 1, 1 }, new List<string>
            {
                "You approach the altar and find a rune, placed with great care and reverance. ",
                Colour.MONSTER,"You recognize it as belonging to one of the ","Orc ","gods, who they belive bring them strength and victory.",
                "They would be angry indeed if anything were to happen to it.",
                Colour.ENERGY, "You could ", "study ", "the runes, trying to learn the secrets of the Orc gods",
                Colour.DAMAGE, "You could ", "desecrate ", "the runes, angering the orcs but possibly interrupting their power source",
                Colour.MITIGATION, "You could ", "walk away, ", "moving on to the next room"
            }, new List<string> { "tudy", "esecrate", "alk away" }, new List<string> { Colour.ENERGY + "S" + Colour.RESET, Colour.DAMAGE + "D" + Colour.RESET, Colour.MITIGATION + "W" + Colour.RESET });
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "s")
        {
            Console.Clear();
            List<int> studyColourArray = new List<int> { };
            List<string> studyList = new List<string> { };
            studyColourArray.Add(0);
            studyList.Add("");
            if (Return.RandomInt(1, 101) <= 75)
            {
                if (Create.p.Health < Create.p.MaxHealth)
                {
                    studyColourArray.Add(1);
                    studyList.Add(Colour.ENERGY);
                    studyList.Add("");
                    studyList.Add("Success! ");
                    studyList.Add("");
                    studyColourArray.Add(0);
                    studyList.Add("");
                    studyColourArray.Add(1);
                    studyList.Add(Colour.HEALTH);
                    studyList.Add("Your ");
                    studyList.Add("health ");
                    studyList.Add("returns to maximum!");
                    Create.p.Health = Create.p.MaxHealth;
                }
                else
                {
                    studyColourArray.Add(0);
                    studyList.Add("Sadly, you glean very little from the runes");
                }
            }
            else
            {
                studyColourArray.Add(1);
                studyList.Add(Colour.DAMAGE);
                studyList.Add("");
                studyList.Add("This was not for you to know! It's too much for your mind and body!");
                studyList.Add("");
                studyColourArray.Add(0);
                studyList.Add("");
                studyColourArray.Add(2);
                studyList.Add(Colour.HEALTH);
                studyList.Add(Colour.DAMAGE);
                studyList.Add("Your ");
                studyList.Add("health ");
                studyList.Add("is reduced to ");
                studyList.Add("1");
                studyList.Add("!");
                Create.p.Health = 1;
            }
            ActionWait(studyColourArray, studyList, Colour.ENERGY + "Studying" + Colour.RESET, null);
            visited = true;
            Location.list[10].Go();
        }
        if (choice == "d")
        {
            Console.Clear();
            List<int> desecrateColourArray = new List<int> { };
            List<string> desecrateList = new List<string> { };
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            if (Return.RandomInt(1,101) <= 25)
            {
                desecrateColourArray.Add(1);
                desecrateList.Add(Colour.HEALTH);
                desecrateList.Add("");
                desecrateList.Add("Success! ");
                desecrateList.Add("");
                desecrateColourArray.Add(0);
                desecrateList.Add("");
                desecrateColourArray.Add(0);
                desecrateList.Add("You hear screams from further in the dungeon!");
                desecrateColourArray.Add(0);
                desecrateList.Add("");
                desecrateColourArray.Add(1);
                desecrateList.Add(Colour.HEALTH);
                desecrateList.Add("Next fight, every monster starts with");
                desecrateList.Add(" HALF ");
                desecrateList.Add("health!");
                Combat.desecrated = true;
            }
            else
            {
                desecrateColourArray.Add(1);
                desecrateList.Add(Colour.DAMAGE);
                desecrateList.Add("");
                desecrateList.Add("You have made the gods angry!");
                desecrateList.Add("");
                desecrateColourArray.Add(0);
                desecrateList.Add("");
                desecrateColourArray.Add(2);
                desecrateList.Add(Colour.HEALTH);
                desecrateList.Add(Colour.DAMAGE);
                desecrateList.Add("Your ");
                desecrateList.Add("health ");
                desecrateList.Add("is reduced to ");
                desecrateList.Add("1");
                desecrateList.Add("!");
            }
            ActionWait(desecrateColourArray, desecrateList, Colour.ENERGY + "Desecrating" + Colour.RESET, null);
            visited = true;
            Location.list[10].Go();
        }
        if (choice == "w")
        {
            visited = true;
        }
        else Explore();
    }
}