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
        else if (choice == "x")
        {
            Create.p.Drops.Add(AdventureItems.monsterEye.Copy());
            Create.p.Drops.Add(AdventureItems.monsterTooth.Copy());
            Menu();
        }
        else Menu();
    }

    private static void BossWeapon()
    {
        
    }

    private static void Upgrade()
    {
        List<string> upgradeList = new List<string> { };
        List<string> upgradeButton = new List<string> { };
        if (Create.p.MainHand.Upgraded == false)
        {
            upgradeList.Add(Create.p.MainHand.Name);
            upgradeButton.Add(Color.ITEM + "1" + Color.RESET);
        }
        if (Create.p.OffHand.Upgraded == false)
        {
            upgradeList.Add(Create.p.OffHand.Name);
            upgradeButton.Add(Color.ITEM + "2" + Color.RESET);
        }
        if (Create.p.Armour.Upgraded == false)
        {
            upgradeList.Add(Create.p.Armour.Name);
            upgradeButton.Add(Color.ITEM + "3" + Color.RESET);       
        }
        if (upgradeList.Count == 0)
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
                "What would you like to upgrade?",
            },
            upgradeList, upgradeButton);
            string choice = Return.Option();
            if (choice == "1" && Create.p.MainHand.Upgraded == false)
            {
                if (Check(Create.p.MainHand)) Success(Create.p.MainHand.Name);
                else NoMats();
            }
            else if (choice == "2" && Create.p.OffHand.Upgraded == false)
            {
                if (Check(Create.p.OffHand)) Success(Create.p.OffHand.Name);
                else NoMats();
            }
            else if (choice == "3" && Create.p.Armour.Upgraded == false) if (Check(Create.p.Armour))
            {
                if (Check(Create.p.Armour)) Success(Create.p.Armour.Name);
                    else NoMats();
            }
            else if (choice == "0") Menu();
            else if (choice == "9") CharacterSheet.Display();
            else Menu();
        }
    }

    private static void Success(string name)
    {
        UI.Keypress(new List<int> { 0,0,0 }, new List<string>
        {
            "Success!",
            "",
            $"You have upgraded your {name}"
        });
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
            if (Create.p.Drops[i].name == "Monster Eye" && Create.p.Drops[i].amount == item.MonsterEye[item.Level]) haveEyes = true;
            if (Create.p.Drops[i].name == "Monster Tooth" && Create.p.Drops[i].amount == item.MonsterTooth[item.Level]) haveTeeth = true;
        }
        if (haveTeeth && haveEyes)
        {
            for (int i = 0; i < Create.p.Drops.Count; i++)
            {
                if (Create.p.Drops[i].name == "Monster Eye")
                {
                    Create.p.Drops[i].amount -= item.MonsterEye[item.Level];
                    if (Create.p.Drops[i].amount <= 0) Create.p.Drops.Remove(Create.p.Drops[i]);
                }
               if (Create.p.Drops[i].name == "Monster Tooth")
                {
                    Create.p.Drops[i].amount -= item.MonsterTooth[item.Level];
                    if (Create.p.Drops[i].amount <= 0) Create.p.Drops.Remove(Create.p.Drops[i]);
                }
            }
            return true;
        }
        else return false;
    }    
}