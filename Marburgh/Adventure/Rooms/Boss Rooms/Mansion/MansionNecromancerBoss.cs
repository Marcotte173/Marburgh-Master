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
        Dungeon.Summon(new Necromancer(5), "The Necromancer");
        Combat.Menu();
        UI.Keypress(new List<int> { 0,1,0,0,0,0,0,0,0,3,0,1 }, new List<string>
        {
            "",
            Color.DEATH,"The ","Necromancer ","lies dead in front of you",
            "",
            Color.DEATH,"As you catch your breath, the ","corpse's"," appearance slowly changes",
            "",
            Color.NAME,"When it is finished changing, it resembles a long dead ","towsperson"," you knew as a child",
            "",
            "You hear someone speak behind you",
            "",
            Color.SPEAK,Color.DEATH,Color.SPEAK," ","'Did you think it would be that easy? What part of ","","Master of Death",""," do you not understand?'","",
            "",
            Color.DEATH,"Now you will feel my true ","power ","",

        });
        Dungeon.Summon(new Necromancer(5), "The Necromancer");
        Combat.Menu();
        UI.Keypress(new List<int> {1,0,1,0,2,0,1,0,1 }, new List<string>
        {
            Color.DEATH,"The ","Necromancer"," falls to the ground, defeated",
            "",
            Color.HEALTH,"You return to town,","victorious","",
            "",
            Color.NAME,Color.NAME,"Your ","family"," avenged, and your ","town"," safe, you retire",
            "",
            Color.GOLD,"And invest in a ","Hockey team"," your uncle just acquired",
            "",
            Color.HEALTH,"","The End",""
        });
        UI.Keypress(new List<int> { 1 }, new List<string>
        {
            Color.DEATH,"","Or is it?",""
        });
        UI.Keypress(new List<int> { 1,1,1 }, new List<string>
        {
            Color.HEALTH,"","I mean, probably","",
            "",
            Color.NAME,"For"," now",", at least",
            "",
            Color.TIME,"Who knows what the ","future"," holds?"
        });
        Environment.Exit(0);
    }
}