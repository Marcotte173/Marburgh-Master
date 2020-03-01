using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dungeon2MiniBoss : Room
{
    public Dungeon2MiniBoss()
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
    }
}