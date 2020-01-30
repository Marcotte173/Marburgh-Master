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
        flavor = new List<string> { "You have found the Savage Orc's Lair!" };
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
        UI.Keypress(new List<int> { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 }, new List<string>
        {
            "You have beaten the first dungeon and for now, the game",
            "",
            "Check back soon! As you read this I'm hard at work adding more dungeons, monsters and Items.",
        });
        Environment.Exit(0);
    }
}