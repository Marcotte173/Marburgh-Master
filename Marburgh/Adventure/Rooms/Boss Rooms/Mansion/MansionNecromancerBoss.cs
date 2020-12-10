using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class MansionNecromancerBoss : Room
{
    ///Constructor
    public MansionNecromancerBoss()
    : base()
    {
        name = "Necromancer";
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found the Necromancer's quarters" };
    }

    internal override void Explore()
    {
        UI.Keypress(new List<int> { 0, 0, 0 }, new List<string>
        {
            "The Savage Orc bellows at you as he brandishes his weapon",
            "",
            "There's no turning back now!",
        });
        Dungeon.Summon(Dungeon.necromancer);
        Combat.Menu();
        UI.Keypress(new List<int> { 0, 0, 0, 0, 0 }, new List<string>
        {
            "The Savage Orc looks shocked as the life leaves his eyes",
            "",
            "You have defeated your foes, saving your town forever!",
            "",
            "Triumphant, you make your way back to town"
        });
        Utilities.ToTown();
    }
}