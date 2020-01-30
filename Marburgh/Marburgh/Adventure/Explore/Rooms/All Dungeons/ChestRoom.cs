using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
public class ChestRoom : Room
{
    Player p = Create.p;
    bool key = false;
    public ChestRoom(int size, int tier)
    : base(size, tier)
    {
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found a chest!" };
        name = $"Chest";
    }
    internal override void Explore()
    {
        for (int i = 0; i < p.Drops.Count; i++)
        {
            if (p.Drops[i].name == "Chest Key" && p.Drops[i].amount > 0) key = true;
        }
        UI.Choice(new List<int> { 0, 0, 0, 0, 1, 1, 1 }, new List<string>
            {
                "A large chest of goods with a sturdy lock sits here.",
                "The goblins haven't managed to bypass the lock yet",
                "An old goblin dagger sticks out of the top of the chest where they attempted to create a new opening.",
                "",
                Colour.DAMAGE,"You could ", "bash"," the lock, but risk destroying the contents",
                Colour.ABILITY,"You could"," pick"," the lock, but in the time it takes, more monsters may find you",
                Colour.NAME,"If only you had a"," key","!"
            }, new List<string> { "ash the lock", "ick the lock", "ey" }, new List<string> { Colour.DAMAGE + "B" + Colour.RESET, Colour.ABILITY + "P" + Colour.RESET, Colour.NAME + "K" + Colour.RESET });
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "b")
        {
            Console.Clear();
            List<int> bashColourArray = new List<int> { };
            List<string> bashList = new List<string> { };
            bashColourArray.Add(0);
            bashList.Add("");
            if (Return.RandomInt(1,101) <= 50)
            {
                bashColourArray.Add(1);
                bashList.Add(Colour.XP);
                bashList.Add("");
                bashList.Add("Success! ");
                bashList.Add("");
                //Treasure
            }
            else
            {
                bashColourArray.Add(1);
                bashList.Add(Colour.DAMAGE);
                bashList.Add("");
                bashList.Add("Failure!");
                bashList.Add("");
                bashColourArray.Add(0);
                bashList.Add("");
                bashColourArray.Add(0);
                bashList.Add("It looks like the valuables inside were fragile indeed.Oh well, maybe next time");
            }
            ActionWait(bashColourArray, bashList, Colour.DAMAGE + "BLAM!" + Colour.RESET, null);
        }
        else if (choice == "p")
        {
            Console.Clear();
            List<int> pickColourArray = new List<int> { };
            List<string> pickList = new List<string> { };
            pickColourArray.Add(0);
            pickList.Add("");
            int pickRoll = Return.RandomInt(1, 101);
            if (pickRoll <= 50)
            {
                pickColourArray.Add(1);
                pickList.Add(Colour.XP);
                pickList.Add("");
                pickList.Add("Success! ");
                pickList.Add("");
                //Treasure
            }
            else if (pickRoll > 50 && pickRoll <= 66)
            {
                Console.WriteLine("You got in!\n\n");
                Thread.Sleep(300);
                //Treasure
                Utilities.Keypress();
                Console.WriteLine("\nThat took a while though, it looks like someone found you!");
                //Summon Monsters, fight
            }
            else
            {
                Console.WriteLine("Failure!");
                Thread.Sleep(300);
                Console.WriteLine("Not only could you not get in, you took so long that someone found you!");
                //Summon Monsters, fight
            }
        }
        else if (choice == "k" && key == true)
        {
            Console.Clear();
            Write.ColourText(Colour.NAME, "CLICK!");
            Write.DotDotDot();
            Console.WriteLine("\n\n\n\n\n\n\n");
            Console.WriteLine("Success!\n\n");
            Thread.Sleep(300);
            Console.WriteLine("Inside you find a bunch of treasure, to be described later!");
            Utilities.Keypress();
        }
        else if (choice == "k" && key == false)
        {
            UI.Keypress(new List<int> { 1 }, new List<string>
            {
                Colour.NAME, "You don't have a ", "key", "!"
            });
            Explore();
        }
        else if (choice == "r")
        {
            
        }
        else if (choice == "x")
        {
            p.Drops.Add(new Drop("Chest Key", 1, true));
            Explore();
        }
        else Explore();
        visited = true;
        Location.list[10].Go();
    }     
}