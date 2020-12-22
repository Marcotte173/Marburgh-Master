using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Shop 
{
    public static NPC weaponNPC = new NPC("weapon");
    public static NPC armorNPC = new NPC("armor");
    public static NPC magicNPC = new NPC("magic");
    public static NPC itemNPC = new NPC("item");
    static List<Equipment> bluntList = new List<Equipment> { Equipment.bluntList[0], Equipment.bluntList[1], Equipment.bluntList[2], Equipment.bluntList[3], Equipment.bluntList[4], Equipment.bluntList[5], Equipment.bluntList[6], Equipment.bluntList[7] };
    static List<Equipment> swordList = new List<Equipment> { Equipment.swordList[0], Equipment.swordList[1], Equipment.swordList[2], Equipment.swordList[3], Equipment.swordList[4], Equipment.swordList[5], Equipment.swordList[6], Equipment.swordList[7] };
    static List<Equipment> daggerList = new List<Equipment> { Equipment.daggerList[0], Equipment.daggerList[1], Equipment.daggerList[2], Equipment.daggerList[3], Equipment.daggerList[4], Equipment.daggerList[5], Equipment.daggerList[6], Equipment.daggerList[7] };
    static List<Equipment> shieldList = new List<Equipment> { Equipment.shieldList[0], Equipment.shieldList[1], Equipment.shieldList[2], Equipment.shieldList[3], Equipment.shieldList[4], Equipment.shieldList[5], Equipment.shieldList[6], Equipment.shieldList[7] };
    static List<Equipment> armorList = new List<Equipment> { Equipment.armorList[0], Equipment.armorList[1], Equipment.armorList[2], Equipment.armorList[3], Equipment.armorList[4], Equipment.armorList[5], Equipment.armorList[6], Equipment.armorList[7] };
    static List<Equipment> magicList = new List<Equipment> { Equipment.magicList[0], Equipment.magicList[1], Equipment.magicList[2], Equipment.magicList[3], Equipment.magicList[4], Equipment.magicList[5], Equipment.magicList[6], Equipment.magicList[7] };
    public static List<Drop> potionList = new List<Drop> { DropList.potionOfFire, DropList.potionOfLearning, DropList.potionOfLife, DropList.potionOfPower, DropList.potionOfProwess, DropList.potionOfKnowledge };
    public static List<Drop> potionAvailableList = new List<Drop> { };
    public static List<Equipment> itemOffenceList = new List<Equipment> { Equipment.bluntList[0], Equipment.magicList[1], Equipment.daggerList[1], Equipment.bluntList[1], Equipment.swordList[1], Equipment.magicList[2], Equipment.daggerList[2], Equipment.bluntList[2], Equipment.swordList[2] };
    public static List<Equipment> itemOffenceAvailableList = new List<Equipment> {  };
    public static List<Equipment> itemDefenceList = new List<Equipment> { Equipment.armorList[0], Equipment.shieldList[1], Equipment.armorList[1], Equipment.shieldList[2], Equipment.armorList[2] };
    public static List<Equipment> itemDefenceAvailableList = new List<Equipment> {  };
    static int[] upgrade = new int[] { 1000, 3000, 10000, 20000, 35000 };
    static int[] healAdd = new int[] { 3, 5, 7, 10, 15 };
    static int current = 0;
    public static bool weaponJob;
    public static bool armorJob;
    public static bool magicJob;
    public static bool itemJob;
    public static Equipment itemToSell;
    public static Equipment itemToSell2;

    public static void Menu(NPC shopKeep)
    {
        GameState.location = Location.Shop;
        Console.Clear();
        if (shopKeep == magicNPC) Button.healthPotionBuyButton.active = true;
        if (shopKeep == itemNPC && (GameState.phase1b || GameState.phase2a || GameState.phase2b || GameState.phase3)) Button.potionBuyButton.active = true;
        else Button.healthPotionBuyButton.active = false;
        if(GameState.currentJob != null)
        {
            if (shopKeep == itemNPC && GameState.currentJob.location == JobLocation.ItemShop) GameState.currentJob.ButtonCheck();
            else if (shopKeep == weaponNPC && GameState.currentJob.location == JobLocation.WeaponShop) GameState.currentJob.ButtonCheck();
            else if (shopKeep == armorNPC && GameState.currentJob.location == JobLocation.ArmorShop) GameState.currentJob.ButtonCheck();
            else if (shopKeep == magicNPC && GameState.currentJob.location == JobLocation.MagicShop) GameState.currentJob.ButtonCheck();
            else GameState.currentJob.ButtonsOff();
        }
        Utilities.Buttons(Button.listOfShopOptions);
        UI.Choice(new List<int> { 1, 2, 0, 1,0, }, new List<string>
        {
            Color.NAME, "You walk into ",$"{shopKeep.name}'s",$" {shopKeep.job} Shop",
            Color.NAME, Color.CLASS, $" ", shopKeep.name, " the ", shopKeep.race, " comes over to greet you",
            "",
            Color.SPEAK,"", $"'Greetings, what can I do for you?'","",
            "",
        },
        Button.list1, Button.button1);
        Write.Line(50, 11, Color.ITEM, "Main Hand:  ", $"{Create.p.MainHand.Name} ", "");
        Write.Line(50, 12, Color.ITEM, "Off Hand:   ", $"{Create.p.OffHand.Name} ", "");
        Write.Line(50, 13, Color.ITEM, "Armor:      ", $"{Create.p.Armor.Name}   ", "");
        Write.Line(104, 27, "[" + Color.BLOOD + "?" + Color.RESET + "] " + Color.BLOOD + "MORE INFO" + Color.RESET);
        string choice = Return.Option();
        if (choice == "b" && shopKeep == weaponNPC)
        {
            UI.Choice(new List<int> { 1, 0, }, new List<string>
            {
                Color.SPEAK,"", $"'And what can I interest you in?'","",
                "",

            },
            new List<string> { "Swords", "Daggers", "Hammers", "Shields" }, new List<string> { Color.ITEM + "1" + Color.RESET, Color.ITEM + "2" + Color.RESET, Color.ITEM + "3" + Color.RESET, Color.ITEM + "4" + Color.RESET });
            Write.Line(50, 11, Color.ITEM, "Main Hand:  ", $"{Create.p.MainHand.Name} ", "");
            Write.Line(50, 12, Color.ITEM, "Off Hand:   ", $"{Create.p.OffHand.Name} ", "");
            Write.Line(50, 13, Color.ITEM, "Armor:      ", $"{Create.p.Armor.Name}   ", "");
            string choice2 = Return.Option();
            if (choice2 == "1") Buy(swordList, shopKeep);
            else if (choice2 == "2") Buy(daggerList, shopKeep);
            else if (choice2 == "3") Buy(bluntList, shopKeep);
            else if (choice2 == "4") Buy(shieldList, shopKeep);
            else Menu(shopKeep);
        }
        else if (choice == "b" && shopKeep == itemNPC)
        {
            UI.Choice(new List<int> { 1,0,1, 0, }, new List<string>
            {
                Color.SPEAK,"","'Just so you know, I get new Equipment EVERYDAY!","",
                "",
                Color.SPEAK,"", $"And what can I interest you in?'","",
                "",
            },
            new List<string> { "ffensive Items", "efensive Items" }, new List<string> { Color.ITEM + "O" + Color.RESET, Color.ITEM + "D" + Color.RESET,  });
            Write.Line(50, 11, Color.ITEM, "Main Hand:  ", $"{Create.p.MainHand.Name} ", "");
            Write.Line(50, 12, Color.ITEM, "Off Hand:   ", $"{Create.p.OffHand.Name} ", "");
            Write.Line(50, 13, Color.ITEM, "Armor:      ", $"{Create.p.Armor.Name}   ", "");
            string choice2 = Return.Option();
            if (choice2 == "o") Buy(itemOffenceAvailableList, shopKeep);
            else if (choice2 == "d") Buy(itemDefenceAvailableList, shopKeep);
            else Menu(shopKeep);
        }
        else if (choice == "b" && shopKeep == armorNPC) Buy(armorList, shopKeep);
        else if (choice == "b" && shopKeep == magicNPC) Buy(magicList, shopKeep);
        else if (choice == "h" && Button.healthPotionBuyButton.active) HealthPotion(shopKeep);
        else if (choice == "p" && Button.potionBuyButton.active) Potion(shopKeep);
        else if (choice == "a" && Button.jobButton.active) GameState.currentJob.Issue();
        else if (choice == "1" && (Button.SortMailButton.active || Button.InventoryButton.active || Button.BalanceBookButton.active || Button.PaintButton.active)) GameState.currentJob.Finish();
        else if (choice == "2" && (Button.turnInButton.active)) GameState.currentJob.Complete();
        else if (choice == "t" && Button.thieveryButton.active) Thief();
        else if (choice == "9") CharacterSheet.Display();
        else if (choice == "0") Utilities.ToTown();
        else if (choice == "s") Sell(shopKeep);
        else if (choice == "?") Info();
        Menu(shopKeep);
    }

    private static void Potion(NPC shopKeep)
    {        
        if(potionAvailableList.Count == 1)
        {
            UI.Keypress(new List<int> { 3 }, new List<string>
            {
                Color.SPEAK,Color.POTION,Color.SPEAK,"","Sorry, I'm all out of ","","potions","",".  Try again tomorrow",""
            });
        }
        else
        {
            Console.Clear();
            Write.SetY(15);
            UIComponent.TopBar();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }
            UIComponent.StandardMiddle(8);
            UIComponent.BarBlank();
            Write.Line(42, 7, Color.SPEAK + "Great! What would are you interested in?" + Color.RESET);
            Write.Line(48, 9, Color.SPEAK + "I get new " +Color.SPEAK + "potions" + Color.SPEAK +" every day" + Color.RESET);
            Write.Line(55, 11, "[0]Return");
            Write.Line(19, 18, string.Format("{0,-33 }{1,-41 }{2,-5 }", "Item", "Description", "Price"));
            for (int i = 1; i < potionAvailableList.Count; i++)
            {
                Write.Line(19, 18 + i * 2, $"[{i}]");
                Write.Line(23, 18 + i * 2, Color.POTION + potionAvailableList[i].name);
                Write.Line(52, 18 + i * 2, potionAvailableList[i].description);
                Write.Line(93, 18 + i * 2, Color.GOLD + potionAvailableList[i].value.ToString());
            }
            int choice = Return.Int();
            if (choice > 0 && choice < potionAvailableList.Count)
            {
                if (Create.p.Gold < potionAvailableList[choice].value)
                {
                    UI.Keypress(new List<int> { 0 }, new List<string>
                {
                    "You don't have enough gold!",
                });
                }
                else if (UI.Confirm(new List<int> { 1 }, new List<string> { Color.POTION, "Would you like to buy the ", $"{potionAvailableList[choice].name}", "?" }))
                {
                    Create.p.Gold -= potionAvailableList[choice].value;
                    Console.Clear();
                    UI.Keypress(new List<int> { 2 }, new List<string>
                {
                Color.NAME, Color.POTION,"Smiling, ",$"{shopKeep.name} ","takes your money and gives you your ",$"{potionAvailableList[choice].name}","",
                });
                    Create.p.AddDrop(potionAvailableList[choice]);
                    potionAvailableList.Remove(potionAvailableList[choice]);
                }
            }
        }        
    }

    private static void Quest()
    {

    }

    private static void Rob()
    {
        
    }

    private static void Thief()
    {
        
    }

    private static void Job()
    {
        
    }

    public static void Buy(List<Equipment> list, NPC shopKeep)
    {
        UI.Store(new List<int> { 0 }, new List<string>
        {
            ""
        },
        list);
        Write.Line(42,7, Color.SPEAK + "Great! What would you like to buy?"+ Color.RESET);
        Write.Line(50, 11, Color.ITEM, "Main Hand:  ", $"{Create.p.MainHand.Name} ", "");
        Write.Line(50, 12, Color.ITEM, "Off Hand:   ", $"{Create.p.OffHand.Name} ", "");
        Write.Line(50, 13, Color.ITEM, "Armor:      ", $"{Create.p.Armor.Name}   ", "");
        Write.Line(50, 9, "[0]Return");
        int choice = Return.Int();
        if (choice > 0 && choice < list.Count)
        {
            if (Create.p.Gold < list[choice].Price)
            {
                UI.Keypress(new List<int> { 0 }, new List<string>
                {
                    "You don't have enough gold!",
                });
            }
            else if (UI.Confirm(new List<int> { 1 }, new List<string> { Color.ITEM, "Would you like to buy the ", $"{list[choice].Name}", "?" }))
            {
                Create.p.Gold -= list[choice].Price;
                Console.Clear();
                UI.Keypress(new List<int> { 2 }, new List<string>
                {
                Color.NAME, Color.ITEM,"Smiling, ",$"{shopKeep.name} ","takes your money and gives you your ",$"{list[choice].Name}","",
                });
                Create.p.Equip(list[choice]);
                if (itemToSell != null)
                {
                    if (itemToSell.Name != "None" && itemToSell.Name != "Fist") SellOld(shopKeep, itemToSell);
                }
                else if (itemToSell2 != null)
                {
                    if (itemToSell2.Name != "None" && itemToSell2.Name != "Fist") SellOld(shopKeep, itemToSell2);
                }
            }

        }
        Menu(shopKeep);
    }

    public static void SellOld(NPC shopKeep,  Equipment current)
    {
        Console.Clear();
        Create.p.Gold += current.Price / 2;
        UI.Keypress(new List<int> { 3, 0, 2 }, new List<string>
        {
            Color.NAME,Color.ITEM, Color.GOLD, "",$"{shopKeep.name} ","takes your ",current.Name , " and gives you ",$"{(current.Price) / 2} ", "gold",
        });
    }

    public static void Sell(NPC shopKeep)
    {
        if (Create.p.MainHand.Name == "Fist" && Create.p.OffHand.Name == "Fist" && Create.p.Armor.Name == "None")
        {
            UI.Keypress(new List<int> { 0 }, new List<string>
            {
                "You have nothing to sell!",
            });
        }
        else
        {
            Console.Clear();
            List<Equipment> EquipmentList = new List<Equipment> { new Blunt("Fist",0,0,0,false,0) };
            if (Create.p.MainHand.Name != "Fist") { EquipmentList.Add(Create.p.MainHand); }
            if (Create.p.OffHand.Name != "Fist" && Create.p.OffHand.Name != "Two Hand") { EquipmentList.Add(Create.p.OffHand); }
            if (Create.p.Armor.Name != "None") { EquipmentList.Add(Create.p.Armor); }
            UI.StoreSell(new List<int> { 0, 0, 0 }, new List<string>
            {
                "What would you like to Sell?",
                "",
                "[0] Return"
            }, EquipmentList);
            Console.SetCursorPosition(58, 14);
            int sellChoice;
            do
            {

            } while (!int.TryParse(Console.ReadKey(true).KeyChar.ToString().ToLower(), out sellChoice));
            if (sellChoice > 0 && sellChoice < EquipmentList.Count)
            {
                if (UI.Confirm(new List<int> { 2 }, new List<string> { Color.ITEM, Color.GOLD, "Would you Like to sell your ", $"{EquipmentList[sellChoice].Name} ", "? I'll give you ", $"{EquipmentList[sellChoice].Price / 2} ", "for it" }))
                {
                    Create.p.Gold += EquipmentList[sellChoice].Price / 2;
                    if (Create.p.Armor == EquipmentList[sellChoice]) Create.p.Armor = Equipment.armorList[0];
                    if (Create.p.OffHand == EquipmentList[sellChoice]) Create.p.OffHand = Equipment.bluntList[0];
                    else if (Create.p.MainHand == EquipmentList[sellChoice]) Create.p.MainHand = Equipment.bluntList[0];
                    UI.Keypress(new List<int> { 3 }, new List<string>
                    {
                        Color.NAME,Color.ITEM, Color.GOLD, "Great! ",$"{ shopKeep.name} ","takes your ",$"{EquipmentList[sellChoice].Name} ", "and gives you ",$"{EquipmentList[sellChoice].Price / 2} ", "gold",
                    });
                    Create.p.UnequipItem(EquipmentList[sellChoice]);
                }                
            }
        }
    }

    private static void HealthPotion(NPC shopKeep)
    {
        if (UI.Confirm(new List<int> { 2, 0, 0 }, new List<string>
            {
                Color.HEALTH, Color.GOLD,"Upgrading your ", "potion ", "will cost ", $"{upgrade[current]} ", "gold.",
                "",
                "Would you like to do this?"
            }))
        {
            if (Return.HaveGold(upgrade[current]))
            {
                UI.Keypress(new List<int> { 3, 0, 0, 0, 1, 0, 2 }, new List<string>
                {
                    Color.NAME, Color.GOLD, Color.HEALTH,"", $"{shopKeep.name}", " takes your ","money ","and your ","potion","",
                    "",
                    "He takes your potion to the back, and returns 5 minutes later",
                    "",
                    Color.SPEAK,"","'Here you go! Your potion is now bigger!'","",
                    "",
                    Color.HEALTH,Color.HEALTH,"Your ","potion ","can now heal up to ",$"{healAdd[current]} ","more hp!"
                });
                Create.p.Gold -= upgrade[current];
                Create.p.MaxPotionSize += healAdd[current];
                Create.p.PotionSize = Create.p.MaxPotionSize;
                current++;
            }
            else
                UI.Keypress(new List<int> { 0 }, new List<string>
                {
                    "You don't have enough gold!",
                });
        }
    }


    public static void Info()
    {
        Console.Clear();
        Write.Line(Color.BLOOD, "", "MORE INFO", "\n\n");
        Console.WriteLine(Color.ITEM + "Items" + Color.RESET + " are a very important part of " + Color.ENERGY + "Marburgh" + Color.RESET + "\n\nThe right " + Color.ITEM + "item" + Color.RESET + " can mean the difference between sucess and " + Color.DAMAGE + "death" + Color.RESET + ".");
        Console.WriteLine("\n\n" + Color.CLASS + "CHARACTER SCREEN" + Color.RESET + "\n\nPress [" + Color.CLASS + "9" + Color.RESET + "] from the shop to see your character information, including which items you currently have equiped");
        Console.WriteLine("\n\n" + Color.GOLD + "BUYING" + Color.RESET + "\n\n" + Color.ITEM + "Items" + Color.RESET + " are listed in the store in order of price as well as power.\nTo purchase an item, select [" + Color.ITEM + "B" + Color.RESET + "]uy, then the " + Color.ITEM + "item" + Color.RESET + " you would like to purchase.\nIf you have the required " + Color.GOLD + "gold" + Color.RESET + ", you can purchase it");
        Console.WriteLine("\n\n" + Color.GOLD + "SELLING" + Color.RESET + "\n\nWhen you sell an " + Color.ITEM + "item" + Color.RESET + ", you will receive half of the item's " + Color.GOLD + "value" + Color.RESET + "");
        Console.WriteLine("\nIf you attempt to equip an " + Color.ITEM + "item" + Color.RESET + " in a slot that already has one, you will be prompted to sell your current item\n\n\n");
        Utilities.Keypress();
    }
}