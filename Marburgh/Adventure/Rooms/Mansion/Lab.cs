using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Lab : Room
{
    public Lab()
       : base()
    {
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found a dusty Laboratory" };
        name = $"Lab";
    }
    internal override void Explore()
    {
        Console.Clear();
        visited = true;
        UI.Choice(new List<int> { 0,1,0,0 }, new List<string>
        {
            "",
            Color.ITEM,"As you enter the lab, you see an assortment of bubbling ","potions","",
            "",
            "If you like you can drink one"

        }, new List<string> { "ed potion", "ellow potion","reen potion","","alk away" }, new List<string> { Color.DAMAGE + "R" + Color.RESET, Color.HIT + "Y" + Color.RESET, Color.HEALTH + "G" + Color.RESET, "", Color.DEFENCE + "W" + Color.RESET });
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice != "r" && choice != "y" && choice != "g" ) 
        {
            if (choice == "9") CharacterSheet.Display();
            Explore();
        }
        else
        {
            List<int> colourList = new List<int> { };
            List<string> stringList = new List<string> { };
            colourList.Add(0);
            stringList.Add("");
            string feel = "";
            UI.Keypress(new List<int> { 1,0,0,0,0,0,0,0,0 }, new List<string>
            {
                Color.POTION,"You grab the ","potion"," and gulp it down",
                "",
                "I mean, what's the worst that could happen?",
                "",
                "Uh oh, something's happening...",
                "",
                "You start thrashing around uncontrollably as the potion takes effect in your body",
                "",
                "When you finally regain control you look around at the wrecked lab and try to assess how you feel"
            });
            if (choice == "r")
            {
                if (Return.RandomInt(1, 101) <= 40)
                {
                    feel = Color.DAMAGE + "Stronger!"+ Color.RESET;
                    colourList.Add(1);
                    stringList.Add(Color.DAMAGE);
                    stringList.Add("You gain 1");
                    stringList.Add(" strength");
                    stringList.Add(" permanently!");
                    Create.p.Strength++;
                }
                else
                {
                    feel = Color.DAMAGE + "Weaker!" + Color.RESET;
                    colourList.Add(1);
                    stringList.Add(Color.DAMAGE);
                    stringList.Add("You lose 1");
                    stringList.Add(" strength");
                    stringList.Add(" permanently!");
                    Create.p.Strength--;
                }
            }
            else if (choice == "y")
            {
                if (Return.RandomInt(1, 101) <= 40)
                {
                    feel = Color.HIT + "Quicker!" + Color.RESET;
                    colourList.Add(1);
                    stringList.Add(Color.HIT);
                    stringList.Add("You gain 1");
                    stringList.Add(" Agility");
                    stringList.Add(" permanently!");
                    Create.p.Agility++;
                }
                else
                {
                    feel = Color.HIT + "Uncoordinated!" + Color.RESET;
                    colourList.Add(1);
                    stringList.Add(Color.HIT);
                    stringList.Add("You lose 1");
                    stringList.Add(" Agility");
                    stringList.Add(" permanently!");
                    Create.p.Agility--;
                }
            }
            else if (choice == "g")
            {
                if (Return.RandomInt(1, 101) <= 40)
                {
                    feel = Color.HEALTH + "Tougher!" + Color.RESET;
                    colourList.Add(1);
                    stringList.Add(Color.HEALTH);
                    stringList.Add("You gain 1");
                    stringList.Add(" Stamina");
                    stringList.Add(" permanently!");
                    Create.p.Stamina++;
                }
                else
                {
                    feel = Color.HEALTH + "Fragile!" + Color.RESET;
                    colourList.Add(1);
                    stringList.Add(Color.HEALTH);
                    stringList.Add("You lose 1");
                    stringList.Add(" Stamina");
                    stringList.Add(" permanently!");
                    Create.p.Stamina--;
                }
            }
            ActionWait(colourList, stringList, Color.RESET + "You feel " + Color.RESET, feel);
            Create.p.Update();
            UI.Keypress(new List<int> { 1, 0,0 }, new List<string>
            {
                Color.MONSTER,"Unfortunately, your thrashing destroyed the other ","potions ","",
                "",
                "You have no choice but to press on"
            });
        }          
    }

    public override List<string> Flavor
    {
        get
        {
            if (visited) return new List<string> { $"You see a laboratory. You have already searched it for anything of value" };
            else return flavor;
        }
    }
}