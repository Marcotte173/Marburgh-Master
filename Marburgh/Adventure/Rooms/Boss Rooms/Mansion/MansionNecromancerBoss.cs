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
        resetable = false;
        name = "Necromancer";
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found the Necromancer's quarters" };
    }

    internal override void Explore()
    {
        UI.Keypress(new List<int> { 0,2,0,0,0,1,0,1 }, new List<string>
        {
            "",
            Color.DEATH,Color.NAME,"You confront the ","Necromancer", " who has been terrorizing your ","town","",
            "",
            "You tell him the deaths end here",
            "",
            Color.DEATH,"The ","Necromancer ","eyes you, smiling",
            "",
            Color.SPEAK," ","'Let's see'","",
        });
        Dungeon.Summon(Dungeon.necromancer5, "The Necromancer");
        Combat.Menu();
        UI.Keypress(new List<int> { 0,1,0,0,0,0,0,0,0,3,0,1 }, new List<string>
        {
            "",
            Color.DEATH,"The ","Necromancer ","lies dead in front of you",
            "",
            "As you catch your breath, the corpse's appearance slowly changes",
            "",
            "When it is finished changing, itresembles a long dead towsperson you knew as a child",
            "",
            "You hear someone behind you",
            "",
            Color.SPEAK,Color.DEATH,Color.SPEAK," ","'Did you think it would be that easy? What part of Master of ","","Death",""," do you not understand?'","",
            "",
            Color.DEATH,"Now you will feel my true ","power ","",

        });
        Dungeon.Summon(Dungeon.necromancer6,"The Necromancer");
        Combat.Menu();
        UI.Keypress(new List<int> { 1, 0, 1 }, new List<string>
        {
            Color.DEATH,"You have beaten the ","Necromancer"," and for now, the game",
            "",
            Color.HEALTH,"","Check back soon","! As you read this I'm hard at work adding more dungeons, monsters and Items.",

        });
        Environment.Exit(0);
    }
}