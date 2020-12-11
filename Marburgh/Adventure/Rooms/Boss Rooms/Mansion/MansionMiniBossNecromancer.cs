using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MansionMiniBossNecromancer : Room
{
    public MansionMiniBossNecromancer()
       : base()
    {
        resetable = false;
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found the necromancer's apprentice!" };
        name = $"Apprentice";
    }
    internal override void Explore()
    {
        Console.Clear(); 
        UI.Keypress(new List<int> { 1,0, 1,0,2 }, new List<string>
        {
            Color.MONSTER,"The ", "Wizard", " looks up from his experiment",
            "",
            Color.SPEAK,"","'Ahhh, one of our guests appear to be lost. Please, allow me to assist you'","",
            "",
            Color.MONSTER,Color.MONSTER,"The ", "Necromancer's apprentice ","snaps his fingers and two ","Zombies"," advance on you "
        });
        Dungeon.Summon(Dungeon.necromancerApprentice);
        Dungeon.Summon(Dungeon.zombie3);
        Dungeon.Summon(Dungeon.zombie3);
        Create.p.combatMonsters[0].Name = "Necromancer's Apprentice";
        Combat.Menu();
        UI.Keypress(new List<int> { 2, 0, 1, 0, 1,0,0 }, new List<string>
        {
            Color.MONSTER,Color.MONSTER,"The ","Necromancer ","and his ","minions"," lie dead...er",
            "",
            Color.CRIT,"Searching his body you find a "," medallion","",
            "",
            Color.MONSTER,"It's clear that the ","Necromancer ","is not the original owner",
            "",
            "Someone in town could be looking for this"
        });
        Create.p.AddDrop(DropList.mansionMedalion);
        visited = true;
    }

    public override List<string> Flavor
    {
        get
        {
            if (visited) return new List<string> { $"You see dead Necromancer. Well, more dead." };
            else return flavor;
        }
    }
}