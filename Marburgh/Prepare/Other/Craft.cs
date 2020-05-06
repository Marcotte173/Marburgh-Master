using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Craft:Location
{    
    public Craft()
    : base() { }

    public override void Menu()
    {
        Console.Clear();
        UI.Choice(new List<int> { 0, 0, 0, 0, 0 }, new List<string>
        {
            "You step closer to the elaborate machine",
            "",
            "You doubt you'll ever figure out ALL of its secrets",
            "",
            "But hopefully more will become apparent over time"
        },
        new List<string> { "pgrade"}, new List<string> { Colour.ITEM + "U" + Colour.RESET, });
        string choice = Return.Option();
        if (choice == "u") Upgrade();
        else if (choice == "b" && GameState.BossWeapon) BossWeapon();
        else if (choice == "0") Utilities.ToTown();
        else if (choice == "9") CharacterSheet.Display();
        else if (choice == "x")
        {
            Create.p.Drops.Add(new Drop("Monster Tooth", 1, 0));
            Create.p.Drops.Add(new Drop("Monster Eye", 1, 0));
            Menu();
        }
        else Menu();
    }

    private void BossWeapon()
    {
        
    }

    private void Upgrade()
    {
        List<string> upgradeList = new List<string> { };
        List<string> upgradeButton = new List<string> { };
        if (Create.p.MainHand.Upgraded == false)
        {
            upgradeList.Add(Create.p.MainHand.Name);
            upgradeButton.Add(Colour.ITEM + "1" + Colour.RESET);
        }
        if (Create.p.OffHand.Upgraded == false)
        {
            upgradeList.Add(Create.p.OffHand.Name);
            upgradeButton.Add(Colour.ITEM + "2" + Colour.RESET);
        }
        if (Create.p.Armor.Upgraded == false)
        {
            upgradeList.Add(Create.p.Armor.Name);
            upgradeButton.Add(Colour.ITEM + "3" + Colour.RESET);       
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
            else if (choice == "3" && Create.p.Armor.Upgraded == false) if (Check(Create.p.Armor))
            {
                if (Check(Create.p.Armor)) Success(Create.p.Armor.Name);
                    else NoMats();
            }
            else if (choice == "0") Location.list[8].Go();
            else if (choice == "9") CharacterSheet.Display();
            else Menu();
        }
    }

    private void Success(string name)
    {
        UI.Keypress(new List<int> { 0,0,0 }, new List<string>
        {
            "Success!",
            "",
            $"You have upgraded your {name}"
        });
    }

    void NoMats()
    {
        UI.Keypress(new List<int> { 0 }, new List<string>
        {
            "You don't have the materials!"
        });
    }

    private bool Check(Armor armor)
    {
        bool haveTeeth = false;
        bool haveEyes = false;
        for (int i = 0; i < Create.p.Drops.Count; i++)
        {
            if (Create.p.Drops[i].name == "Monster Eye" && Create.p.Drops[i].amount == armor.MonsterEye[armor.Level]) haveEyes = true;
            if (Create.p.Drops[i].name == "Monster Tooth" && Create.p.Drops[i].amount == armor.MonsterTooth[armor.Level]) haveTeeth = true;
        }
        if (haveTeeth && haveEyes)
        {
            for (int i = 0; i < Create.p.Drops.Count; i++)
            {
                if (Create.p.Drops[i].name == "Monster Eye")
                {
                    Create.p.Drops[i].amount -= armor.MonsterEye[armor.Level];
                    if (Create.p.Drops[i].amount <= 0) Create.p.Drops.Remove(Create.p.Drops[i]);
                }
               if (Create.p.Drops[i].name == "Monster Tooth")
                {
                    Create.p.Drops[i].amount -= armor.MonsterTooth[armor.Level];
                    if (Create.p.Drops[i].amount <= 0) Create.p.Drops.Remove(Create.p.Drops[i]);
                }
            }
            return true;
        }
        else return false;
    }

    private bool Check(Weapon weapon)
    {
        bool haveTeeth = false;
        bool haveEyes = false;
        for (int i = 0; i < Create.p.Drops.Count; i++)
        {
            if (Create.p.Drops[i].name == "Monster Eye" && Create.p.Drops[i].amount == weapon.MonsterEye[weapon.Level]) haveEyes = true;
            if (Create.p.Drops[i].name == "Monster Tooth" && Create.p.Drops[i].amount == weapon.MonsterTooth[weapon.Level]) haveTeeth = true;
        }
        if (haveTeeth && haveEyes)
        {
            for (int i = 0; i < Create.p.Drops.Count; i++)
            {
                if (Create.p.Drops[i].name == "Monster Eye")
                {
                    Create.p.Drops[i].amount -= weapon.MonsterEye[weapon.Level];
                    if (Create.p.Drops[i].amount <= 0) Create.p.Drops.Remove(Create.p.Drops[i]);
                }
                if (Create.p.Drops[i].name == "Monster Tooth")
                {
                    Create.p.Drops[i].amount -= weapon.MonsterTooth[weapon.Level];
                    if (Create.p.Drops[i].amount <= 0) Create.p.Drops.Remove(Create.p.Drops[i]);
                }
            }
            return true;
        }
        else return false;
    }
}