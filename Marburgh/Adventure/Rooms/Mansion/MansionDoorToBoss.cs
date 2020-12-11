using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MansionDoorToBoss : Room
{
    public bool open;
    public MansionDoorToBoss()
    : base()
    {
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have returned to the green wall of fog" };
        name = "Door";
        skipExplore = true;
    }

    internal override void Explore()
    {
        Console.Clear();
        if (open) GreenFog();
        else Door();
        
    }

    private void GreenFog()
    {
        Console.Clear();
        UI.Choice(new List<int> { 0, 1, 0, 1, 0, 0,0,0}, new List<string>
        {
            "",
            Color.DEATH,"Behind the door is a thick ","fog","",
            "",
            Color.DEATH,"On the other side of the room, through the fog, is the door to the ","Necromancer's"," chambers",
            "",
            "You can tell this is no ordinary fog",
            "",
            "You see the corpses of creatures who have tried to cross the room strewn out across the floor"
        }, new List<string> { "ross the fog to the door", "eturn to the foyer" }, new List<string> { Color.ITEM + "C" + Color.RESET, Color.ITEM + "R" + Color.RESET });
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "c")
        {
            bool hasNecklace = false;
            foreach (Drop d in Create.p.Drops)
            {
                if (d.name == DropList.mansionMedalion.name)
                {
                    hasNecklace = true;
                    break;
                }
            }
            if (Create.p.Health <= 0)
            {
                UI.Keypress(new List<int> { 0,1,0,1,0,1 }, new List<string>
                {
                    "",
                    Color.DEATH,"You feel a slight ","tickle ","as the fog dances around you",
                    "",
                    Color.DEATH,"The fog is reinforcing your ","undead ","body",
                    "",
                    Color.DEATH,"By the time you reach the door you are at ","full"," health! "
                });
                Dungeon.mansionNecromancerBoss.Explore();
            }
            else if (hasNecklace)
            {
                UI.Keypress(new List<int> { 0, 2, 0, 1, 0, 0}, new List<string>
                {
                    "",
                    Color.DEATH,Color.CRIT,"You hear an ear shattering noise as the ","fog"," in the room starts to swirl around the ","necklace","",
                    "",
                    Color.CRIT,"As it gets closer, the ","necklace"," seems to vacum it up",
                    "",
                    "With no further impediments, you reach the door "
                });
                Dungeon.mansionNecromancerBoss.Explore();
            }
            else
            {
                UI.Keypress(new List<int> { 1, 0,  1 }, new List<string>
                {
                    Color.DEATH,"You immediately start choking as you enter the ","fog","",
                    "",
                    Color.DEATH,"The last thing you hear before you die is the mocking laugh of ","Toliax",""
                });
                Monster g = new Goblin(3, 3, 3, 3);
                g.Name = Color.DEATH + "Death Fog"+Color.RESET;
                Create.p.Death(g);
            }
        }
        else if (choice == "9")
        {
            CharacterSheet.Display();
            Explore();
        }
        else if (choice == "r") global::Explore.dungeon.layout[1].room.Explore();
        else GreenFog();

    }

    private void Door()
    {
        Console.Clear();
        if (Create.p.Health > 0)
        {
            UI.Choice(new List<int> { 0,1,0,0,0,0 }, new List<string>
            {
                "",
                Color.DEATH,"You see a large door carved in the image of ","Toliax",".",
                "",
                "It is large, foreboding, radiating evil and quite possible sentient, but it DOES have a handle....",
                "",
                "You can sense it waiting for something",
            }, new List<string> { "pen the door", "eturn to the foyer" }, new List<string> { Color.ITEM + "O" + Color.RESET, Color.ITEM + "R" + Color.RESET });
            string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
            if (choice == "o")
            {
                int hpLoss = Create.p.Health / 2 - 1;
                UI.Keypress(new List<int> { 1,0,0,0,0,0,1 }, new List<string>
                {
                    Color.DAMAGE,"As the door opens, the door takes a giant ","BITE"," out of you arm!",
                    "",
                    "I mean in fairness, it IS an evil door",
                    "",
                    "You can sense that the door is somehow amused",
                    "",
                    Color.DAMAGE,"You lose ",hpLoss.ToString()," hitpoints"
                });
                Create.p.TakeDamage(hpLoss);
                open = true;
                Explore();
            }
            else if (choice == "r") global::Explore.dungeon.layout[1].room.Explore();
            else Door();
        }
        else
        {
            UI.Keypress(new List<int> { 0, 1, 0, 0, 0, 0 }, new List<string>
            {
                "",
                Color.DEATH,"You see a large door carved in the image of ","Toliax",".",
                "",
                "It is large, foreboding, radiating evil and quite possible sentient, but it DOES have a handle....",
                "",
                "You can sense it waiting for something",
            });
            UI.Keypress(new List<int> { 1 }, new List<string>
            {
                    Color.DEATH,"Sensing the presence of ","death",", the door opens before your hand reaches it",
            });
            open = true;
            Explore();
        }
    }
}