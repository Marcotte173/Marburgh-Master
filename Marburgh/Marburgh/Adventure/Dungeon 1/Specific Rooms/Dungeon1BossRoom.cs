using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Dungeon1BossRoom : Room
{
    ///Constructor
    public Dungeon1BossRoom(int size, int tier)
    : base(size, tier)
    {
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found a secret Lair!" };
    }

    internal override void Explore()
    {
        UI.Keypress(new List<int> { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 }, new List<string>
        {
            "The Savage Orc bellows at you as he brandishes his weapon",
            "",
            "There's no turning back now!",
        });
        global::Summon.SavageOrc();
        Location.list[11].Go();
        GameState.CanCraft = true;
        UI.Keypress(new List<int> { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 }, new List<string>
        {
            "The Savage Orc bellows at you as he brandishes his weapon",
            "",
            "There's no turning back now!",
        });
    }
}