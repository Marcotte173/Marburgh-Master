using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Kitchen : Room
{
    public Kitchen()
    : base()
    {
        resetable = false;
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found the kitchen" };
        name = $"Kitchen";
    }
    internal override void Explore()
    {
        Console.Clear();
        UI.Keypress(new List<int> {1,0,1,2,0,1,1,0,1,0,0 }, new List<string>
        {
            Color.DAMAGE,"The kitchen is a horrifying tableau of ","misery ","",
            "",
            Color.DAMAGE,"Human ","coprses"," are stacked carelessly in the corner",
            Color.DAMAGE,Color.MONSTER,"","Severed limbs"," hang from hooks over what is looks to be a ","butchering"," station. ",
            "",
            Color.NAME,"You recognize some corpses as being from your ","town",".",
            Color.DEATH,"Clearly, this is what they do with the bodies when the ","experiments"," are through",
            "",
            Color.MONSTER,"A giant ","orc", " is butchering a corpse as you enter.",
            "",
            "With a bellow, he charges!"
        });
        Dungeon.Summon(Dungeon.orc2);
        Create.p.combatMonsters[0].Name = "Butcher";
        Combat.Menu();
        UI.Keypress(new List<int> { 1,0,1,0,0 }, new List<string>
        {
            Color.MONSTER,"The ","Butcher ","is dead",
            "",
            Color.RAREDROP,"There is a broken ","cleaver"," on the floor",
            "",
            "You take it, perhaps you can repair it",
        });
        Create.p.AddDrop(DropList.brokenCleaver);
        visited = true;
    }

    public override List<string> Flavor
    {
        get
        {
            if (visited) return new List<string> { $"You see the Kitchen. The Butcher lies dead" };
            else return flavor;
        }
    }
}