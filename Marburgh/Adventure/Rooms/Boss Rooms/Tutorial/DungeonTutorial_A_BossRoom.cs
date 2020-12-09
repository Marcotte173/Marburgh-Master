using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class DungeonTutorial_A_BossRoom : Room
{
    ///Constructor
    public DungeonTutorial_A_BossRoom()
    : base()
    {
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found a secret Lair!" };
        name = "Lair";
    }

    internal override void Explore()
    {
        UI.Keypress(new List<int> { 0, 0, 1, 0 , 1, 0, 0 }, new List<string>
        {
            "Entering the lair you find a large Orc, but not the one you expected to find",
            "",
            Color.SPEAK, "","Heh, you thought you found da boss, eh?","",
            "",
            Color.SPEAK, "","He's further inside not that it matters to you. Now you gonna die"," ",
            "",
            "The Orc charges "
        });
        Dungeon.Summon(Dungeon.orc1);
        Combat.Menu();
        GameState.CanCraft();        
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