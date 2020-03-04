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
        else if (choice == "r") Utilities.ToTown();
        else if (choice == "c") CharacterSheet.Display();
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
            upgradeButton.Add(Colour.ITEM + upgradeList.Count + Colour.RESET);
        }
        if (Create.p.OffHand.Upgraded == false)
        {
            upgradeList.Add(Create.p.OffHand.Name);
            upgradeButton.Add(Colour.ITEM + upgradeList.Count + Colour.RESET);
        }
        if (Create.p.Armor.Upgraded == false)
        {
            upgradeList.Add(Create.p.Armor.Name);
            upgradeButton.Add(Colour.ITEM + upgradeList.Count + Colour.RESET);       
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
        }
    }
}