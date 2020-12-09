using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Altar:Room
{
    public Altar()
    :base()
    {
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found an old altar" };
        name = $"Altar";
    }
    internal override void Explore()
    {
        UI.Choice(new List<int> { 0,0,1,0,2,0,1 }, new List<string>
        {
            "As you approach, you see the dead body of a townsperson you couldn't save",
            "",
            Color.DAMAGE, "Their ","heart"," has been removed and their lips are sewn shut",
            "",
            Color.DEATH,Color.DEATH,"You realize this is an altar to ","Toliax",", the god of"," Death","",
            "",
            Color.DEATH,"There is clearly a great deal of power here, and ","death ","plays no favorites...."
        }, new List<string> { "tudy", "esecrate", "alk away" }, new List<string> { Color.ENERGY + "S" + Color.RESET, Color.DAMAGE + "D" + Color.RESET, Color.MITIGATION + "W" + Color.RESET }) ;
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
                    studyList.Add(Color.ENERGY);
                    studyList.Add("");
                    studyList.Add("Success! ");
                    studyList.Add("");
                    studyColourArray.Add(0);
                    studyList.Add("");
                    studyColourArray.Add(1);
                    studyList.Add(Color.HEALTH);
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
                studyList.Add(Color.DAMAGE);
                studyList.Add("");
                studyList.Add("This was not for you to know! It's too much for your mind and body!");
                studyList.Add("");
                studyColourArray.Add(0);
                studyList.Add("");
                studyColourArray.Add(2);
                studyList.Add(Color.HEALTH);
                studyList.Add(Color.DAMAGE);
                studyList.Add("Your ");
                studyList.Add("health ");
                studyList.Add("is reduced to ");
                studyList.Add("1");
                studyList.Add("!");
                Create.p.Health = 1;
            }
            ActionWait(studyColourArray, studyList, Color.ENERGY + "Studying" + Color.RESET, null);
        }
        else if (choice == "d")
        {
            Console.Clear();
            List<int> desecrateColourArray = new List<int> { };
            List<string> desecrateList = new List<string> { };
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            if (Return.RandomInt(1, 101) <= 25)
            {
                desecrateColourArray.Add(1);
                desecrateList.Add(Color.HEALTH);
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
                desecrateList.Add(Color.HEALTH);
                desecrateList.Add("Next fight, every monster starts with");
                desecrateList.Add(" HALF ");
                desecrateList.Add("health!");
                Combat.desecrated = true;
            }
            else
            {
                desecrateColourArray.Add(1);
                desecrateList.Add(Color.DAMAGE);
                desecrateList.Add("");
                desecrateList.Add("You have made the gods angry!");
                desecrateList.Add("");
                desecrateColourArray.Add(0);
                desecrateList.Add("");
                desecrateColourArray.Add(2);
                desecrateList.Add(Color.HEALTH);
                desecrateList.Add(Color.DAMAGE);
                desecrateList.Add("Your ");
                desecrateList.Add("health ");
                desecrateList.Add("is reduced to ");
                desecrateList.Add("1");
                desecrateList.Add("!");
            }
            ActionWait(desecrateColourArray, desecrateList, Color.ENERGY + "Desecrating" + Color.RESET, null);
        }
        else if (choice == "w") { }
        else Explore();
        visited = true;
    }

    public override List<string> Flavor
    {
        get
        {
            if (visited) return new List<string> { $"You see an altar. Whatever mystical forces were enhabiting it, they are long gone" };
            else return flavor;
        }
    }
}