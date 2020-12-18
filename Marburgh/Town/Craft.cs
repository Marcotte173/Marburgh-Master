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
        Utilities.Buttons(Button.listOfCraftOptions);
        UI.Choice(new List<int> { 0, 0, 0, 0, 0 }, new List<string>
        {
            "You step closer to the elaborate machine",
            "",
            "You doubt you'll ever figure out ALL of its secrets",
            "",
            "But hopefully more will become apparent over time"
        },
        Button.list1, Button.button1);
        string choice = Return.Option();
        if (choice == "u") Upgrade();
        else if (choice == "c" && Button.bossWeapons.active) BossWeapon();
        else if (choice == "0") Utilities.ToTown();
        else if (choice == "9") CharacterSheet.Display();
        else Menu();
    }

    private static void BossWeapon()
    {
        if (CheckFang())
        {
            if (UI.Confirm(new List<int> { 1 }, new List<string>
            {
                Color.BURNING, "" +
                "Would you like to create the ",
                "Savage Dagger",
                "?"
            }))
            {
                UI.Keypress(new List<int> { 0, 0, 1 }, new List<string>
                {
                    "Success!",
                    "",
                    Color.BURNING,
                    $"You have created the ",
                    "Savage Dagger",
                    "!"
                });
                Create.p.Equip(Dagger.savageDagger);
                for (int i = 0; i < Create.p.Drops.Count; i++)
                {
                    if (Create.p.Drops[i].name == "Savage Orc Fang") Create.p.RemoveDrop(DropList.savageOrcFang, 1);
                    if (Create.p.Drops[i].name == "Slime") Create.p.RemoveDrop(DropList.slime, 2);
                }
            }
        }
        else
        {
            UI.Keypress(new List<int> { 0 }, new List<string>
            {
                "You don't have the materials required to create a weapon"
            });
        }
    }

    private static void Upgrade()
    {
        List<Equipment> list = new List<Equipment> { };
        if (Create.p.MainHand.Upgraded == false && Create.p.MainHand.Level != 0) list.Add(Create.p.MainHand);
        if (Create.p.OffHand.Upgraded == false && Create.p.OffHand.Level != 0) list.Add(Create.p.OffHand);
        if (Create.p.Armor.Upgraded == false && Create.p.Armor.Level != 0) list.Add(Create.p.Armor);
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
            for (int i = 0; i < Create.p.Drops.Count; i++)
            {
                if (Create.p.Drops[i].name == "Monster Eye") Create.p.RemoveDrop(DropList.monsterEye, e.MonsterEye);
                if (Create.p.Drops[i].name == "Monster Tooth") Create.p.RemoveDrop(DropList.monsterTooth, e.MonsterTooth);
            }
            e.Upgrade();
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
    private static bool CheckFang()
    {
        bool haveFang = false;
        bool haveSlime = false;
        for (int i = 0; i < Create.p.Drops.Count; i++)
        {
            if (Create.p.Drops[i].name == "Savage Orc Fang" ) haveFang = true;
            if (Create.p.Drops[i].name == "Slime" && Create.p.Drops[i].amount >= 2) haveSlime = true;
        }
        return haveFang && haveSlime;
    }
}