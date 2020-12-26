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
        Utilities.Buttons(Button.listOfUpgradeOptions);
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
        foreach (Button b in Button.listOfCraftOptions) b.active = false;
        CheckSavageDagger();
        CheckSavageWand();
        CheckMaul();
        CheckSword();
        CheckOrb();
        CheckCleaver();
        if(!Button.savageDaggerButton.active && !Button.savageWandButton.active && !Button.maulButton.active&& !Button.swordButton.active&& !Button.orbButton.active&& !Button.cleaverButton.active)
        {
            UI.Keypress(new List<int> { 2 }, new List<string>
            {
                Color.RAREDROP,Color.BURNING,"You don't have the required ","materials"," to build a ","weapon","!"
            });
        }
        else
        {
            Console.Clear();
            Utilities.Buttons(Button.listOfCraftOptions);
            UI.Choice(new List<int> { 1, 0, 0 }, new List<string>
            {
                Color.CRIT,"What ","Weapon"," would you like to create?",
                "",
                "[0] to return"
            },
            Button.list1, Button.button1);
            string choice = Return.Option();
            if (choice == "0") Craft.Menu();
            else if (choice == "9") CharacterSheet.Display();
            else if (choice == "1" && Button.savageDaggerButton.active)
            {
                if (UI.Confirm(new List<int> { 1 }, new List<string>
                {
                    Color.BURNING, "Would you like to create the ", "Savage Dagger", "?"
                }))
                {
                    UI.Keypress(new List<int> { 0, 0, 1 }, new List<string>
                    {
                        "Success!",
                        "",
                        Color.BURNING, $"You have created the ", "Savage Dagger", "!"
                    });
                    Create.p.Equip(Equipment.savageDagger);
                    Create.p.RemoveDrop(DropList.savageOrcFang, 1);
                    Create.p.RemoveDrop(DropList.slime, 2);
                }
            }    
            else if (choice == "2" && Button.savageWandButton.active)
            {
                if (UI.Confirm(new List<int> { 1 }, new List<string>
                {
                    Color.BURNING, "Would you like to create the ", "Savage Wand", "?"
                }))
                {
                    UI.Keypress(new List<int> { 0, 0, 1 }, new List<string>
                    {
                        "Success!",
                        "",
                        Color.BURNING, $"You have created the ", "Savage Wand", "!"
                    });
                    Create.p.Equip(Equipment.savageWand);
                    Create.p.RemoveDrop(DropList.savageOrcFang, 1);
                    Create.p.RemoveDrop(DropList.batBrain, 2);
                }     
            }
            else if (choice == "3" && Button.maulButton.active)
            {
                if (UI.Confirm(new List<int> { 1 }, new List<string>
                {
                    Color.BURNING, "Would you like to create the ", "Maul of Hope", "?"
                }))
                {
                    UI.Keypress(new List<int> { 0, 0, 1 }, new List<string>
                    {
                        "Success!",
                        "",
                        Color.BURNING, $"You have created the ", "Maul of Hope", "!"
                    });
                    Create.p.Equip(Equipment.maul);
                    Create.p.RemoveDrop(DropList.spiderEgg, 1);
                    Create.p.RemoveDrop(DropList.bearPaw, 1);
                }   
            }
            else if (choice == "4" && Button.swordButton.active)
            {
                if (UI.Confirm(new List<int> { 1 }, new List<string>
                {
                    Color.BURNING, "Would you like to create the ", "Sword of Knowledge", "?"
                }))
                {
                    UI.Keypress(new List<int> { 0, 0, 1 }, new List<string>
                    {
                        "Success!",
                        "",
                        Color.BURNING, $"You have created the ", "Sword of Knowledge", "!"
                    });
                    Create.p.Equip(Equipment.sword);
                    Create.p.RemoveDrop(DropList.necromancerBrain, 1);
                    Create.p.RemoveDrop(DropList.bone, 1);
                    Create.p.RemoveDrop(DropList.ghoulFang, 1);
                }
            }
            else if (choice == "5" && Button.orbButton.active)
            {
                if (UI.Confirm(new List<int> { 1 }, new List<string>
                {
                    Color.BURNING, "Would you like to create the ", "Orb of Zorb", "?"
                }))
                {
                    UI.Keypress(new List<int> { 0, 0, 1 }, new List<string>
                    {
                        "Success!",
                        "",
                        Color.BURNING, $"You have created the ", "Orb of Zorb", "!"
                    });
                    Create.p.Equip(Equipment.orb);
                    Create.p.RemoveDrop(DropList.necromancerBrain, 1);
                    Create.p.RemoveDrop(DropList.spiderEgg, 1);
                }
            }
            else if (choice == "6" && Button.cleaverButton.active)
            {
                if (UI.Confirm(new List<int> { 1 }, new List<string>
                {
                    Color.BURNING, "Would you like to create the ", "Haunted Cleaver", "?"
                }))
                {
                    UI.Keypress(new List<int> { 0, 0, 1 }, new List<string>
                    {
                        "Success!",
                        "",
                        Color.BURNING, $"You have created the ", "Haunted Cleaver", "!"
                    });
                    Create.p.Equip(Equipment.cleaver);
                    Create.p.RemoveDrop(DropList.brokenCleaver, 1);
                    Create.p.RemoveDrop(DropList.mguffin, 1);
                }  
            }
            Menu();
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
    private static void CheckSavageDagger()
    {
        bool haveFang = false;
        bool haveSlime = false;
        for (int i = 0; i < Create.p.Drops.Count; i++)
        {
            if (Create.p.Drops[i].name == "Savage Orc Fang" ) haveFang = true;
            if (Create.p.Drops[i].name == "Slime" && Create.p.Drops[i].amount >= 2) haveSlime = true;
        }
        if (haveFang && haveSlime) Button.savageDaggerButton.active = true ;
    }
    private static void CheckSavageWand()
    {
        bool haveFang = false;
        bool haveBrain = false;
        for (int i = 0; i < Create.p.Drops.Count; i++)
        {
            if (Create.p.Drops[i].name == "Savage Orc Fang") haveFang = true;
            if (Create.p.Drops[i].name == "Bat Brain" && Create.p.Drops[i].amount >= 2) haveBrain = true;
        }
        if( haveFang && haveBrain) Button.savageWandButton.active = true;
    }
    private static void CheckMaul()
    {
        bool haveEgg = false;
        bool havePaw = false;
        for (int i = 0; i < Create.p.Drops.Count; i++)
        {
            if (Create.p.Drops[i].name == "Spider Egg") haveEgg = true;
            if (Create.p.Drops[i].name == "Bear Paw" ) havePaw = true;
        }
        if (haveEgg && havePaw) Button.maulButton.active = true;
    }
    private static void CheckSword()
    {
        bool haveBrain = false;
        bool haveBone = false;
        bool haveGhoulFang = false;

        for (int i = 0; i < Create.p.Drops.Count; i++)
        {
            if (Create.p.Drops[i].name == "Necromancer Brain") haveBrain = true;
            if (Create.p.Drops[i].name == "Old Bone" ) haveBone = true;
            if (Create.p.Drops[i].name == "Ghoul Fang") haveGhoulFang = true;
        }
        if (haveBrain && haveGhoulFang && haveBone) Button.swordButton.active = true;
    }
    private static void CheckOrb()
    {
        bool haveBrain = false;
        bool haveEgg = false;
        for (int i = 0; i < Create.p.Drops.Count; i++)
        {
            if (Create.p.Drops[i].name == "Necromancer Brain") haveBrain = true;
            if (Create.p.Drops[i].name == "Spider Egg") haveEgg = true;
        }
        if (haveBrain && haveEgg) Button.orbButton.active = true;
    }
    private static void CheckCleaver()
    {
        bool haveCleaver = false;
        bool haveMguffin = false;
        for (int i = 0; i < Create.p.Drops.Count; i++)
        {
            if (Create.p.Drops[i].name == "Broken Cleaver") haveCleaver = true;
            if (Create.p.Drops[i].name == "Mguffin" ) haveMguffin = true;
        }
        if (haveCleaver && haveMguffin) Button.cleaverButton.active = true;
    }
}