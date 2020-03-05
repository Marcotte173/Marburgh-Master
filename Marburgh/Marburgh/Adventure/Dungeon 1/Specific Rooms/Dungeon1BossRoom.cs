using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Dungeon1BossRoom : Room
{
    ///Constructor
    public Dungeon1BossRoom()
    : base()
    {
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found a secret Lair!" };
    }

    internal override void Explore()
    {
        UI.Keypress(new List<int> { 0, 0, 1, 0 , 1, 0, 0 }, new List<string>
        {
            "Entering the lair you find a large Orc, but not the one you expecte to find",
            "",
            Colour.SPEAK, "","Heh, you thought you found da boss, eh?","",
            "",
            Colour.SPEAK, "","He's further inside not that it matters to you. Now you gonna die"," ",
            "",
            "The Orc charges "
        });
        global::Summon.Orc();
        Location.list[10].Go();
        GameState.CanCraft = true;        
        House.houseOptionList.Add("nhancement Machine");
        House.houseOptionButton.Add(Colour.ENHANCEMENT + "E" + Colour.RESET);
        UI.Keypress(new List<int> { 0, 0, 0, 0, 0 }, new List<string>
        {
            "You emerge vitorious!",
            "",
            "Searching the room you find a strange looking machine",
            "",
            "Curious, you bring the machine home with you"
        }) ;
        Utilities.ToTown();
    }
}