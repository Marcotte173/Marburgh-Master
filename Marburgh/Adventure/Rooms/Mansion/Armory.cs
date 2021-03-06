﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Armory : Room
{
    public Armory()
    : base()
    {
        resetable = false;
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found the Armory" };
        name = $"Armory";
    }

    internal override void Explore()
    {
        Console.Clear();
        visited = true;
        UI.Choice(new List<int> {0,1,0,0,0,0,0,2  }, new List<string>
        {
            "",
            Color.ITEM,"You eneter a small room filled with ","equipment","",
            "",
            "Most of it is in disrepair, but if you search thorugh the piles you might fight a gem",
            "",
            "You hear footsteps down the hallway. Someone might be coming!",
            "",
            Color.ITEM,Color.ITEM,"You have time to search through either the pile of ","armor"," or the pile of ","weapons",""
        }, new List<string> { "eapon Pile", "rmor Pile" }, new List<string> { Color.ITEM + "W" + Color.RESET, Color.ITEM + "A" + Color.RESET });
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "w")
        {
            int weaponType = Return.RandomInt(0, 5);
            Equipment[] list = new Equipment[8];
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
        else if (choice == "9")
        {
            CharacterSheet.Display();
            Explore();
        }
        else if (choice == "a")
        {
            Armor armor = Equipment.armorList[Return.RandomInt(global::Explore.dungeon.rewardMod, global::Explore.dungeon.rewardMod * 2)];
            if (UI.Confirm(new List<int> { 1, 1 }, new List<string>
                {
                    Color.ITEM, "You find some ", armor.Name, " armor!",
                    Color.SPEAK, "Would you like to", " equip ","it?",
                }))
            {
                Create.p.Equip(armor);
            }
        }
        else Explore();
        visited = true;
    }

    public override List<string> Flavor
    {
        get
        {
            if (visited) return new List<string> { $"You see an armory. You have already picked it clean of any useful items" };
            else return flavor;
        }
    }
}