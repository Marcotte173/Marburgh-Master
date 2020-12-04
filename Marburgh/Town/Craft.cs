using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Craft
{    
    public static void Menu()
    {
        GameState.location = Location.Craft;
        Console.Clear();
        UI.Choice(new List<int> { 0, 0, 0, 0, 0 }, new List<string>
        {
            "You step closer to the elaborate machine",
            "",
            "You doubt you'll ever figure out ALL of its secrets",
            "",
            "But hopefully more will become apparent over time"
        },
        new List<string> { "pgrade"}, new List<string> { Color.ITEM + "U" + Color.RESET, });
        string choice = Return.Option();
        if (choice == "u") Upgrade();
        else if (choice == "b" && GameState.canCraftWeaponsFromBossDrops) BossWeapon();
        else if (choice == "0") Utilities.ToTown();
        else if (choice == "9") CharacterSheet.Display();
        else Menu();
    }

    private static void BossWeapon()
    {
        
    }

    private static void Upgrade()
    {
        List<Equipment> list = new List<Equipment> { };
        if (Create.p.MainHand.Upgraded == false && Create.p.MainHand.Level != 0) list.Add(Create.p.MainHand);
        if (Create.p.OffHand.Upgraded == false && Create.p.OffHand.Level != 0) list.Add(Create.p.OffHand);
        if (Create.p.Armour.Upgraded == false && Create.p.Armour.Level != 0) list.Add(Create.p.Armour);
        if (list.Count == 0)
        {
            UI.Keypress(new List<int> { 0 }, new List<string>
            {
                "You have nothing to upgrade!"
            });
        }
        else
        {
            UI.Choice(new List<int> { 0, }, new List<string>
            {
                ""
            },
            new List<string> { }, null);
            Write.Line(50, 6, "What would you like to upgrade?");
            Write.Line(30, 8, "Item");
            Write.Line(50, 8, "Cost");
            for (int i = 0; i < list.Count; i++) Write.Line(30,10 + i, $"[{i + 1}]{Color.ITEM + list[i].Name + Color.RESET}");
            for (int i = 0; i < list.Count; i++)
            {
                string mEye = (list[i].MonsterEye == 1) ? "Monster Eye" : "Monster Eyes";
                string mTeeth = (list[i].MonsterTooth == 1) ? "Monster Tooth" : "Monster Teeth";
                Write.Line(50, 10 + i, $"{list[i].MonsterEye} {Color.DROP + mEye + Color.RESET}, {list[i].MonsterTooth} {Color.DROP + mTeeth + Color.RESET}");
            }
            int choice = Return.Int();
            if (choice == 0) Menu();
            else if (choice == 9) CharacterSheet.Display();
            else if (choice > 0 && choice <= list.Count)
            {
                if (!list[choice-1].Upgraded)
                {
                    if (Check(list[choice-1])) Confirm(list[choice-1]);
                    else NoMats();
                }
            }       
            else Menu();
        }
    }

    private static void Confirm(Equipment e)
    {
        if (UI.Confirm(new List<int> { 1 }, new List<string> 
        {
            Color.ITEM, "" +
            "Would you like to upgrade the ", 
            $"{e.Name}", 
            "?"
        }))
        {
            UI.Keypress(new List<int> { 0, 0, 0 }, new List<string>
            {
                "Success!",
                "",
                $"You have upgraded your {e.Name}"
            });
            e.Upgrade();
            for (int i = 0; i < Create.p.Drops.Count; i++)
            {
                if (Create.p.Drops[i].name == "Monster Eye") Create.p.Drops[i].amount -= e.MonsterEye;
                if (Create.p.Drops[i].name == "Monster Tooth") Create.p.Drops[i].amount -= e.MonsterTooth;
            }
        }        
    }

    static void NoMats()
    {
        UI.Keypress(new List<int> { 0 }, new List<string>
        {
            "You don't have the materials!"
        });
    }

    private static bool Check(Equipment item)
    {
        bool haveTeeth = false;
        bool haveEyes = false;
        for (int i = 0; i < Create.p.Drops.Count; i++)
        {
            if (Create.p.Drops[i].name == "Monster Eye" && Create.p.Drops[i].amount >= item.MonsterEye) haveEyes = true;
            if (Create.p.Drops[i].name == "Monster Tooth" && Create.p.Drops[i].amount >= item.MonsterTooth) haveTeeth = true;
        }
        return haveEyes && haveTeeth;
    }    
}