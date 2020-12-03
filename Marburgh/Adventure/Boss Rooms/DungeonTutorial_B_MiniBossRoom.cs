using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DungeonTutorial_B_MiniBossRoom : Room
{
    public DungeonTutorial_B_MiniBossRoom()
    : base()
    {
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found an Orc Lieutenant!" };
    }
    internal override void Explore()
    {
        UI.Keypress(new List<int> {0,0,0 }, new List<string>
        {
            "Guarding the cell is a nasty looking orc!",
            "",
            "He pulls out his weapon and charges!",
        });
        global::Summon.Orc();
        Create.p.combatMonsters[0].Name = "Orc Lieutenant";
        Combat.Menu();
        UI.Keypress(new List<int> { 0, 0, 0,0,0 }, new List<string>
        {
            "You have defeated the Savage Orc's right hand... Orc",
            "",
            "Searching his body you find a key",
            "",
            "Could this be useful somewhere in the dungeon?"
        });
        Create.p.Drops.Add(AdventureItems.tutorialKey);
        visited = true;
    }
}