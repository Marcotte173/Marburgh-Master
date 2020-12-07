using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Latrine : Room
{
    public Latrine()
    : base()
    {
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found the latrines" };
        name = $"Latrines";
    }

    internal override void Explore()
    {
        UI.Keypress(new List<int> { 0, 0, 0 }, new List<string>
        {
            $"You smell them before you see them, but you have discovered the latrines",
            "",
            "Lucky there's no one around.",
        });
        Decision();        
    }

    private void Decision()
    {
        UI.Choice(new List<int> { 0, 0, 0 }, new List<string>
        {
            "If you were so inclined, you COULD search the latrines.",
            "",
            "Or you could move on."
        }, new List<string> { "earch", "eep going" }, new List<string> { Color.ENERGY + "S" + Color.RESET, Color.MITIGATION + "K" + Color.RESET });
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "s")
        {
            if (Return.RandomInt(0,101) < 60)
            {
                int teeth = Return.RandomInt(1, 3);
                UI.Keypress(new List<int> { 0, 0, 0 }, new List<string>
                {
                    $"Searching through the muck you find {teeth} monster teeth!",
                    "",
                    "A lucky find! Almost worth it!",
                });
                for (int i = 0; i < teeth; i++) { Create.p.AddDrop(AdventureItems.monsterTooth); }                
            }
            else
            {
                UI.Keypress(new List<int> { 0, 0, 0 }, new List<string>
                {
                    $"You smell them before you see them, but you have discovered the latrines",
                    "",
                    "Lucky there's no one around.",
                });
            }
        }
        else if (choice == "k")
        {
            UI.Keypress(new List<int> { 0, 0, 0 }, new List<string>
            {
                $"Probably for the best",
                "",
                "That place stinks!",
            });
        }
        visited = true;
    }
    public override List<string> Flavor
    {
        get
        {
            if (visited) return new List<string> { $"You enter the latrines. The smell is overwhelming. Time to move on" };
            else return flavor;
        }
    }
}