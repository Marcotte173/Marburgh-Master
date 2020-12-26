using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
public class ChestRoom : Room
{
    bool key = false;
    public ChestRoom()
    : base()
    {
        resetable = false;
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found a chest!" };
        name = $"Chest";
    }
    internal override void Explore()
    {
        for (int i = 0; i < Create.p.Drops.Count; i++)
        {
            if (Create.p.Drops[i].name == "Chest Key" && Create.p.Drops[i].amount > 0) key = true;
        }
        UI.Choice(new List<int> { 0, 0, 0, 0, 1, 1, 1 }, new List<string>
            {
                "A large chest of goods with a sturdy lock sits here.",
                "The goblins haven't managed to bypass the lock yet",
                "An old goblin dagger sticks out of the top of the chest where they attempted to create a new opening.",
                "",
                Color.DAMAGE,"You could ", "bash"," the lock, but risk destroying the contents",
                Color.ABILITY,"You could"," pick"," the lock, but in the time it takes, more monsters may find you",
                Color.NAME,"If only you had a"," key","!"
            }, new List<string> { "ash the lock", "ick the lock", "ey" }, new List<string> { Color.DAMAGE + "B" + Color.RESET, Color.ABILITY + "P" + Color.RESET, Color.NAME + "K" + Color.RESET });
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "b")
        {
            Console.Clear();
            List<int> bashColourArray = new List<int> { };
            List<string> bashList = new List<string> { };
            bashColourArray.Add(0);
            bashList.Add("");
            bool success = Return.RandomInt(1, 101) <= 30;
            if (success)
            {
                bashColourArray.Add(1);
                bashList.Add(Color.XP);
                bashList.Add("");
                bashList.Add("Success! ");
                bashList.Add("");                
            }
            else
            {
                bashColourArray.Add(1);
                bashList.Add(Color.DAMAGE);
                bashList.Add("");
                bashList.Add("Failure!");
                bashList.Add("");
                bashColourArray.Add(0);
                bashList.Add("");
                bashColourArray.Add(0);
                bashList.Add("It looks like the valuables inside were fragile indeed");
                bashColourArray.Add(0);
                bashList.Add("Oh well, maybe next time");
            }
            ActionWait(bashColourArray, bashList, Color.DAMAGE + "BLAM!" + Color.RESET, null);
            if(success)Receive();
        }
        else if (choice == "p")
        {
            Console.Clear();
            List<int> pickColourArray = new List<int> { };
            List<string> pickList = new List<string> { };
            pickColourArray.Add(0);
            pickList.Add("");
            bool success = Return.RandomInt(1, 101) <= 50;
            bool summon = Return.RandomInt(1, 101) <= 15;
            if (success && !summon)
            {
                pickColourArray.Add(1);
                pickList.Add(Color.XP);
                pickList.Add("");
                pickList.Add("Success! ");
                pickList.Add("");
                
            }
            else if (success && summon)
            {
                pickColourArray.Add(1);
                pickList.Add(Color.XP);
                pickList.Add("");
                pickList.Add("You got in! ");
                pickList.Add("");
                pickColourArray.Add(1);
                pickList.Add(Color.DAMAGE);
                pickList.Add("That took a while though, it looks like ");
                pickList.Add("someone ");
                pickList.Add("found you!");
            }
            else if (!success && summon)
            {
                pickColourArray.Add(1);
                pickList.Add(Color.DAMAGE);
                pickList.Add("");
                pickList.Add("Failure!");
                pickList.Add("");
                pickColourArray.Add(0);
                pickList.Add("");
                pickColourArray.Add(0);
                pickList.Add("Try as you might, lack lock is not going to budge!");
                pickColourArray.Add(1);
                pickList.Add(Color.DAMAGE);
                pickList.Add("That took a while though, it looks like ");
                pickList.Add("someone ");
                pickList.Add("found you!");
            }
            else
            {
                pickColourArray.Add(1);
                pickList.Add(Color.DAMAGE);
                pickList.Add("");
                pickList.Add("Failure!");
                pickList.Add("");
                pickColourArray.Add(0);
                pickList.Add("");
                pickColourArray.Add(0);
                pickList.Add("Try as you might, that lock is not going to budge!");
            }
            ActionWait(pickColourArray, pickList, Color.SHIELD + "*Tick* *Tick*" + Color.RESET, null);
            if (success) Receive();
            if (summon) Summon(1);
        }
        else if (choice == "k" && key == true)
        {
            ActionWait(new List<int> {1}, new List<string>
            {
                Color.XP,
                "",
                "Success!",
                ""
            }, Color.NAME + "*Click*" + Color.RESET, null);
            Thread.Sleep(300);
            Receive();
        }
        else if (choice == "k" && key == false)
        {
            UI.Keypress(new List<int> { 1 }, new List<string>
            {
                Color.NAME, "You don't have a ", "key", "!"
            });
            Explore();
        }
        else if (choice == "9")
        {
            CharacterSheet.Display();
            Explore();
        }
        else if (choice == "0")
        {
            
        }
        else Explore(); 
        visited = true;
    }

    private void Receive()
    {
        int treasure = Return.RandomInt(0, 3);
        if(treasure == 0)
        {
            int goldAdd = Return.RandomInt(60, 90) + Return.RandomInt(20, 40) * global::Explore.dungeon.rewardMod * (1 + Create.p.MainHand.gold);
            UI.Keypress(new List<int> { 1 }, new List<string>
            {
                Color.GOLD, "You find ", goldAdd.ToString(), " gold!"
            });
            Create.p.Gold += goldAdd;
        }
        else if(treasure == 1)
        {
            Armor armor = Equipment.armorList[Return.RandomInt(global::Explore.dungeon.rewardMod, global::Explore.dungeon.rewardMod*2)];
            if (UI.Confirm(new List<int> { 1, 1 }, new List<string>
                {
                    Color.ITEM, "You find some ", armor.Name, " armor!",
                    Color.SPEAK, "Would you like to", " equip ","it?",
                }))
            {
                Create.p.Equip(armor);
            }
        }
        else if (treasure == 2)
        {
            int weaponType = Return.RandomInt(0,5);
            Equipment[] list = new Equipment[8] ;
            if (weaponType == 0) list = Equipment.bluntList;
            else if (weaponType == 1) list = Equipment.daggerList;
            else if (weaponType == 2) list = Equipment.magicList;
            else if (weaponType == 3) list = Equipment.shieldList;
            else list = Equipment.swordList;
            Equipment weapon = list[Return.RandomInt(global::Explore.dungeon.rewardMod, global::Explore.dungeon.rewardMod * 2)];
            if (UI.Confirm(new List<int> { 1, 1 }, new List<string>
            {
                Color.ITEM, "You find a ", weapon.Name, "!",
                Color.SPEAK, "Would you like to", " equip ","it?",
            }))
            {
                Create.p.Equip(weapon);
            }
        }        
    }
    public override List<string> Flavor
    {
        get
        {
            if (visited) return new List<string> { $"You see chest. Having spent enough time on it, you decide to move on" };
            else return flavor;
        }
    }
}