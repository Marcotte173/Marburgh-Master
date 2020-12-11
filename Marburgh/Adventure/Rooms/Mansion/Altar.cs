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
        resetable = false;
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found an old altar" };
        name = $"Altar";
    }
    internal override void Explore()
    {
        UI.Choice(new List<int> { 0,0,1,0,2,0,0,0,1 }, new List<string>
        {
            "As you approach, you see the dead body of a townsperson you couldn't save",
            "",
            Color.DAMAGE, "Their ","heart"," has been removed and their lips are sewn shut",
            "",
            Color.DEATH,Color.DEATH,"You realize this is an altar to ","Toliax",", the god of"," Death","",
            "",
            "At the base of the altar there is an empty pool",
            "",
            Color.DEATH,"There is clearly a great deal of power here, and ","death ","plays no favorites...."
        }, new List<string> { "ray to "+Color.DEATH+"Toliax"+Color.RESET, "estroy this abomination", Color.RESET+"alk away" }, new List<string> { Color.ENERGY + "P" + Color.RESET, Color.DAMAGE + "D" + Color.RESET, Color.MITIGATION + "W" + Color.RESET }) ;
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "p") Pray();
        else if (choice == "d")
        {
            Console.Clear();
            List<int> desecrateColourArray = new List<int> { };
            List<string> desecrateList = new List<string> { };
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(0);
            desecrateList.Add("You destroy the altar");
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(1);
            desecrateList.Add(Color.DEATH);
            desecrateList.Add("You can feel a ");
            desecrateList.Add("presence ");
            desecrateList.Add("stirring. It is not happy");
            ActionWait(desecrateColourArray, desecrateList, Color.DAMAGE + "Destroying" + Color.RESET, null);
        }
        else if (choice == "9")
        {
            CharacterSheet.Display();
            Explore();
        }
        else if (choice == "w") { }
        else Explore();
        visited = true;
    }

    private void Pray()
    {
        visited = true;
        Console.Clear();
        List<int> studyColourArray = new List<int> { };
        List<string> studyList = new List<string> { };
        studyColourArray.Add(0);
        studyList.Add("");
        studyColourArray.Add(1);
        studyList.Add(Color.DEATH);
        studyList.Add("You hear");
        studyList.Add(" whispers");
        studyList.Add(", or was it wind?");
        ActionWait(studyColourArray, studyList, Color.ENERGY + "Praying" + Color.RESET, null);
        UI.Choice(new List<int> { 0, 0, 1, 0, 0, 1 }, new List<string>
            {
                "",
                "",
                Color.DEATH,"","Toliax ","has heard you and responds",
                "",
                "",
                Color.DEATH,"The pool at the base of the altar begins to fill with a pale ", "green ", "liquid",
            }, new List<string> { "rink the liquid", "ottle the liquid", "alk awak" }, new List<string> { Color.DEATH + "D" + Color.RESET, Color.POTION + "B" + Color.RESET, Color.MITIGATION + "W" + Color.RESET });
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "d")
        {
            Console.Clear();
            List<int> desecrateColourArray = new List<int> { };
            List<string> desecrateList = new List<string> { };
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(1);
            desecrateList.Add(Color.HEALTH);
            desecrateList.Add("You feel ");
            desecrateList.Add("Strange");
            desecrateList.Add(".");
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(1);
            desecrateList.Add(Color.DEATH);
            desecrateList.Add("");
            desecrateList.Add("Death ");
            desecrateList.Add("radiates from you");
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(0);
            desecrateList.Add("");
            desecrateColourArray.Add(1);
            desecrateList.Add(Color.HEALTH);
            desecrateList.Add("You are at ");
            desecrateList.Add("-10 ");
            desecrateList.Add("health!");
            Create.p.Health = -10;
            ActionWait(desecrateColourArray, desecrateList, Color.DEATH + "Drinking" + Color.RESET, null);
        }
        else if (choice == "b")
        {
            UI.Keypress(new List<int> { 1, 0, 0, 0, 1 }, new List<string>
            {
                Color.DEATH,"You fill a bottle with the ","liquid","",
                "",
                "Who knows, this may come in handy some time",
                "",
                Color.POTION, "You gain 1 ","Potion of Death",""
            });
        }
        else if (choice == "w") { }
        else Pray();
    }

    public override List<string> Flavor
    {
        get
        {
            if (visited) return new List<string> { $"You see an altar. Whatever mystical forces were inhabiting it, they are long gone" };
            else return flavor;
        }
    }
}